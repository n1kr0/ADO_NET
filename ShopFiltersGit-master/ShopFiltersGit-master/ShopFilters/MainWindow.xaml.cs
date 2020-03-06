using BLL.Interfaces;
using BLL.Service;
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

namespace ShopFilters
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IFilterService _filterService = new FilterService();
            foreach (var item in _filterService.GetAll())
            {
                TreeViewItem tvi = new TreeViewItem();
                tvi.Header = item.Name;
                foreach (var child in item.Values)
                {
                    tvi.Items.Add(new TreeViewItem()
                    {
                        Header = child.Name
                    });

                }
                tvFilters.Items.Add(tvi);
            }
        }
    }
}
