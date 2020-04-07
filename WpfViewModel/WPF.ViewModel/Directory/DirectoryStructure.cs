using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPF.ViewModel.Directory.Data;


namespace WPF.ViewModel.Directory
{
    /// <summary>
    /// A helper class to query information about directories
    /// </summary>
   public static class DirectoryStructure
    {
        #region Get Drivers
        /// <summary>
        /// Get all logical drives on the computer
        /// </summary>
        public static List<DirectoryItem> GetLogicalDrive()
        {
            
          // Get every logical drive on the machine
          return System.IO.Directory.GetLogicalDrives().Select(drive => new DirectoryItem
          {
              FullPath = drive,
              Type = DirectoryItemType.Drive
          }).ToList();

        }
        #endregion

        #region Get Driectories Item
        /// <summary>
        /// Get the directories top-level content
        /// </summary>
        /// <param name="fullPath">The full path to the content into the directory</param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            #region Initial Checks

            // Create empty list
            var items = new List<DirectoryItem>();


            #endregion

            #region Get Folders

            // Try and get directories from the folder
            // ignoring any issues doing so
            try
            {
                var dirs = System.IO.Directory.GetDirectories(fullPath);

                if (dirs.Length > 0)
                    items.AddRange(dirs.Select(dir => new DirectoryItem
                    {
                        FullPath = dir,
                        Type = DirectoryItemType.Folder
                    }));
            }
            catch { }


            #endregion

            #region Get Files


            // Try and get files from the folder
            // ignoring any issues doing so
            try
            {
                var fs = System.IO.Directory.GetFiles(fullPath);

                if (fs.Length > 0)
                    items.AddRange(fs.Select(file => new DirectoryItem
                    {
                        FullPath = file,
                        Type = DirectoryItemType.File
                    }));
            }
            catch { }

            #endregion

            return items;
        }

        #endregion

        #region Helpers
        /// <summary>
        /// Find the file or folder name from a full path
        /// </summary>
        /// <param name="path">The full path</param>
        /// <returns></returns>
        public static string GetFileFolderName(string path)
        {
            // If we have no path, return empty
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            // Make all slashes back slashes
            var normalizedPath = path.Replace('/', '\\');

            // Find the last backslash in the path
            var lastIndex = normalizedPath.LastIndexOf('\\');

            // If we don't find a backslash, return the path itself
            if (lastIndex <= 0)
                return path;

            // Return the name after the last back slash
            return path.Substring(lastIndex + 1);
        }

        #endregion
    }
}
