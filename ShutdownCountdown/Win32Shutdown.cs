using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShutdownCountdown
{
	static class Win32Shutdown
	{
		public static void Shutdown() => RunWin32Shutdown(Win32ShutdownFlag.Shutdown);

		public static void Logoff() => RunWin32Shutdown(Win32ShutdownFlag.Logoff);

		public static void Reboot() => RunWin32Shutdown(Win32ShutdownFlag.Reboot);

		private static void RunWin32Shutdown(Win32ShutdownFlag shutdownFlags)
		{
			// 参考:
			// WMIを利用してWindowsをログオフ、シャットダウン、再起動する[C#] | JOHOBASE
			// https://johobase.com/wmi-os-shutdown-csharp/

			var thread = new Thread(() =>
			{
				// Win32_OperatingSystemクラスを作成する
				using (var managementClass = new ManagementClass("Win32_OperatingSystem")) {
					// Win32_OperatingSystemオブジェクトを取得する
					managementClass.Get();
					// 権限を有効化する
					managementClass.Scope.Options.EnablePrivileges = true;

					var managementObjectCollection = managementClass.GetInstances();
					foreach (ManagementObject managementObject in managementObjectCollection) {
						managementObject.InvokeMethod("Win32Shutdown", new object[] { shutdownFlags, 0 });
						managementObject.Dispose();
					}
				}
			});

			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
			thread.Join();
		}


		private enum Win32ShutdownFlag
		{
			Logoff = 0,
			Shutdown = 1,
			Reboot = 2,
			PowerOff = 8,
			Forced = 4
		}
	}
}
