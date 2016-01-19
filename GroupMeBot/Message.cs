using System;

namespace GroupMeBot
{
	public class Message
	{
		public string bot_id;
		public string text;

		public Message (string id, string message)
		{
			bot_id = id;
			text = message;
		}
	}
}

