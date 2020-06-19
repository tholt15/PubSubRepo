using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubProject.Broker
{
    public class BrokerGUIDelegateWrapper
    {
        public updatePublishers updatePubs { get; set; }
        public updateSubscribers updateSubs { get; set; }
        public updatePublisherTopics updatePubTopics { get; set; }
        public updateSubscriberTopics updateSubTopics { get; set; }
        public deleteSubscriberTopic delete { get; set; }
    }
}
