﻿using System;
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
    class kliens
    {
        public static void log_in(string name, string pass)
        {
            Iserver s = (Iserver)Activator.GetObject(
                typeof(Iserver),
                   "tcp://localhost:8085/CGD"
                );
            if (s == null) MessageBox.Show("nem sikerült!!");
            else
            {
                
            }
        }
    }
}
