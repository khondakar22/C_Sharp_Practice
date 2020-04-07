using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void ApplyButton_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"The Description is {this.DescriptionText}");
        }

        private void ResetButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.WeldCheckBox.IsChecked = this.AssemblyCheckBox.IsChecked = this.DrillCheckBox.IsChecked =
                this.FoldCheckBox.IsChecked = this.LaserCheckBox.IsChecked
                    = this.LatheCheckBox.IsChecked = this.PlasmaCheckBox.IsChecked = this.RollCheckBox.IsChecked =
                        this.PurchaseCheckBox.IsChecked = this.SawCheckBox.IsChecked = false;
        }

        private void CheckBox_OnChecked(object sender, RoutedEventArgs e)
        {
            this.LengthTextBox.Text += (string)((CheckBox) sender).Content;
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.NoteBox == null)
            {
                return;
            }
            var combo = (ComboBox) sender;
            var value = (ComboBoxItem) (combo).SelectedValue;
            this.NoteBox.Text += (string)(value).Content;
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
           Selector_OnSelectionChanged(this.FinishDropDown, null);
        }

        private void SupplierNameText_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            this.MassText.Text = this.SupplierNameText.Text;
        }
    }

   
}
