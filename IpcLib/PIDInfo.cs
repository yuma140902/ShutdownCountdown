using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpcLib
{
	public class PIDInfo : MarshalByRefObject
	{
		public PIDInfo(int parentPID)
		{
			this.ParentPID = parentPID;
		}

		public int ParentPID { get; private set; }
	}
}
