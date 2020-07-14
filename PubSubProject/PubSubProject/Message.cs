using Newtonsoft.Json;

namespace PubSubProject {
	public class Message {
		public enum MessageType {
			NewPublisher,
			NewSubscriber,
			NewTopic,
			DeleteTopic,
			NewPost,
			Unsubscribe,
			Subscribe,
			ServerClosed
		}

		// These fields can be made properties so that you can get rid of the getters and setters. This is something specific to C#

		/* 
		 * Strings are bad to switch on because it's very easy to accidentally spell something wrong. Better to use an enum so the compiler can make sure the type is always valid.
		 * The other otption, besides an enum, would be a static class (struct) with a few readonly properties that contain the strings you want to handle
		 */
		[JsonProperty]
		public MessageType Type { get; }

		[JsonProperty]
		public Post Post { get; }

		[JsonProperty]
		public string TopicName { get; set; }

		public Message( MessageType type ) {
			Type = type;
		}

		public Message( MessageType type, Post post ) {
			Type = type;
			Post = post;
		}

		public Message( MessageType type, string topicName ) {
			Type = type;
			TopicName = topicName;
		}

		[JsonConstructor]
		public Message( MessageType type, Post post, string topicName ) {
			Type = type;
			Post = post;
			TopicName = topicName;
		}
	}
}
