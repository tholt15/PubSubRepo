using System.Collections.Generic;
using WebSocketSharp;
using Newtonsoft.Json;
using static PubSubProject.Message;
using static PubSubProject.ControllerUtilities;

namespace PubSubProject.Subscriber {
	public class SubscriberController {
		// GUI delegates
		private newPost _newPost;
		private refreshActiveTopicList _refreshTopics;
		private deletedTopic _deleteTopic;

		private WebSocket webSocket;
		private bool serverClosed = false;
		private List<string> allTopics;
		private List<string> subscribedTopics;

		public SubscriberController( string ip ) {
			allTopics = new List<string>();
			subscribedTopics = new List<string>();

			webSocket = new WebSocket("ws://" + ip + "/BrokerController");

			webSocket.OnMessage += ( sender, e ) => {
				var message = JsonConvert.DeserializeObject<Message>(e.Data);
				switch (message.Type) {		// Switch statements are generally preferred over big if-else statements if the condition is just the value of a variable
					case MessageType.NewTopic:
						allTopics.Add(message.TopicName);
						_refreshTopics(allTopics);
						break;
					case MessageType.NewPost:
						_newPost(message.Post);
						break;
					case MessageType.DeleteTopic:
						allTopics.Remove(message.TopicName);
						_refreshTopics(allTopics);
						_deleteTopic(message.TopicName);
						break;
					case MessageType.ServerClosed:
						serverClosed = true;
						break;
				}
			};

			webSocket.Connect();
			sendClientType();
		}

		public void setDelegates( newPost postDelegate, refreshActiveTopicList refreshDelegate, deletedTopic delete ) {
			_newPost = postDelegate;
			_refreshTopics = refreshDelegate;
			_deleteTopic = delete;
		}

		public void sendClientType() => SendClientType(serverClosed, webSocket, MessageType.NewSubscriber);

		public bool unsubscribeFromTopic( string topic ) {
			if (serverClosed == false) {
				subscribedTopics.Remove(topic);
				webSocket.Send(JsonConvert.SerializeObject(new Message(MessageType.Unsubscribe, topic)));
			}

			return !serverClosed;
		}

		public bool subscribeToTopic( string topic ) {
			if (serverClosed == false) {
				subscribedTopics.Add(topic);
				webSocket.Send(JsonConvert.SerializeObject(new Message(MessageType.Subscribe, topic)));
			}

			return !serverClosed;
		}

		public bool closeConnection() => CloseConnection(serverClosed, webSocket);
	}
}
