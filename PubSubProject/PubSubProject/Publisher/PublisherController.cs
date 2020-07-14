using WebSocketSharp;
using Newtonsoft.Json;
using static PubSubProject.Message;
using static PubSubProject.ControllerUtilities;

namespace PubSubProject.Publisher {
	public class PublisherController {
		private WebSocket webSocket;
		private bool serverClosed = false;

		public PublisherController( string ip ) {
			webSocket = new WebSocket("ws://" + ip + "/BrokerController");
			webSocket.OnMessage += ( sender, e ) => {
				if (JsonConvert.DeserializeObject<Message>(e.Data).Type == MessageType.ServerClosed) {
					serverClosed = true;
				}
			};

			webSocket.Connect();
			sendClientType();
		}

		private void sendClientType() => SendClientType(serverClosed, webSocket, MessageType.NewPublisher);

		public bool newTopic( string topicName ) {
			if (serverClosed == false) {
				webSocket.Send(JsonConvert.SerializeObject(new Message(MessageType.NewTopic, topicName)));
			}

			return !serverClosed;
		}

		public bool newPost( string topicName, string topicMessage, string dateTime ) {
			if (serverClosed == false) {
				var newPost = new Post(topicName, topicMessage, dateTime);
				var newMessage = new Message(MessageType.NewPost, newPost);
				webSocket.Send(JsonConvert.SerializeObject(newMessage));
			}

			return !serverClosed;
		}

		public bool deleteTopic( string topicName ) {
			if (serverClosed == false) {
				webSocket.Send(JsonConvert.SerializeObject(new Message(MessageType.DeleteTopic, topicName)));
			}

			return !serverClosed;
		}

		public bool closeConnection() => CloseConnection(serverClosed, webSocket);
	}
}
