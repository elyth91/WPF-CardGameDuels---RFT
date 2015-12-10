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
        bool login(string name, string pass, string id);
        void logout();
        List<string> get_players();
        string get_id(string name);
    }
    public interface Ikliens
    {
        void refresh_lobby();
        void game_require();
    }
}
