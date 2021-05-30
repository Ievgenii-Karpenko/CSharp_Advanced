using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientChat1
{
    public partial class Form1 : Form
    {
        // private IServer server;

        public Form1()
        {
            //server = new Server(ip, port);
            //

            string ipAddress = string.Empty;
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipAddress = ip.ToString();
                }
            }

            InitializeComponent();

            
            ipTextBox.Text = ipAddress;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendToServer(input_textBox.Text);
            input_textBox.Clear();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            // Get IP from TextBox
            // Connect to server
        }

        private void SendToServer(string text)
        {
            //Create IMessage to send
            outputMessageBox.Text += text + "\n";
        }
    }
}
