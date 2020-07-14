using System;
using System.Threading;
using System.Windows.Forms;
using PubSubProject.Publisher;
using PubSubProject.Subscriber;
using PubSubProject.Broker;
using WebSocketSharp.Server;
using System.Net;
using System.Net.Sockets;

namespace PubSubProject {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			// get server ip
			IPAddress localIP;
			using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0)) {
				socket.Connect("8.8.8.8", 65530);
				var endpoint = socket.LocalEndPoint as IPEndPoint;
				localIP = endpoint.Address;
			}
			var port = "8008";
			var portNum = Convert.ToInt32(port);
			var ipAndPort = String.Format("{0}:{1}", localIP, portNum);

			// Create the broker, then 3 pubs and 2 subs
			new Thread(StartBrokerForm).Start(ipAndPort);
			Thread.Sleep(2000);
			new Thread(StartPublisherForm).Start(ipAndPort);
			new Thread(StartPublisherForm).Start(ipAndPort);
			new Thread(StartPublisherForm).Start(ipAndPort);
			new Thread(StartSubscriberForm).Start(ipAndPort);
			new Thread(StartSubscriberForm).Start(ipAndPort);
		}

		private static void StartBrokerForm( object ipAndPort ) {
			var brokerController = new BrokerController();
			var brokerGUI = new BrokerGUI(brokerController, (string)ipAndPort);
			brokerController.RegisterGUI(createGUIWrapper(brokerGUI));

			var wssv = new WebSocketServer(8008);
			wssv.AddWebSocketService("/BrokerController", () => {
				var server = new WebServer(createControllerWrapper(brokerController));
				brokerController.RegisterBoundary(server.BroadcastMessage);
				return server;
			});

			wssv.Start();
			Application.Run(brokerGUI);
		}

		private static BrokerGUIDelegateWrapper createGUIWrapper( BrokerGUI gui ) => new BrokerGUIDelegateWrapper() {
			updatePubs = gui.updatePublishers,
			updateSubs = gui.updateSubscribers,
			updatePubTopics = gui.updatePublisherTopics,
			updateSubTopics = gui.updateSubscriberTopics,
			delete = gui.deleteSubscriberTopic
		};

		private static BrokerControllerDelegateWrapper createControllerWrapper( BrokerController control ) => new BrokerControllerDelegateWrapper {
			newPub = control.newPublisherConnected,
			newSub = control.newSubscriberConnected,
			closed = control.connectionClosed,
			newPubTopic = control.newPublisherTopic,
			delPubTopic = control.deletePublisherTopic,
			unsubbed = control.subscriberUnsubscribedFromTopic,
			newConnect = control.newConnection,
			newPost = control.newPost,
			subbedToTopic = control.subscribedToTopic
		};

		private static void StartPublisherForm( object ipAndPort ) {
			var publisherController = new PublisherController((string)ipAndPort);
			var publisherGUI = new PublisherGUI(publisherController);
			Application.Run(publisherGUI);
		}

		private static void StartSubscriberForm( object ipAndPort ) {
			var subscriberController = new SubscriberController((string)ipAndPort);
			var subscriberGUI = new SubscriberGUI(subscriberController);
			subscriberController.setDelegates(subscriberGUI.newPost, subscriberGUI.refreshActiveTopicList, subscriberGUI.deletedTopic);
			Application.Run(subscriberGUI);
		}
	}
}
