using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using WPF.ViewModel.Directory;
using WPF.ViewModel.Directory.Data;

namespace WPF.ViewModel
{
    /// <summary>
    /// Converts a full path to a specific image type of a drive, folder or file
    /// </summary>
    ///
    [ValueConversion(typeof(DirectoryItemType), typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
          

            // By Default, we presume an image
            var image = "img/file.png";

            // If the name is blank,  we presume it's a drive as we cannot have a blank file or folder name
            if (value != null)
                switch (((DirectoryItemType) value))
                {
                    case DirectoryItemType.Drive:
                        image = "img/drive.png";
                        break;
                    case DirectoryItemType.Folder:
                        image = "img/folder-closed.png";
                        break;
                }

            return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
