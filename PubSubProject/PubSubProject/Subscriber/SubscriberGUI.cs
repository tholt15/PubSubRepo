using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PubSubProject.Subscriber
{

    public delegate void newPost(Post post);
    public delegate void refreshActiveTopicList(List<string> topics);
    public delegate void deletedTopic(string topic);

    public partial class SubscriberGUI : Form
    {
        private SubscriberController controller;

        public SubscriberGUI(SubscriberController controller)
        {
            InitializeComponent();
            this.controller = controller;
        }

        private void uxSubscribeButton_Click(object sender, EventArgs e)
        {
            if (uxActiveTopicsList.SelectedItem != null)
            {
                string topic = uxActiveTopicsList.SelectedItem.ToString();
                if (uxSubbedTopicsList.Items.Contains(topic))
                {
                    MessageBox.Show("Already subscribed to " + topic);
                }
                else
                {
                    bool messageSent = controller.subscribeToTopic(topic);
                    if (messageSent == true)
                    {
                        uxSubbedTopicsList.Items.Add(topic);
                    }
                    else
                    {
                        MessageBox.Show("Server is closed.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Select a topic from the active topics list.");
            }
        }

        private void uxUnsubscribeButton_Click(object sender, EventArgs e)
        {
            if (uxSubbedTopicsList.SelectedItem != null)
            {
                string topic = uxSubbedTopicsList.SelectedItem.ToString();
                bool messageSent = controller.unsubscribeFromTopic(topic);
                if (messageSent == true)
                {
                    uxSubbedTopicsList.Items.Remove(topic);
                }
                else
                {
                    MessageBox.Show("Server is closed.");
                }
            }
            else
            {
                MessageBox.Show("Select a topic from the list of subscribed topics.");
            }
        }

        public void newPost(Post post)
        {
            this.Invoke(new Action(() => {
                string topic = post.Topic;
                string message = post.Message;
                string time = post.DateCreated;
                int rowId = uxPostHistoryGrid.Rows.Add();
                DataGridViewRow row = uxPostHistoryGrid.Rows[rowId];
                row.Cells["topicNameColumn"].Value = topic;
                row.Cells["messageColumn"].Value = message;
                row.Cells["dateTimeColumn"].Value = time;
            }));
        }

        public void refreshActiveTopicList(List<string> topics)
        {
            this.Invoke(new Action(() => {
                uxActiveTopicsList.Items.Clear();
                foreach (string topic in topics)
                {
                    uxActiveTopicsList.Items.Add(topic);
                }
            }));
        }

        public void deletedTopic(string topic)
        {
            this.Invoke(new Action(() => {
                if (uxSubbedTopicsList.Items.Contains(topic))
                {
                    uxSubbedTopicsList.Items.Remove(topic);
                }
            }));
        }

        private void SubscriberGUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            bool messageSent = controller.closeConnection();
            if (messageSent == false) // this means the server is closed already
            {
                this.Hide();
            }
        }
    }
}
