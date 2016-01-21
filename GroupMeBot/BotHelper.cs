using System;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;

namespace GroupMeBot
{
	public class BotHelper
	{
		public static GroupMeBot.GroupMeMessage message;
		public static string responseString = "<HTML><BODY> Bot is online.</BODY></HTML>";
		public static string bot_id = "";

		public static void Listen()
		{
			HttpListener listener = new HttpListener ();
			listener.Prefixes.Add ("http://*:5000/");
			listener.Start ();
			Console.WriteLine ("Listening...");
			HttpListenerContext context = listener.GetContext ();
			HttpListenerRequest request = context.Request;
			Stream input = request.InputStream;
			var encoding = request.ContentEncoding;
			var reader = new StreamReader (input, encoding);
			string s = reader.ReadToEnd ();
			if (s != "") 
			{
				message = JsonConvert.DeserializeObject<GroupMeMessage> (s);
				if (!message.Name.Contains ("Bot")) 
				{
					Console.WriteLine (message.Name + ": " + message.Text);
					TeenagerBot.CheckMessage (message.Text);

					//Command Handling
					if(message.Text.First() == '!')
					{
						Commands.checkCommand (message.Text.Substring (1).Split (' '));;
					}
				}
			}
		

			Thread.Sleep (500);


			byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
			HttpListenerResponse response = context.Response;
			response.ContentLength64 = buffer.Length;
			System.IO.Stream output = response.OutputStream;
			output.Write(buffer,0,buffer.Length);
			output.Close();
			listener.Stop();
			Listen ();
		}

		public static void SendResponse(string text)
		{
			var uri = "https://api.groupme.com/v3/bots/post";
			if (bot_id == "") 
			{
				if (!File.Exists("config.txt"))
				{
					Console.WriteLine ("Bot Id:");
					using (StreamWriter writer = File.CreateText ("config.txt")) 
					{
						writer.WriteLine (Console.ReadLine ());
					}
				}
					bot_id = File.ReadAllLines ("config.txt") [0];
			}
			Message msg = new Message (bot_id, text);
			string json = JsonConvert.SerializeObject (msg);

			ApiHelper.Post (uri, json);
		}
	}
}

