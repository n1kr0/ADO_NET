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

namespace BookShop
{
        // Второй вариантСоздать приложение «Музыкальный магазин».  
        // Основная задача  проекта:  учитывать текущий  ассортимент музыкальных  
        // пластинок в магазине.Необходимо хранить  следующую информацию  о пластинках: 
        // название пластинки, название коллектива, название издателя, количество треков, 
        // жанр, год издания, себестоимость, цена для продажи.
        // Экзаменационное задание по ADO.NETстр. 2 из 2Приложение должно позволять: 
        // добавлять пластинки, удалять пластинки, редактировать параметры пластинок,
        // продавать пластинки, списывать пла-стинки, вносить пластинки  в акции
        //(например, неделя пластинок  джаза  со скидкой 10%), 
        //откладывать диски для конкретного покупателя.
        //Приложение должно предоставить функциональность
        //по поиску дисков по таким параметрам: название диска,
        //исполнитель, жанр. Приложение долж-но предоставлять возможность
        //просмотреть список новинок, список самых продаваемых  пластинок,  
        //список самых  популярных авторов, список  самых популярных жанров по итогам дня,
        //недели, месяца, года. Необходимо предусмотреть возможность входа по логину и паролю.
        //Также нужно сделать возможность регистрации постоянных покупателей
        //и создать систему скидок в зависимости от накопленной суммы потраченных средств.


    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRegistr_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ShopWindow shopWindow = new ShopWindow();
            shopWindow.ShowDialog();
        }
    }
}
