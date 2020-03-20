using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
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

namespace WpfBackgroundWorker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BackgroundWorker backgroundWorker;

        public MainWindow()
        {
            InitializeComponent();
            backgroundWorker = ((BackgroundWorker)this.FindResource("bgWorker"));
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        { 
            using (UsersContext context=new UsersContext())
            {
                List<users> ListUs = context.users.ToList();

                foreach (users us in ListUs)
                {
                    SendMail(us.E_mail);
                }
            }
            int sum = 0;
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(100);
                sum += i;
                backgroundWorker.ReportProgress(i);
                if(backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    backgroundWorker.ReportProgress(0);
                    return;
                }
            }
            e.Result = sum;
        }

        private void SendMail(string email)
        {
            MailMessage msg = new MailMessage()
            {
                From=new MailAddress("nikro.ua.1974@gmail.com"),
                Body="<div style 'color:red' Hello friend! </div>",
                Subject="test message",
                IsBodyHtml=true,
                
             };
            msg.To.Add(email);


            using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential("nikro.ua.1974@gmail.com", "241912&&!=Dsnz");
                smtpClient.Send(msg);
            }
        
        }
        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Cancelled)
            {
                MessageBox.Show("Припинено!");
            }
            else
            {
                MessageBox.Show(e.Result.ToString());
            }
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbProgress.Value = e.ProgressPercentage;
           labelName.Content =""+e.ProgressPercentage+" %";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();
            }
        }
    }
}
