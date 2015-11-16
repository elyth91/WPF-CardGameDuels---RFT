using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using CGD_interface;

namespace CGD_szerver
{
    public class CGD : MarshalByRefObject, Iserver
    {
        public void login(string name, string pass)
        {
            logined.Add(new player(name, pass));
        }
        public List<player> get_logined()
        {
            return logined;
        }
        public CGD()
        {
            logined = new List<player>();
        }
        List<player> logined;
    }
    class player
    {
        public string l_name;
        public string passw;
        public player(string name, string pass)
        {
            l_name = name;
            passw = pass;
        }
    }
}
