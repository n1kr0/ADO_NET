using PostExample.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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


//Зробити таблицю для постів(через Code First).
//У таблиці є поле
//ід, заголовок(макс: 200), контент(макс:5000), дата кінцевого оновлення(не обов'язково), дата створення(обов'язково), посилання(також перевірка на чи є це посилання.)
//Також є юзери, які викладають пости.
//У них є емейл(має бути перевірка), ім'я, номер телефону(також перевірка як +38(000)000-00-00), вік(не менше 15).
//Заповнити таблиці тестовими данними.

//Зробити можливість виводу постів, сортування їх по контенту і по даті створення. 
//Можливість виводу юзерів і сортування їх по імені і по віку.
//Також є пошук по назві поста, і по проміжку по даті.
//Пишете на чому завгодно.



namespace PostExample
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (PEContext context = new PEContext())
            {
                dgPostsUser.ItemsSource = context.Posts.ToList();

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (PEContext context = new PEContext())
            {
                dgPostsUser.ItemsSource = context.Users.ToList();

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            List<Post> Res = new List<Post>();
            List<Post> FinRes = new List<Post>();
            using (PEContext context = new PEContext())
            {
                foreach (var item in context.Posts)
                {
                    if (item.Name.Contains(tbSearchName.Text))
                    {
                        Res.Add(item);
                    }
                }

                foreach (var item in Res)
                {
                    if (FromDate.SelectedDate<=item.DataOfCreate&& ToDate.SelectedDate>= item.DataOfCreate)// додумати))
                    {
                        FinRes.Add(item);
                    }
                }
                dgPostsUser.ItemsSource = FinRes;

            }

        }
    }

}
