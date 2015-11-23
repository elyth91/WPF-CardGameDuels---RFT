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
    class peldanyosito : IPeldanyosit
    {
        string peldanytkeszit()
        {
            string id = Guid.NewGuid().ToString();
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(server), id, WellKnownObjectMode.Singleton);
            return id;
        }
    }
    class server
    {

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
