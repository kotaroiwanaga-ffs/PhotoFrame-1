using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using PhotoFrame.Domain.Model;
using PhotoFrame.Persistence;


namespace PhotoFrame.Domain.UseCase
{
    public class SearchFolder
    {
        private readonly RepositoryMaster repositoryMaster;
        private readonly IPhotoFileService photoFileService;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="repositoryMaster"></param>
        /// <param name="photoFileService"></param>
        public SearchFolder(RepositoryMaster repositoryMaster, IPhotoFileService photoFileService)
        {
            this.repositoryMaster = repositoryMaster;
            this.photoFileService = photoFileService;
        }

        /// <summary>
        /// �w�肵���t�H���_�p�X�z���̉摜�t�@�C����Photo�^�ɕϊ����ă��X�g�ŕԂ�
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns></returns>
        public IEnumerable<Photo> Execute(string folderPath)
        {
            List<Photo> photos = new List<Photo>();

            // folderPath�z���ɂ��邷�ׂẲ摜�t�@�C���p�X���擾
            IEnumerable<File> files = photoFileService.FindAllPhotoFilesFromDirectory(folderPath);

            // �t�@�C���p�X�̐���100�ȉ��̎��̂�Photo�^�ϊ����s��
            if(files.Count() <= 100)
            {
                foreach (File file in files)
                {
                    Func<IQueryable<Photo>, Photo> query = ((folderPhotos) =>
                    {
                        return folderPhotos
                            .Where(p => p.File.FilePath == file.FilePath)
                            .FirstOrDefault();
                    });

                    // �ۑ��ς݃t�@�C���p�X��������
                    Photo hitPhoto = repositoryMaster.FindPhoto(query);

                    // �ۑ��ς݂̉摜�������ꍇ
                    if (hitPhoto != null)
                    {
                        // �摜�t�@�C���̎B�e�����擾�����݂邱�ƂŃf�[�^�j�����Ȃ����m�F
                        if (GetFilmingDate(file.FilePath) != null)
                        {
                            photos.Add(hitPhoto);
                        }
                    }
                    // ���ۑ��̉摜�������ꍇ
                    else
                    {
                        // �摜�t�@�C������B�e�������擾
                        DateTime? date = GetFilmingDate(file.FilePath);

                        if (date != null)
                        {
                            photos.Add(new Photo(file, (DateTime)date));
                        }
                    }
                }

                // �t�H���_�����̌��ʂł���Photo�̃��X�g��repositoryMaster�ɕۑ������Ă���
                this.repositoryMaster.SetAllPhotos(photos);
            }

            return photos;
        }

        // �摜����B�e�������擾
        private DateTime? GetFilmingDate(string filePath)
        {
            System.IO.FileStream stream = System.IO.File.OpenRead(filePath);
            Image image;

            try
            {
                image = Image.FromStream(stream, false, false);
            }
            catch (Exception)
            {
                return null; // �f�[�^���j�����Ă����ꍇ
            }

            DateTime date = new DateTime();

            // �B�e�����擾�����݂�
            foreach (PropertyItem item in image.PropertyItems)
            {
                if (item.Id == 0x9003 && item.Type == 2)
                {
                    string val = System.Text.Encoding.ASCII.GetString(item.Value);
                    val = val.Trim(new char[] { '\0' });
                    date = DateTime.ParseExact(val, "yyyy:MM:dd HH:mm:ss", null);
                }
            }

            if (date != null)
            {
                return date; // �B�e�������擾�ł����ꍇ
            }
            else
            {
                return new DateTime(); // �B�e�������ݒ肳��Ă��Ȃ������ꍇ
            }
        }

    }
}
