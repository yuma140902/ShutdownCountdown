using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShutdownCountdown.Model
{
	public class ModelTime
	{
		public DateTime TimeToShutdown { get; private set; }

		public ModelTime(DateTime timeToShutdown) => this.TimeToShutdown = timeToShutdown;

		public TimeSpan TimeRemaining() => this.TimeToShutdown - DateTime.Now;

		public bool IsInWarningPhase() => this.TimeRemaining().TotalMinutes <= 5;

		public bool IsInShutdownPhase() => this.TimeRemaining().TotalSeconds <= 0;
	}
}
