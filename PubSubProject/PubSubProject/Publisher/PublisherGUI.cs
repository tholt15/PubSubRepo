using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PubSubProject.Publisher
{
    public partial class PublisherGUI : Form
    {
        private PublisherController controller;

        public PublisherGUI(PublisherController controller)
        {
            InitializeComponent();
            this.controller = controller;           
        }

        private void uxCreateTopicButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(uxTopicTextBox.Text))
            {
                string topic = uxTopicTextBox.Text;
                bool messageSent = controller.newTopic(topic);
                if (messageSent == true)
                {
                    uxTopicDropDown.Items.Add(topic);
                    uxTopicTextBox.Clear();
                }
                else
                {
                    MessageBox.Show("Server is closed.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid topic name.");
            }
        }

        private void uxDeleteTopic_Click(object sender, EventArgs e)
        {
            if (uxTopicDropDown.SelectedItem != null)
            {
                string topic = uxTopicDropDown.SelectedItem.ToString();
                bool messageSent = controller.deleteTopic(topic);
                if (messageSent == true)
                {
                    uxTopicDropDown.Items.Remove(topic);
                    uxTopicDropDown.Text = "";
                }
                else
                {
                    MessageBox.Show("Server is closed.");
                }
            }
            else
            {
                MessageBox.Show("Select a topic from the dropdown list.");
            }
        }

        private void uxPostMessageButton_Click(object sender, EventArgs e)
        {
            // Check which field is missing first, display appropriate message
            if (uxTopicDropDown.SelectedItem == null)
            {
                MessageBox.Show("Invalid Topic Selection");
            }
            else if (string.IsNullOrWhiteSpace(uxMessageBox.Text) || uxMessageBox.Text == "")
            {
                MessageBox.Show("Invalid Post Message");
            }
            else if (uxTopicDropDown.SelectedItem != null && uxMessageBox.Text != null)
            {
                string topic = uxTopicDropDown.SelectedItem.ToString();
                string message = uxMessageBox.Text;
                DateTime time = DateTime.Now;
                bool messageSent = controller.newPost(topic, message, time.ToString());
                if (messageSent == true)
                {
                    int rowId = uxPostHistoryGrid.Rows.Add();
                    DataGridViewRow row = uxPostHistoryGrid.Rows[rowId];
                    row.Cells["topicNameColumn"].Value = topic;
                    row.Cells["messageColumn"].Value = message;
                    row.Cells["dateTimeColumn"].Value = time.ToString();
                    uxMessageBox.Clear();
                }
                else
                {
                    MessageBox.Show("Server is closed.");
                }
            }
        }

        private void PublisherGUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            bool messageSent = controller.closeConnection();
            if (messageSent == false) // this means the server is closed already
            {
                this.Hide();
            }
        }
    }
}
