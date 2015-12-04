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
using CGD_interface;

namespace CGD_kliens
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Iserver b;
        string id;
        public MainWindow()
        {
            InitializeComponent();
            b = null;
            //connect();
        }

        void connect()
        {
            try
            {
                IPeldanyosit m = (IPeldanyosit)Activator.GetObject(typeof(IPeldanyosit), "tcp://localhost:8085/Peldanyosito");
                id = m.peldanytkeszit();
                b = (Iserver)Activator.GetObject(typeof(Iserver), "tcp://localhost:8085/" + id);
            }
            catch { MessageBox.Show("Nincs kapcsolat a szerverrel"); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (b != null)
            {
                b.logout();
            }
            
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (b.login(l_name.Text, passwd.Password,id))
                {
                    MessageBox.Show("bejelentkezés sikeres!");
                }
                else
                {
                    MessageBox.Show("sikertelen bejelentkezés!");
                }

            }
            catch { MessageBox.Show("Hiba"); }
        }
    }
}
