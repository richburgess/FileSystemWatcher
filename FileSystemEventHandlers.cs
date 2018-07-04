using System;
using System.IO;

namespace Howmet.Utilities.FileSystem
{
    /// <summary>
    /// An inheritable class of event handlers for a common interface.
    /// </summary>
    public class FileSystemEventHandlers
    {

        public event EventHandler<MessageAvailableEventArgs> MessageAvailable;
        public event EventHandler<FileSystemEventArgs> FileCreated;
        public event EventHandler<FileSystemEventArgs> FileModified;
        public event EventHandler<RenamedEventArgs> FileRenamed;
        public event EventHandler<FileSystemEventArgs> FileDeleted;

        /// <summary>
        /// Used as a way to bubble messages up the stack.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnMessageAvailable(MessageAvailableEventArgs e)
        {
            MessageAvailable?.Invoke(this, e);
        }

        /// <summary>
        /// Fired when a file is created in the watched directory.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnFileCreated(FileSystemEventArgs e)
        {
            FileCreated?.Invoke(this, e);
        }

        /// <summary>
        /// Fired when a file is modified in the watched directory.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnFileModified(FileSystemEventArgs e)
        {
            FileModified?.Invoke(this, e);
        }

        /// <summary>
        /// Fired when a file is renamed in the watched directory.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnFileRenamed(RenamedEventArgs e)
        {
            FileRenamed?.Invoke(this, e);
        }

        /// <summary>
        /// Fired when a file is deleted from the watched directory.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnFileDeleted(FileSystemEventArgs e)
        {
            FileDeleted?.Invoke(this, e);
        }


    }
}
