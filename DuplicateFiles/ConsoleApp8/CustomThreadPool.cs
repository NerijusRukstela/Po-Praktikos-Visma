using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConsoleApp8
{
    public class CustomThreadPool
    {
        private readonly IList<Thread> _threadsList;
        private readonly DuplicateFilesFinder _duplicateFilesFinder;
        
        public CustomThreadPool(DuplicateFilesFinder duplicateFilesFinder)
        {
            _threadsList = new List<Thread>();
            _duplicateFilesFinder = duplicateFilesFinder;
        }
        
        public void CreateAndStartSearchThreads(int threadsCount)
        {
            for (int i = 0; i < threadsCount; i++)
            {
                var thread = new Thread(delegate ()
                {
                    _duplicateFilesFinder.FindFileDuplicates();
                });
                _threadsList.Add(thread);
                thread.Start();
            }
        }
        
        public void WaitForThreadsToFinish()
        {
            while (_threadsList.All(t => t.ThreadState != ThreadState.Stopped))
            {
                Console.WriteLine("Threads are working");
            }
        }
    }
}