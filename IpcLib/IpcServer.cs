using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace IpcLib
{
	public class IpcServer
	{
		public IpcServer(int pid)
		{
			var channel = new IpcServerChannel(Constants.ChannelName);
			ChannelServices.RegisterChannel(channel, ensureSecurity: true);

			Pid = new PIDInfo(pid);
			RemotingServices.Marshal(Pid, Constants.UriName, typeof(PIDInfo));
		}

		public PIDInfo Pid { get; private set; }
	}
}
