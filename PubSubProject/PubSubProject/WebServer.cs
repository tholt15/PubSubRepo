using PubSubProject.Broker;
using System.Collections.Generic;
using WebSocketSharp;
using WebSocketSharp.Server;
using Newtonsoft.Json;
using System;
using static PubSubProject.Message;	// Enums are a static type, so we can import them using the static import


namespace PubSubProject
{
	public delegate void BroadcastMessage(Message msg, List<string> subs);

	public class WebServer : WebSocketBehavior
	{
		// Broker Controller delegates
		private readonly newSubscriberConnected _newSubscriber;
		private readonly newPublisherConnected _newPublisher;
		private readonly connectionClosed _connectionClosed;
		private readonly newPublisherTopic _newPubTopic;
		private readonly deletePublisherTopic _deletePubTopic;
		private readonly subscriberUnsubscribedFromTopic _subUnsubbedFromTopic;
		private readonly newConnection _newConnection;
		private readonly newPost _newPost;
		private readonly subscribedToTopic _subToTopic;

		public WebServer(BrokerControllerDelegateWrapper wrapper)
		{
			_newSubscriber = wrapper.newSub;
			_newPublisher = wrapper.newPub;
			_connectionClosed = wrapper.closed;
			_newPubTopic = wrapper.newPubTopic;
			_deletePubTopic = wrapper.delPubTopic;
			_subUnsubbedFromTopic = wrapper.unsubbed;
			_newConnection = wrapper.newConnect;
			_newPost = wrapper.newPost;
			_subToTopic = wrapper.subbedToTopic;
		}

		// This method can be inlined
		protected override void OnOpen() => _newConnection(ID);

		// This method can be inlined
		protected override void OnMessage(MessageEventArgs e) => routeMessage(JsonConvert.DeserializeObject<Message>(e.Data.ToString()), ID);

		private void routeMessage(Message message, string id)
		{
			switch (message.Type) // This series of if-else statements can be made into a switch statement for better readability and cleaner code
			{
				case MessageType.NewPublisher:
					_newPublisher(id);
					break;
				case MessageType.NewSubscriber:
					_newSubscriber(id);
					break;
				case MessageType.NewTopic:
					_newPubTopic(message.TopicName, id);
					break;
				case MessageType.DeleteTopic:
					_deletePubTopic(message.TopicName, id);
					break;
				case MessageType.NewPost:
					_newPost(message.Post);
					break;
				case MessageType.Unsubscribe:
					_subUnsubbedFromTopic(message.TopicName, id);
					break;
				case MessageType.Subscribe:
					_subToTopic(message.TopicName, id);
					break;
				default:	// This should be added just in case an invalid type somehow gets into your code (the value of the enum is actually an int, so they could pass an int theoretically that you don't handle)
					throw new ArgumentException($"Invalid message type: {message.Type}");
			}
		}

		// This method can be inlined
		protected override void OnClose(CloseEventArgs e) => _connectionClosed(ID);

		// This method can be inlined using LINQ
		public void BroadcastMessage(Message msg, List<string> subs) => subs.ForEach(sub => Sessions.SendTo(JsonConvert.SerializeObject(msg), sub));

	}
}
