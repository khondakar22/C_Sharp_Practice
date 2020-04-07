using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.ViewModel.Directory.ViewModels.Base;

namespace WPF.ViewModel.Directory.ViewModels
{
    /// <summary>
    /// The view model
    /// </summary>
    public class DirectoryStructureViewModel : BaseViewModel
    {

        /// <summary>
        /// A list of all directories
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public DirectoryStructureViewModel()
        {
            var children = DirectoryStructure.GetLogicalDrive();
            this.Items = new ObservableCollection<DirectoryItemViewModel>( 
                children.Select(drive => new DirectoryItemViewModel(drive.FullPath, drive.Type)));
        }
    }
}
