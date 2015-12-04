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
            server.get_window(this);
            server.users.Add(new user("Elyth", "salynet"));
            server.users.Add(new user("Zooli", "salynet"));
            server.users.Add(new user("Niki", "kiscica"));
            server.init_users();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        public void to_log(string name)
        {
            online.Items.Add(name);
            log.Items.Add(string.Format("{0} bejelentkezett", name));
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TcpChannel chan = new TcpChannel(8085);
            ChannelServices.RegisterChannel(chan, false);
            RemotingConfiguration.RegisterWellKnownServiceType(
               typeof(peldanyosito),
               "Peldanyosito",
               WellKnownObjectMode.Singleton);
            log.Items.Add("Szerver elindult");
        }
    }
}
