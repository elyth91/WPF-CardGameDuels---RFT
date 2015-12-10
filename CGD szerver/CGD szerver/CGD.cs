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
        public static List<user> users = new List<user>();
        static List<user> logined = new List<user>();
        public user logged_in = null;
        

        public List<string> get_players()
        {
            List<string> ret = new List<string>();
            foreach (user item in logined)
            {
                ret.Add(item.name);
            }
            return ret;
        }
        user find_user(string name)
        {
            user u = null;
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].name==name)
                {
                    u = users[i];
                }
            }
            return u;
        }
        public bool login(string name, string pass, string id)
        {
            user u = find_user(name);
            if (u == null)
            {
                u = new user(name, pass);
                users.Add(u);
            }
            else
            {
                if (!u.valid_password(pass)) return false;
            }
            u.id = id;
            logined.Add(u);
            logged_in = u;

            return true;
            
        }

        public void logout()
        {
            logined.Remove(logged_in);
            logged_in = null;
        }

        public string get_id(string name)
        {
            int i = 0;
            while(logined[i].name != name)
            {
                i++;
            }
            return logined[i].id;
        }
    }
    class user
    {
        string _name;
        string _passwd;
        int _win;
        int _loss;
        public string id;
        public user(string name, string passwd)
        {
            _name = name;
            _passwd = passwd;
            _win = 0;
            _loss = 0;
        }
        public bool valid_password(string pass)
        {
            if (_passwd == pass) return true;
            else return false;
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
