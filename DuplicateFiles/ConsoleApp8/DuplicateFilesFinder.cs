using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    public class DuplicateFilesFinder
    {
        private readonly int _threadsCount;
        private readonly CustomThreadPool _threadPool;
        private IList<string> _duplicates;
        private IList<HashFile> _filesToSearch;
        
        private readonly string _searchFolderPath;

        public DuplicateFilesFinder(string searchFolderPath, int threadsCount)
        {
            _searchFolderPath = searchFolderPath;
            _threadsCount = threadsCount;
            _threadPool = new CustomThreadPool(this);
        }
        
        public void Search()
        {
            _filesToSearch = GetHashFiles(Directory.GetFiles(_searchFolderPath));
            _duplicates = new List<string>();
            _threadPool.CreateAndStartSearchThreads(_threadsCount);
            _threadPool.WaitForThreadsToFinish();
            FileDuplicateHelper.WriteToOutputFile(_duplicates);
        }

        private static IList<HashFile> GetHashFiles(IEnumerable<string> filesPaths)
        {
            return filesPaths.Select(file => new HashFile()
            {
                FileName = file,
                HashValue = FileDuplicateHelper.GetHash(file)
            }).ToList();
        }
        
        public void FindFileDuplicates()
        {
            while (_filesToSearch.Any(f => f.Processed == false))
            {
                var file = _filesToSearch.First(f => f.Processed == false);
                file.Processed = true;
                var index = _filesToSearch.IndexOf(file);

                for (int i = index + 1; i < _filesToSearch.Count; i++)
                {
                    var nextFile = _filesToSearch[i];
                    lock (_duplicates)
                    {
                        if (file.HashValue == nextFile.HashValue && _duplicates.All(f => f != nextFile.FileName))
                        {
                            _duplicates.Add(_filesToSearch[i].FileName);
                        }
                    }
                }
            }
        }
    }
}
