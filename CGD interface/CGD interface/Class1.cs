using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CGD_interface
{
    [Serializable]
    public class player
    {
        public string l_name;
        public string passw;
    }

    public interface Iserver
    {
        void login(string name, string pass);
        List<player> get_logined();
    }
}
