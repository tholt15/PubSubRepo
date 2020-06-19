using PubSubProject.Broker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
using Newtonsoft.Json;

namespace PubSubProject
{
    public delegate void BroadcastMessage(Message msg, List<string> subs);

    public class WebServer : WebSocketBehavior
    {
        // Broker Controller delegates
        private newSubscriberConnected _newSubscriber;
        private newPublisherConnected _newPublisher;
        private connectionClosed _connectionClosed;
        private newPublisherTopic _newPubTopic;
        private deletePublisherTopic _deletePubTopic;
        private subscriberUnsubscribedFromTopic _subUnsubbedFromTopic;
        private newConnection _newConnection;
        private newPost _newPost;
        private subscribedToTopic _subToTopic;

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
                          
        protected override void OnOpen()
        {
            _newConnection(ID);
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            Message message = JsonConvert.DeserializeObject<Message>(e.Data.ToString());
            routeMessage(message, ID);
        }

        private void routeMessage(Message message, string id)
        {
            string type = message.getType();

            if(type == "newPublisher")
            {
                _newPublisher(id);
            }
            else if(type == "newSubscriber")
            {
                _newSubscriber(id);
            }
            else if(type == "newTopic")
            {
                _newPubTopic(message.getTopicName(), id);
            }
            else if (type == "deleteTopic") {
                _deletePubTopic(message.getTopicName(), id);
            }
            else if (type == "newPost")
            {
                _newPost(message.getPost(), id);
            }
            else if (type == "unsubscribe")
            {
                _subUnsubbedFromTopic(message.getTopicName(), id);
            }
            else if (type == "subscribe")
            {
                _subToTopic(message.getTopicName(), id);
            }
        }

        protected override void OnClose(CloseEventArgs e)
        {
            _connectionClosed(ID);
        }

        public void BroadcastMessage(Message msg, List<string> subs)
        {
            foreach (string sub in subs)
            {
                Sessions.SendTo(JsonConvert.SerializeObject(msg), sub);
            }
        }
    }
}
