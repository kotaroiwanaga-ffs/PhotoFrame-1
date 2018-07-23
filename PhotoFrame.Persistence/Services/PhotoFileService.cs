using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PhotoFrame.Persistence
{
    /// <summary>
    /// <see cref="IPhotoFileService">の実装クラス
    /// </summary>
    class PhotoFileService : IPhotoFileService
    {
        public IEnumerable<Domain.Model.File> FindAllPhotoFilesFromDirectory(string directory)
        {
            // TODO: コレクション講座で実装予定
            List<Domain.Model.File> file_list = new List<Domain.Model.File>();

            // directoryが存在する場合
            if (Directory.Exists(directory))
            {
                List<string> path_list = new List<string>();

                try
                {
                    path_list = Enumerate(directory, DateTime.Now);
                }
                catch (Exception)
                {
                    return file_list;
                }

                foreach (string filePath in path_list)
                {
                    Domain.Model.File file = new Domain.Model.File(filePath);

                    if(file.IsPhoto)
                    {
                        file_list.Add(file);
                    }
                }

            }

            return file_list;
            
        }

        private List<string> Enumerate(string dir, DateTime startTime)
        {
            List<string> file_list = new List<string>();
            TimeSpan elapsedTime = DateTime.Now - startTime;

            if(elapsedTime.Seconds < 10000)
            {
                try
                {
                    string[] files = Directory.GetFiles(dir);

                    foreach (string s in files)
                    {
                        file_list.Add(s);
                    }

                    string[] dirs = Directory.GetDirectories(dir);

                    foreach (string s in dirs)
                    {
                        List<string> temp_list = Enumerate(s, startTime);

                        foreach (string t in temp_list)
                        {
                            file_list.Add(t);
                        }
                    }

                    return file_list;
                }
                catch (Exception)
                {
                    return file_list;
                }
            }
            else
            {
                throw new Exception();
            }
            
            
        }
    }
}
