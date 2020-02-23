using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Text;
using System.Threading.Tasks;

namespace IpcLib
{
	public class IpcClient
	{
		public IpcClient()
		{
			var channel = new IpcClientChannel();
			ChannelServices.RegisterChannel(channel, ensureSecurity: true);

			Pid = Activator.GetObject(typeof(PIDInfo), $"ipc://{Constants.ChannelName}/{Constants.UriName}") as PIDInfo;
		}

		public object Pid { get; private set; }
	}
}
