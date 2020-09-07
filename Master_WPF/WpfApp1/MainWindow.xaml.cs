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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Grid grid = new Grid();
            this.Content = grid;
            
            Button btn = new Button();
            btn.FontSize = 26;
            
            WrapPanel wrapPanel = new WrapPanel();
            TextBlock txt1 = new TextBlock();
            txt1.Text = "Multi";
            txt1.Foreground = Brushes.Blue;
            wrapPanel.Children.Add(txt1);

            txt1 = new TextBlock();
            txt1.Text = "Color";
            txt1.Foreground = Brushes.Red;
            wrapPanel.Children.Add(txt1);

            txt1 = new TextBlock();
            txt1.Text = "Button";
            txt1.Foreground = Brushes.Wheat;
            wrapPanel.Children.Add(txt1);


            btn.Content = wrapPanel;
            grid.Children.Add(btn);
        }
    }
}
