using Newtonsoft.Json;

namespace PubSubProject
{
	public class Post
	{
		[JsonProperty]
		public string Topic { get; }	// These fields can be made properties, that way you can get rid of the getters. This is specific to C#

		[JsonProperty]
		public string Message { get; }

		[JsonProperty]
		public string DateCreated { get; }

		[JsonConstructor]
		public Post(string topic, string message, string dateAndTime)
		{
			Topic = topic;
			Message = message;
			DateCreated = dateAndTime;
		}
	}
}
