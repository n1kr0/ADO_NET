using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.IO;

namespace _1_Processes_HW
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

        private void Add(object sender, RoutedEventArgs e)
        {
            if (textbox.Text != "")
            {
                Process proc = new Process();
                proc.StartInfo = new ProcessStartInfo(textbox.Text + ".exe");
                proc.Start();
                Refresh(sender, e);
            }
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            Check();
            list.ItemsSource = null;
            list.ItemsSource = Process.GetProcesses();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (list.SelectedItem != null)
            {
                foreach (var item in Process.GetProcessesByName(((Process)list.SelectedItem).ProcessName))
                    item.Kill();
                Refresh(sender, e);
            }
        }
        public void Check()
        {
            Process proc = new Process();

        }
    }
}
