using System;

namespace GroupMeBot
{
	public static class Commands
	{
		public static void checkCommand(string[] command)
		{
			switch (command[0]) 
			{
			case "dirtywords":
				if (command.Length == 1) 
				{
					TeenagerBot.SayDirtyWords ();
				}
				else
					if(command[1] == "add" && command.Length == 3)
					{
						TeenagerBot.dirtywords.Add (command [2]);
						TeenagerBot.SaveDirtyWords ();
						TeenagerBot.init ();

					}
				
				break;
			default:
				
				break;
			}
		}
	}
}

