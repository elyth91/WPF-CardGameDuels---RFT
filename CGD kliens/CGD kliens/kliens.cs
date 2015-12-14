using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGD_interface;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows;

namespace CGD_kliens
{
    class kliens : MarshalByRefObject, Ikliens
    {
        public static Lobby l;
        static string id;
        Ikliens opponent = (Ikliens)Activator.GetObject(typeof(Ikliens), "tcp://localhost:8085/" + id);
        public void refresh_lobby()
        {
            l.refresh();
        }

        public bool game_require(string name, string id)
        {
            MessageBoxResult r = MessageBox.Show(name + " kihívott téged!\nElfogadod?", "Kihívás", MessageBoxButton.YesNo);
            if (r == MessageBoxResult.Yes)
            {
                kliens.id = id;
                //pályatér nyitás
                return true;
            }
            return false;
        }
    }
}
