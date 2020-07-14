using System;
using System.Collections.Generic;
using System.Linq;
using WebSocketSharp.Server;
using static PubSubProject.Message;

namespace PubSubProject.Broker {
	public delegate void newSubscriberConnected( string id );
	public delegate void newPublisherConnected( string id );
	public delegate void newPublisherTopic( string topicName, string id );
	public delegate void connectionClosed( string id );
	public delegate void deletePublisherTopic( string topicName, string id );
	public delegate void subscriberUnsubscribedFromTopic( string topicName, string id );
	public delegate void newConnection( string id );
	public delegate void newPost( Post post );
	public delegate void subscribedToTopic( string topicName, string id );

	public class BrokerController : WebSocketBehavior {
		// Web socket delegates
		private BroadcastMessage _broadcastMessage;

		// GUI delegates
		private updatePublishers _updatePublishers;
		private updateSubscribers _updateSubscribers;
		private updatePublisherTopics _updatePublisherTopics;
		private updateSubscriberTopics _updateSubscriberTopics;
		private deleteSubscriberTopic _deleteSubscriberTopic;

		// variables
		List<string> connectedIDs;
		List<Tuple<string, List<string>>> publishersAndTopics;
		List<Tuple<string, List<string>>> subscribersAndTopics;

		public BrokerController() {
			connectedIDs = new List<string>();
			publishersAndTopics = new List<Tuple<string, List<string>>>();
			subscribersAndTopics = new List<Tuple<string, List<string>>>();
		}

		public void RegisterBoundary( BroadcastMessage broadcast ) => _broadcastMessage = broadcast;

		public void RegisterGUI( BrokerGUIDelegateWrapper wrapper ) {
			_updatePublishers = wrapper.updatePubs;
			_updateSubscribers = wrapper.updateSubs;
			_updatePublisherTopics = wrapper.updatePubTopics;
			_updateSubscriberTopics = wrapper.updateSubTopics;
			_deleteSubscriberTopic = wrapper.delete;
		}

		public void newConnection( string id ) => connectedIDs.Add(id);

		public void newSubscriberConnected( string id ) {
			subscribersAndTopics.Add(new Tuple<string, List<string>>(id, new List<string>()));
			_updateSubscribers(id);
		}

		public void newPublisherConnected( string id ) {
			publishersAndTopics.Add(new Tuple<string, List<string>>(id, new List<string>()));
			_updatePublishers(id);
		}

		// LINQ can be very useful in methods like this where you're searching a list for something specific
		public void connectionClosed( string id ) {
			if (publishersAndTopics.Any(pair => pair.Item1 == id)) _updatePublishers(id);
			else _updateSubscribers(id);
		}

		public void newPublisherTopic( string topicName, string id ) {

			publishersAndTopics.ForEach(idTopicPair => {
				if (idTopicPair.Item1 == id) {
					idTopicPair.Item2.Add(topicName);
				}
			});
			_updatePublisherTopics(id);

			// Push topic list to subs and get all sub IDs
			var subs = subscribersAndTopics.Select(subAndTopics => subAndTopics.Item1).ToList();
			_broadcastMessage(new Message(MessageType.NewTopic, topicName), subs);

		}

		public void deletePublisherTopic( string topicName, string id ) {
			// Update topics for the publisher
			publishersAndTopics.ForEach(idTopicPair => {
				if (idTopicPair.Item1 == id) {
					idTopicPair.Item2.Remove(topicName);
				}
			});
			_updatePublisherTopics(id);

			//update subscribed topics for the subscriber
			subscribersAndTopics.ForEach(idTopicPair => {
				if (idTopicPair.Item2.Contains(topicName)) {
					idTopicPair.Item2.Remove(topicName);
				}
			});
			_deleteSubscriberTopic(topicName);

			// create message to pass on to subscribers and get all sub Ids
			var newMessage = new Message(MessageType.DeleteTopic, topicName);
			var subs = subscribersAndTopics.Select(subAndTopics => subAndTopics.Item1).ToList();
			
			_broadcastMessage(newMessage, subs);
		}

		public void subscriberUnsubscribedFromTopic( string topicName, string id ) {
			subscribersAndTopics.ForEach(idTopicPair => {
				if (idTopicPair.Item1 == id) {
					idTopicPair.Item2.Remove(topicName);
				}
			});
			_updateSubscriberTopics(id);
		}

		public void subscribedToTopic( string topicName, string id ) {
			subscribersAndTopics.ForEach(idTopicPair => {
				if (idTopicPair.Item1 == id) {
					idTopicPair.Item2.Add(topicName);
				}
			});
			_updateSubscriberTopics(id);
		}

		public void newPost( Post post ) {
			var newPostMessage = new Message(MessageType.NewPost, post);
			var subs = subscribersAndTopics.Where(idTopicPair => idTopicPair.Item2.Contains(post.Topic)).Select(idTopicPair => idTopicPair.Item1).ToList();
			_broadcastMessage(newPostMessage, subs);
		}

		public List<string> getPublisherTopicsByID( string id ) => publishersAndTopics.FirstOrDefault(idTopicPair => idTopicPair.Item1 == id)?.Item2 ?? new List<string>();

		public List<string> getSubscriberTopicsByID( string id ) => subscribersAndTopics.FirstOrDefault(idTopicPair => idTopicPair.Item1 == id)?.Item2 ?? new List<string>();

		public void closeClients() => _broadcastMessage(new Message(MessageType.ServerClosed), connectedIDs);
	}
}
