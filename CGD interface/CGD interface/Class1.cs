using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CGD_interface
{
    public interface IPeldanyosit
    {
        string peldanytkeszit();
    }
    public interface Iserver
    {
        bool login(string name, string pass);
        void logout();
        List<string> get_players();
        string get_id();
    }
    
}
