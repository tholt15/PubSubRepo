using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PubSubProject.Broker;

namespace PubSubProject
{
    public class BrokerControllerDelegateWrapper
    {
        public newSubscriberConnected newSub { get; set; }
        public newPublisherConnected newPub { get; set; }
        public connectionClosed closed { get; set; }
        public newPublisherTopic newPubTopic { get; set; }
        public deletePublisherTopic delPubTopic { get; set; }
        public subscriberUnsubscribedFromTopic unsubbed { get; set; }
        public newConnection newConnect { get; set; }
        public newPost newPost { get; set; }
        public subscribedToTopic subbedToTopic { get; set; }

        public BrokerControllerDelegateWrapper()
        {

        }
    }
}
