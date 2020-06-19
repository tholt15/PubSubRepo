using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubProject
{
    public class Message
    {
        [JsonProperty]
        public string type;

        [JsonProperty]
        public Post post;

        [JsonProperty]
        public string topicName;

        public Message(string type)
        {
            this.type = type;
        }

        public Message(string type, Post post)
        {
            this.type = type;
            this.post = post;
        }

        public Message(string type, string topicName)
        {
            this.type = type;
            this.topicName = topicName;
        }

        [JsonConstructor]
        public Message(string type, Post post, string topicName)
        {
            this.type = type;
            this.post = post;
            this.topicName = topicName;
        }

        public Post getPost()
        {
            return post;
        }

        public string getType()
        {
            return type;
        }

        public void setTopicName(string name)
        {
            topicName = name;
        }

        public string getTopicName()
        {
            return topicName;
        }
    }
}
