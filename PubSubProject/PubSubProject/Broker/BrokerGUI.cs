using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using PubSubProject.Broker;


namespace PubSubProject
{
    public delegate void updatePublishers(string id);
    public delegate void updateSubscribers(string id);
    public delegate void updatePublisherTopics(string id);
    public delegate void updateSubscriberTopics(string id);
    public delegate void deleteSubscriberTopic(string topicName);

    public partial class BrokerGUI : Form
    {
        private BrokerController controller;

        public BrokerGUI(BrokerController controller, string ipAndPort)
        {
            InitializeComponent();
            this.controller = controller;
            this.Text = ipAndPort;
        }

        public void updatePublishers(string id)
        {
            this.Invoke(new Action(() => {
                if (uxPubs.Items.Contains(id))
                {
                    uxPubs.Items.Remove(id);
                    uxPubTopics.Items.Clear();
                }
                else
                {
                    uxPubs.Items.Add(id);
                }
            }));
        }

        public void updateSubscribers(string id)
        {
            this.Invoke(new Action(() => {
                if (uxSubs.Items.Contains(id))
                {
                    uxSubs.Items.Remove(id);
                    uxSubTopics.Items.Clear();
                }
                else
                {
                    uxSubs.Items.Add(id);
                }
            }));
        }

        public void updatePublisherTopics(string id)
        {
            this.Invoke(new Action(() => {
                if (uxPubs.SelectedItem != null)
                {
                    if (uxPubs.SelectedItem.ToString() == id)
                    {
                        uxPubTopics.Items.Clear();                    
                        List<string> topics = controller.getPublisherTopicsByID(id);
                        foreach (string topic in topics)
                        {
                            uxPubTopics.Items.Add(topic);
                        }
                    }
                }
            }));
        }

        public void updateSubscriberTopics(string id)
        {
            this.Invoke(new Action(() => {
                if (uxSubs.SelectedItem != null)
                {
                    if (uxSubs.SelectedItem.ToString() == id)
                    {
                        uxSubTopics.Items.Clear();
                        List<string> topics = controller.getSubscriberTopicsByID(id);
                        foreach (string topic in topics)
                        {
                            uxSubTopics.Items.Add(topic);
                        }
                    }
                }
            }));
        }

        public void deleteSubscriberTopic(string topicName)
        {
            this.Invoke(new Action(() =>
            {
                if (uxSubs.SelectedItem != null)
                {
                    if (uxSubTopics.Items.Contains(topicName))
                    {
                        uxSubTopics.Items.Remove(topicName);
                    }
                }
            }));
        }

        private void uxPubs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uxPubs.SelectedItem != null)
            {
                uxPubTopics.Items.Clear();
                string id = uxPubs.SelectedItem.ToString();
                List<string> topics = controller.getPublisherTopicsByID(id);
                foreach (string topic in topics)
                {
                    uxPubTopics.Items.Add(topic);
                }
            }
        }

        private void uxSubs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uxSubs.SelectedItem != null)
            {
                uxSubTopics.Items.Clear();
                string id = uxSubs.SelectedItem.ToString();
                List<string> topics = controller.getSubscriberTopicsByID(id);
                foreach (string topic in topics)
                {
                    uxSubTopics.Items.Add(topic);
                }
            }
        }

        private void BrokerGUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            controller.closeClients();
        }
    }
}
