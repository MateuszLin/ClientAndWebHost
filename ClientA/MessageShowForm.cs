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
    public partial class MessageShowForm : Form
    {
        public MessageShowForm()
        {
            InitializeComponent();
            GetMessageToList();
            messagesListView.AutoResizeColumns(new ColumnHeaderAutoResizeStyle());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetMessageToList()
        {
            foreach (var item in LiteDatabase.GetMessages())
            {
                string[] row = { item.message, item.date };
                ListViewItem lvi = new ListViewItem(row);
                messagesListView.Items.Add(lvi);
            }
        }
    }
}
