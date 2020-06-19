using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PubSubProject
{
    public class Post
    {
        [JsonProperty]
        private string topic;

        [JsonProperty]
        private string message;

        [JsonProperty]
        private string dateCreated;

        [JsonConstructor]
        public Post(string topic, string message, string dateAndTime)
        {
            this.topic = topic;
            this.message = message;
            this.dateCreated = dateAndTime;
        }

        public string getTopic()
        {
            return topic;
        }

        public string getMessage()
        {
            return message;
        }

        public string getDateTime()
        {
            return dateCreated;
        }
    }
}
