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
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;


namespace CGD_szerver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [Serializable]
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            server.users.Add(new user("Elyth", "passwd01"));
            server.users.Add(new user("Zooli", "passwd01"));
            server.users.Add(new user("Niki", "jelszó"));
            server.users.Add(new user("Barbi", "jelszó"));
            server_run = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        bool server_run;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!server_run)
            {
                TcpChannel chan = new TcpChannel(8085);
                ChannelServices.RegisterChannel(chan, false);
                RemotingConfiguration.RegisterWellKnownServiceType(
                   typeof(peldanyosito),
                   "SzerverPeldanyosito",
                   WellKnownObjectMode.Singleton);
                server_run = true;
                MessageBox.Show("A szerver elindult!");
            }
            else
            {
                MessageBox.Show("A szerver már fut");
            }
            
        }
    }
}
