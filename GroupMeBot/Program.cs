using System;
using System.Net;
using System.Web;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Threading;
using System.Collections.Generic;

namespace GroupMeBot
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			TeenagerBot.init ();
			TeenagerBot.Listen ();
		}

}
}
