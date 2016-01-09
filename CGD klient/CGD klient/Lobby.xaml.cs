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
using System.Windows.Shapes;
using CGD_interface;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;

namespace CGD_klient
{
    /// <summary>
    /// Interaction logic for Lobby.xaml
    /// </summary>
    public partial class Lobby : Window
    {
        Iserver b;
        string id;
        string user;
        public Lobby(Iserver b, string id, string user)
        {
            InitializeComponent();
            this.b = b;
            this.id = id;
            this.user = user;
            init_lobby();
        }
        void init_lobby()
        {
            player_list.Items.Clear();
            List<string> players = b.get_players();
            foreach (string item in players)
            {
                player_list.Items.Add(item);
            }
            p_name.Content = user;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Memory m = new Memory();
            this.Visibility = Visibility.Collapsed;
            m.ShowDialog();
            this.Visibility = Visibility.Visible;
            this.Close();
        }
    }
}
