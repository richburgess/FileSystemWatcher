using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Howmet.Utilities.FileSystem
{

    /// <summary>
    /// Holds, initiates and manages a collection of FileWatchers.
    /// </summary>
    public class WatcherManager:FileSystemEventHandlers
    {

        #region Constants

        #endregion

        #region Declarations

        List<string> Paths = new List<string>();
        List<FileWatcher> Watchers = new List<FileWatcher>();

        #endregion

        #region Constructors

        public WatcherManager(List<string> paths)
        {
            Paths = paths;
            foreach (string path in Paths)
            {
                FileWatcher fileWatcher = new FileWatcher(path);
                Watchers.Add(fileWatcher);
                fileWatcher.MessageAvailable += FileWatcher_MessageAvailable;
                fileWatcher.FileCreated += FileWatcher_FileCreated;
                fileWatcher.FileDeleted += FileWatcher_FileDeleted;
                fileWatcher.FileModified += FileWatcher_FileModified;
                fileWatcher.FileRenamed += FileWatcher_FileRenamed;
                
            }
        }

        #endregion
        
        #region Event Handling

        private void FileWatcher_MessageAvailable(object sender, MessageAvailableEventArgs e)
        {
            OnMessageAvailable(e);
        }

        private void FileWatcher_FileCreated(object sender, FileSystemEventArgs e)
        {
            OnFileCreated(e);
        }

        private void FileWatcher_FileModified(object sender, FileSystemEventArgs e)
        {
            OnFileModified(e);
        }

        private void FileWatcher_FileRenamed(object sender, RenamedEventArgs e)
        {
            OnFileRenamed(e);
        }

        private void FileWatcher_FileDeleted(object sender, FileSystemEventArgs e)
        {
            OnFileDeleted(e);
        }

        #endregion

        #region Public Methods

        public void ShutItDown()
        {
            foreach (FileWatcher watcher in Watchers)
            {
                watcher.Shutdown();
            }
        }

        #endregion

    }

}
