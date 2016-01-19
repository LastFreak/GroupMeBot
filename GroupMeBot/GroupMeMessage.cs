using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GroupMeBot
{
	public class GroupMeMessage
	{
				

					[JsonProperty("attachments")]
					public object[] Attachments { get; set; }

					[JsonProperty("avatar_url")]
					public string AvatarUrl { get; set; }

					[JsonProperty("created_at")]
					public int CreatedAt { get; set; }

					[JsonProperty("group_id")]
					public string GroupId { get; set; }

					[JsonProperty("id")]
					public string Id { get; set; }

					[JsonProperty("name")]
					public string Name { get; set; }

					[JsonProperty("sender_id")]
					public string SenderId { get; set; }

					[JsonProperty("sender_type")]
					public string SenderType { get; set; }

					[JsonProperty("source_guid")]
					public string SourceGuid { get; set; }

					[JsonProperty("system")]
					public bool System { get; set; }

					[JsonProperty("text")]
					public string Text { get; set; }

					[JsonProperty("user_id")]
					public string UserId { get; set; }

			}
		
	
}

