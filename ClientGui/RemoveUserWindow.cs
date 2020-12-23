using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TcpServerLibrary;

namespace ClientGui
{
    public partial class RemoveUserWindow : Form
    {
        ClientComunicator comunicator = new ClientComunicator();
        TcpClient client;
        NetworkStream stream;
        int permision;
        public RemoveUserWindow(TcpClient client, int permision)
        {
            InitializeComponent();
            stream = client.GetStream();
            this.client = client;
            this.permision = permision;
            comunicator.SendMessage(stream, "3");
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Hide();
            InteractionAdminWindow adminWindow = new InteractionAdminWindow(client, 0);
            adminWindow.ShowDialog();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            String login = textBoxName.Text;
            comunicator.SendMessage(stream, login);

            var respone = comunicator.ReadResponse(stream);
            if (!respone.Equals("ACK"))
            {
                responseLabel.ForeColor = Color.Red;
                responseLabel.Text = respone;
            }
            else
            {
                responseLabel.ForeColor = Color.Green;
                responseLabel.Text = "Successfully deleted";
            }
            
        }
    }
}
