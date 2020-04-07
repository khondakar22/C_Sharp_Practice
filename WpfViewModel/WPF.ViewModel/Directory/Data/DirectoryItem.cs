using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.ViewModel.Directory.Data
{
    /// <summary>
    /// Information about a directory item  such as a drive,a file or a folder
    /// </summary>
    public class DirectoryItem
    {
        /// <summary>
        /// The type of this item
        /// </summary>
        public DirectoryItemType Type { get; set; }
        /// <summary>
        /// The absolute path to this item 
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// The name of this directory items
        /// </summary>
        public string Name =>
            this.Type == DirectoryItemType.Drive
                ? this.FullPath
                : DirectoryStructure.GetFileFolderName(this.FullPath);
    }
}
