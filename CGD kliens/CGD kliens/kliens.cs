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
        public void game_require()
        {
            throw new NotImplementedException();
        }

        public void refresh_lobby()
        {
            l.refresh();
        }
    }
}
