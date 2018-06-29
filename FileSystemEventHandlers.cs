using System;
using System.IO;

namespace Howmet.Utilities.FileSystem
{
    public class FileSystemEventHandlers
    {

        public event EventHandler<MessageAvailableEventArgs> MessageAvailable;
        public event EventHandler<FileSystemEventArgs> FileCreated;
        public event EventHandler<FileSystemEventArgs> FileModified;
        public event EventHandler<RenamedEventArgs> FileRenamed;
        public event EventHandler<FileSystemEventArgs> FileDeleted;

        protected virtual void OnMessageAvailable(MessageAvailableEventArgs e)
        {
            MessageAvailable?.Invoke(this, e);
        }

        protected virtual void OnFileCreated(FileSystemEventArgs e)
        {
            FileCreated?.Invoke(this, e);
        }

        protected virtual void OnFileModified(FileSystemEventArgs e)
        {
            FileModified?.Invoke(this, e);
        }

        protected virtual void OnFileRenamed(RenamedEventArgs e)
        {
            FileRenamed?.Invoke(this, e);
        }

        protected virtual void OnFileDeleted(FileSystemEventArgs e)
        {
            FileDeleted?.Invoke(this, e);
        }


    }
}
