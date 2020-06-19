using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using Newtonsoft.Json;

namespace PubSubProject.Subscriber
{
    public class SubscriberController
    {
        // GUI delegates
        private newPost _newPost;
        private refreshActiveTopicList _refreshTopics;
        private deletedTopic _deleteTopic;

        private WebSocket ws;
        private bool serverClosed = false;
        private List<string> allTopics;
        private List<string> subscribedTopics;

        public SubscriberController(string ip)
        {
            allTopics = new List<string>();
            subscribedTopics = new List<string>();

            ws = new WebSocket("ws://" + ip + "/BrokerController");

            ws.OnMessage += (sender, e) =>
            {
                Message message = JsonConvert.DeserializeObject<Message>(e.Data);
                string type = message.getType();
                if (type == "newTopic")
                {
                    allTopics.Add(message.getTopicName());
                    _refreshTopics(allTopics);
                }
                else if (type == "newPost")
                {
                    _newPost(message.getPost());
                }
                else if (type == "deleteTopic")
                {
                    allTopics.Remove(message.getTopicName());
                    _refreshTopics(allTopics);
                    _deleteTopic(message.getTopicName());
                }
                else if (type == "serverClosed")
                {
                    serverClosed = true;
                }
            };

            ws.Connect();
            sendClientType();
        }

        public void setDelegates(newPost postDelegate, refreshActiveTopicList refreshDelegate, deletedTopic delete)
        {
            _newPost = postDelegate;
            _refreshTopics = refreshDelegate;
            _deleteTopic = delete;
        }

        public void sendClientType()
        {
            if (serverClosed == false)
            {
                Message newMessage = new Message("newSubscriber");
                ws.Send(JsonConvert.SerializeObject(newMessage));
            }
        }

        public bool unsubscribeFromTopic(string topic)
        {
            if (serverClosed == false)
            {
                subscribedTopics.Remove(topic);
                Message newMessage = new Message("unsubscribe", topic);
                ws.Send(JsonConvert.SerializeObject(newMessage));
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool subscribeToTopic(string topic)
        {
            if (serverClosed == false)
            {
                subscribedTopics.Add(topic);
                Message newMessage = new Message("subscribe", topic);
                ws.Send(JsonConvert.SerializeObject(newMessage));
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool closeConnection()
        {
            // this if/else safely handles the closing of the form if the server has already been closed
            if (serverClosed == false)
            {
                ws.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
