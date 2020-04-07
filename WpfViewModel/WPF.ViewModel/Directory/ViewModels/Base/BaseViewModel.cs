using System.ComponentModel;
using PropertyChanged;

namespace WPF.ViewModel.Directory.ViewModels.Base
{
    /// <summary>
    /// A base view mode that fires Property Changed events as needed
    /// </summary>
    [AddINotifyPropertyChangedInterface]
   public class BaseViewModel: INotifyPropertyChanged
    {
        /// <summary>
        /// The event that is fired when any child property will fire
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => {};

    }
}
