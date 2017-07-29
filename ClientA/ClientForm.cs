using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientA
{
    public partial class ClientForm : Form
    {
        ClientServerTCP _client;
        bool _isDbAvailable;
        public ClientForm(bool isDbAvailable)
        {
            _isDbAvailable = isDbAvailable;
            InitializeComponent();

        }

        /// <summary>
        /// Sets elements in the form enabled or not
        /// </summary>
        /// <param name="enabled">true to enabled false to not enabled</param>
        private void SetElementsEnabled(bool enabled)
        {
            textBoxMessage.Enabled = enabled;
            SendBtn.Enabled = enabled;
            labelConnecting.Visible = !enabled;
        }

        private void ClientForm_Shown(object sender, EventArgs e)
        {
            PrepareClient();
        }

        /// <summary>
        /// Connecting to Host
        /// </summary>
        private void PrepareClient()
        {
            _client = new ClientServerTCP();
            SetElementsEnabled(false);
            if (_client.Connect())
                SetElementsEnabled(true);
            else
            {
                MessageBox.Show("Failed to connect with host. \nTry running host first");
                this.Close();
            }
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            SendMessage();

        }

        /// <summary>
        /// Send message and insert into DB
        /// </summary>
        private void SendMessage()
        {
            string msg = textBoxMessage.Text.ToString();
            if (!(_client.SendMessage(msg)))
                MessageBox.Show("Can't send message");
            else
                if(_isDbAvailable)
                LiteDatabase.InsertMessage(msg);
            textBoxMessage.Clear();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageShowForm msg = new MessageShowForm();
            msg.Show();
        }
    }
}
