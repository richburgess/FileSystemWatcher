using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Howmet.Utilities.FileSystem
{

    /// <summary>
    /// A class that wraps FileSystemWatcher that is meant to be a single entity in a 
    /// collection of FileWatchers used to monitor directory structures.
    /// </summary>
    public class FileWatcher : FileSystemEventHandlers
    {

        #region Constants


        #endregion

        #region Declarations

        private string Path = "";
        private FileSystemWatcher Watcher = new FileSystemWatcher();
        private FileSystemEventHandlers Events = new FileSystemEventHandlers();

        #endregion

        #region Constructors

        public FileWatcher(string path)
        {
            Path = System.IO.Path.GetDirectoryName(path);
            Watcher.Path = Path;
            SendMessage(string.Format("Watching: {0}", Path));
            Watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.LastAccess | NotifyFilters.CreationTime | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            Watcher.IncludeSubdirectories = true;
            // Watch all files.
            Watcher.Filter = "*.*";
            Watcher.Created += Watcher_FileCreated;
            Watcher.Changed += Watcher_FileModified;
            Watcher.Renamed += Watcher_Renamed;
            Watcher.Deleted += Watcher_Deleted;
            // Begin watching.
            Watcher.EnableRaisingEvents = true;
        }

        #endregion

        #region Event Handling

        private void Watcher_FileCreated(object sender, FileSystemEventArgs e)
        {
            OnFileCreated(e);
        }

        private void Watcher_FileModified(object sender, FileSystemEventArgs e)
        {
            OnFileModified(e);
        }

        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            OnFileRenamed(e);
        }

        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            OnFileDeleted(e);
        }

        #endregion

        #region Private Methods

        private void SendMessage(string message)
        {
            MessageAvailableEventArgs eArgs = new MessageAvailableEventArgs();
            eArgs.Message = message;
            OnMessageAvailable(eArgs);
        }

        #endregion

        #region Public Methods

        public void Shutdown()
        {
            Watcher.EnableRaisingEvents = false;
            Watcher.Dispose();
        }

        #endregion

    }

}
