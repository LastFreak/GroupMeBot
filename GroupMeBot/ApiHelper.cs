using System;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace GroupMeBot
{
	public static class ApiHelper
	{
		public static bool Validator (object sender, X509Certificate certificate, X509Chain chain,
			SslPolicyErrors sslPolicyErrors)
		{
			return true;
		}


		public static void Post(string uri, string json)
		{
			ServicePointManager.ServerCertificateValidationCallback = Validator;
			var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.Method = "POST";
			using (var streamWriter = new StreamWriter (httpWebRequest.GetRequestStream ())) 
			{
				streamWriter.Write (json);
				streamWriter.Flush ();
				streamWriter.Close ();
			}
			var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse ();
			using (var streamReader = new StreamReader (httpResponse.GetResponseStream ())) {
				string result = streamReader.ReadToEnd ();
				Debug.WriteLine (result);
			}
		}


	}
}

