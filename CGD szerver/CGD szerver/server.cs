using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace CGD_szerver
{
    class server
    {
        public static void start()
        {
            TcpChannel chan = new TcpChannel(8085);
            ChannelServices.RegisterChannel(chan, false);
            RemotingConfiguration.RegisterWellKnownServiceType(
                 typeof(CGD),
                 "CGDszerver",
                WellKnownObjectMode.SingleCall
             );
        }
    }
}
