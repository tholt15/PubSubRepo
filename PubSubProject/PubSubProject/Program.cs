using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PubSubProject.Publisher;
using PubSubProject.Subscriber;
using PubSubProject.Broker;
using WebSocketSharp;
using WebSocketSharp.Server;
using System.Net;
using System.Net.Sockets;

namespace PubSubProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // get server ip
            IPAddress localIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endpoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endpoint.Address;
            }
            string port = "8008";
            int portNum = Convert.ToInt32(port);
            string ipAndPort = String.Format("{0}:{1}", localIP, portNum);

            // Create the broker, then 3 pubs and 2 subs
            new Thread(StartBrokerForm).Start(ipAndPort);
            Thread.Sleep(2000);
            new Thread(StartPublisherForm).Start(ipAndPort);
            new Thread(StartPublisherForm).Start(ipAndPort);
            new Thread(StartPublisherForm).Start(ipAndPort);
            new Thread(StartSubscriberForm).Start(ipAndPort);
            new Thread(StartSubscriberForm).Start(ipAndPort);        
        }

        private static void StartBrokerForm(object ipAndPort)
        {
            BrokerController brokerController = new BrokerController();
            BrokerGUI brokerGUI = new BrokerGUI(brokerController, (string)ipAndPort);
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

        private static BrokerGUIDelegateWrapper createGUIWrapper(BrokerGUI gui)
        {
            BrokerGUIDelegateWrapper wrapper = new BrokerGUIDelegateWrapper();
            wrapper.updatePubs = gui.updatePublishers;
            wrapper.updateSubs = gui.updateSubscribers;
            wrapper.updatePubTopics = gui.updatePublisherTopics;
            wrapper.updateSubTopics = gui.updateSubscriberTopics;
            wrapper.delete = gui.deleteSubscriberTopic;
            return wrapper;
        }
        
        private static BrokerControllerDelegateWrapper createControllerWrapper(BrokerController control)
        {
            BrokerControllerDelegateWrapper wrapper = new BrokerControllerDelegateWrapper();
            wrapper.newPub = control.newPublisherConnected;
            wrapper.newSub = control.newSubscriberConnected;
            wrapper.closed = control.connectionClosed;
            wrapper.newPubTopic = control.newPublisherTopic;
            wrapper.delPubTopic = control.deletePublisherTopic;
            wrapper.unsubbed = control.subscriberUnsubscribedFromTopic;
            wrapper.newConnect = control.newConnection;
            wrapper.newPost = control.newPost;
            wrapper.subbedToTopic = control.subscribedToTopic;
            return wrapper;
        }
        
        private static void StartPublisherForm(object ipAndPort)
        {
            PublisherController publisherController = new PublisherController((string)ipAndPort);
            PublisherGUI publisherGUI = new PublisherGUI(publisherController);
            Application.Run(publisherGUI);
        }

        private static void StartSubscriberForm(object ipAndPort)
        {
            SubscriberController subscriberController = new SubscriberController((string)ipAndPort);
            SubscriberGUI subscriberGUI = new SubscriberGUI(subscriberController);
            subscriberController.setDelegates(subscriberGUI.newPost, subscriberGUI.refreshActiveTopicList, subscriberGUI.deletedTopic);
            Application.Run(subscriberGUI);
        }
    }
}
