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
        private WebSocket ws;
        private bool serverClosed = false;

        public PublisherController(string ip)
        {
            ws = new WebSocket("ws://" + ip + "/BrokerController");
            ws.OnMessage += (sender, e) =>
            {
                Message message = JsonConvert.DeserializeObject<Message>(e.Data);
                string type = message.getType();
                if (type == "serverClosed")
                {
                    serverClosed = true;
                }
            };

            ws.Connect();
            sendClientType();
        }

        private void sendClientType()
        {
            if (serverClosed == false)
            {
                Message newMessage = new Message("newPublisher");
                ws.Send(JsonConvert.SerializeObject(newMessage));
            }
        }

        public bool newTopic(string topicName)
        {
            if (serverClosed == false)
            {
                Message newMessage = new Message("newTopic");
                newMessage.setTopicName(topicName);
                ws.Send(JsonConvert.SerializeObject(newMessage));
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
                ws.Send(JsonConvert.SerializeObject(newMessage));
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
