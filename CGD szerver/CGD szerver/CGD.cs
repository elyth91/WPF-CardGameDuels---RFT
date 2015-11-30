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
using CGD_interface;

namespace CGD_szerver
{
    class peldanyosito :  MarshalByRefObject, IPeldanyosit
    {
        string IPeldanyosit.peldanytkeszit()
        {
            string id = Guid.NewGuid().ToString();
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(server), id, WellKnownObjectMode.Singleton);
            return id;
        }
    }
    class server : MarshalByRefObject, Iserver
    {
        static List<user> users = new List<user>();
        public user logged_in = null;
        public string get_id()
        {
            throw new NotImplementedException();
        }

        public List<string> get_players()
        {
            throw new NotImplementedException();
        }

        public bool login(string name, string pass)
        {
            user u = new user(name, pass);
            logged_in = u;
            users.Add(u);
            MessageBox.Show(string.Format("{0} Bejelentkezett",name));
            return true;
        }

        public void logout()
        {
            throw new NotImplementedException();
        }
    }
    class user
    {
        string _name;
        string _passwd;
        int _win;
        int _loss;
        public user(string name, string passwd)
        {
            _name = name;
            _passwd = passwd;
            _win = 0;
            _loss = 0;
        }
        public string name
        {
            get { return _name; }
        }
        public int win
        {
            get { return _win; }
        }
        public int loss
        {
            get { return _loss; }
        }
    }
}
