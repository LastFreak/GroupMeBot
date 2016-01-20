using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace GroupMeBot
{
	public static class TeenagerBot : BotHelper
	{
		public static List<string> dirtywords = new List<string> ();
		public static void init()
		{
			string[] lines = File.ReadAllLines ("dirtywords.txt");
			TeenagerBot.dirtywords = new List<string> (); //Delete all existing words
			foreach (string line in lines) 
			{
				TeenagerBot.dirtywords.Add (line);
			}
		}

		public static void CheckMessage(string message)
		{
			message = message.ToLower ();
			var haha = dirtywords.Where (x => message.Contains(x.ToLower()));
			Console.WriteLine (message);
			foreach (string ha in haha) 
			{
				SendResponse ("Ha, er hat " + ha + " gesagt!");
			}
			responseString = "<HTML><BODY>Last message:" + message + "</BODY></HTML>";
		}
		public static void SayDirtyWords()
		{
			string msg = "";
			foreach (string word in dirtywords) 
			{
				msg += word + ", ";
			}
			SendResponse (msg);
		}
		public static void SaveDirtyWords()
		{
			using (StreamWriter writer = new StreamWriter ("dirtywords.txt", false)) 
			{
				foreach (string line in dirtywords) {
					writer.WriteLine (line);
				}
			}
		}

	}
}

