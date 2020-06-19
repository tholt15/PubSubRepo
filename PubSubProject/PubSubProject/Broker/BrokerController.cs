using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
using PubSubProject;

namespace PubSubProject.Broker
{
    public delegate void newSubscriberConnected(string id);
    public delegate void newPublisherConnected(string id);
    public delegate void newPublisherTopic(string topicName, string id);
    public delegate void connectionClosed(string id);
    public delegate void deletePublisherTopic(string topicName, string id);
    public delegate void subscriberUnsubscribedFromTopic(string topicName, string id);
    public delegate void newConnection(string id);
    public delegate void newPost(Post post, string id);
    public delegate void subscribedToTopic(string topicName, string id);

    public class BrokerController : WebSocketBehavior
    {
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

        public BrokerController()
        {
            connectedIDs = new List<string>();
            publishersAndTopics = new List<Tuple<string, List<string>>>();
            subscribersAndTopics = new List<Tuple<string, List<string>>>();
        }

        public void RegisterBoundary(BroadcastMessage broadcast)
        {
            _broadcastMessage = broadcast;
        }
 
        public void RegisterGUI(BrokerGUIDelegateWrapper wrapper)
        {
            _updatePublishers = wrapper.updatePubs;
            _updateSubscribers = wrapper.updateSubs;
            _updatePublisherTopics = wrapper.updatePubTopics;
            _updateSubscriberTopics = wrapper.updateSubTopics;
            _deleteSubscriberTopic = wrapper.delete;
        }

        public void newConnection(string id)
        {
            connectedIDs.Add(id);
        }

        public void newSubscriberConnected(string id)
        {
            Tuple<string, List<string>> newSub = new Tuple<string, List<string>>(id, new List<string>());
            subscribersAndTopics.Add(newSub);
            _updateSubscribers(id);
            
        }

        public void newPublisherConnected(string id)
        {
            Tuple<string, List<string>> newPub = new Tuple<string, List<string>>(id, new List<string>());
            publishersAndTopics.Add(newPub);
            _updatePublishers(id);
        }

        public void connectionClosed(string id)
        {
            string type = "";
            foreach(Tuple<string, List<string>> idTopicPair in publishersAndTopics)
            {
                if(idTopicPair.Item1 == id)
                {
                    type = "pub";
                }
            }
            if (type == "pub")
            {
                _updatePublishers(id);
            }
            else 
            {
                _updateSubscribers(id);
            }
        }

        public void newPublisherTopic(string topicName, string id)
        {
            foreach(Tuple<string, List<string>> idTopicPair in publishersAndTopics)
            {
                if (idTopicPair.Item1 == id)
                {
                    idTopicPair.Item2.Add(topicName);
                }
            }
            _updatePublisherTopics(id);

            // Push topic list to subs
            Message newTopicMessage = new Message("newTopic", topicName);
            List<string> subs = new List<string>();
            // Get all sub Ids
            foreach(Tuple<string, List<string>> subAndTopics in subscribersAndTopics)
            {
                subs.Add(subAndTopics.Item1);
            }
            _broadcastMessage(newTopicMessage, subs);
            
        }
        
        public void deletePublisherTopic(string topicName, string id)
        {
            // Update topics for the publisher
            foreach (Tuple<string, List<string>> idTopicPair in publishersAndTopics)
            {
                if (idTopicPair.Item1 == id)
                {
                    idTopicPair.Item2.Remove(topicName);
                }
            }
            _updatePublisherTopics(id);

            //update subscribed topics for the subscriber
            foreach (Tuple<string, List<string>> idTopicPair in subscribersAndTopics)
            {
                if (idTopicPair.Item2.Contains(topicName))
                {
                    idTopicPair.Item2.Remove(topicName);
                }
            }
            _deleteSubscriberTopic(topicName);

            // create message to pass on to subscribers
            Message newTopicMessage = new Message("deleteTopic", topicName);
            List<string> subs = new List<string>();
            // Get all sub Ids
            foreach (Tuple<string, List<string>> subAndTopics in subscribersAndTopics)
            {
                subs.Add(subAndTopics.Item1);
            }
            _broadcastMessage(newTopicMessage, subs);
        }

        public void subscriberUnsubscribedFromTopic(string topicName, string id)
        {
            foreach(Tuple<string, List<string>> idTopicPair in subscribersAndTopics)
            {
                if (idTopicPair.Item1 == id)
                {
                    idTopicPair.Item2.Remove(topicName);
                }
            }
            _updateSubscriberTopics(id);
        }

        public void subscribedToTopic(string topicName, string id)
        {
            foreach(Tuple<string, List<string>> idTopicPair in subscribersAndTopics)
            {
                if (idTopicPair.Item1 == id)
                {
                    idTopicPair.Item2.Add(topicName);
                }
            }
            _updateSubscriberTopics(id);
        }

        public void newPost(Post post, string id)
        {
            string topic = post.getTopic();
            Message newPostMessage = new Message("newPost", post);
            List<string> subs = new List<string>();
            // Get all sub Ids
            foreach (Tuple<string, List<string>> idTopicPair in subscribersAndTopics)
            {
                if (idTopicPair.Item2.Contains(topic))
                {
                    subs.Add(idTopicPair.Item1);
                }
            }
            _broadcastMessage(newPostMessage, subs);
        }

        public List<string> getPublisherTopicsByID(string id)
        {
            foreach (Tuple<string, List<string>> idTopicPair in publishersAndTopics)
            {
                if (idTopicPair.Item1 == id) 
                {
                    return idTopicPair.Item2;
                }
            }
            return new List<string>();
        }

        public List<string> getSubscriberTopicsByID(string id)
        {
            foreach (Tuple<string, List<string>> idTopicPair in subscribersAndTopics)
            {
                if (idTopicPair.Item1 == id)
                {
                    return idTopicPair.Item2;
                }
            }
            return new List<string>();
        }

        public void closeClients()
        {
            Message closeMessage = new Message("serverClosed");
            _broadcastMessage(closeMessage, connectedIDs);
        }
    }
}
