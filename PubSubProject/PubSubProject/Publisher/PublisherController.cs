using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using Newtonsoft.Json;

namespace PubSubProject.Publisher
{
    public class PublisherController
    {
        private WebSocket webSocket;
        private bool serverClosed = false;

        public PublisherController(string ip)
        {
            webSocket = new WebSocket("ws://" + ip + "/BrokerController");
            webSocket.OnMessage += (sender, e) =>
            {
                Message message = JsonConvert.DeserializeObject<Message>(e.Data);
                string type = message.getType();
                if (type == "serverClosed")
                {
                    serverClosed = true;
                }
            };

            webSocket.Connect();
            sendClientType();
        }

        private void sendClientType()
        {
            if (serverClosed == false)
            {
                Message newMessage = new Message("newPublisher");
                webSocket.Send(JsonConvert.SerializeObject(newMessage));
            }
        }

        public bool newTopic(string topicName)
        {
            if (serverClosed == false)
            {
                Message newMessage = new Message("newTopic");
                newMessage.setTopicName(topicName);
                webSocket.Send(JsonConvert.SerializeObject(newMessage));
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool newPost(string topicName, string topicMessage, string dateTime)
        {
            if (serverClosed == false)
            {
                Post newPost = new Post(topicName, topicMessage, dateTime);
                Message newMessage = new Message("newPost", newPost);
                webSocket.Send(JsonConvert.SerializeObject(newMessage));
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool deleteTopic(string topicName)
        {
            if (serverClosed == false)
            {
                Message newMessage = new Message("deleteTopic", topicName);
                webSocket.Send(JsonConvert.SerializeObject(newMessage));
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
                webSocket.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
