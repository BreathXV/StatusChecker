using System;
using System.Net.NetworkInformation;

namespace StatusChecker
{
	class StatusGetter
	{
		public bool GetStatus(string IP)
		{
			if (IP != null)
			{
				Ping ping = new Ping();
				PingReply = pingSender.Send(IP);
				if (reply.Status == IPStatus.Success)
				{
					return true;
				}
				else if (reply.Status == IPStatus.TimedOut)
				{
					return false;
				}
				else { return false; }
			}
			else if (string.IsNullOrEmpty(IP))
			{
				return false;
			}
		}
		
		public 
	}
}
