using Newtonsoft.Json;
using WebSocketSharp;
using static PubSubProject.Message;

namespace PubSubProject {
	public static class ControllerUtilities {

		public static void SendClientType(bool serverClosed, WebSocket webSocket, MessageType type) {
			if (serverClosed == false) {
				webSocket.Send(JsonConvert.SerializeObject(new Message(type)));
			}
		}

		public static bool CloseConnection(bool serverClosed, WebSocket webSocket) {
			// this if/else safely handles the closing of the form if the server has already been closed
			if (serverClosed == false) {
				webSocket.Close();
			}

			return !serverClosed;
		}
	}
}
