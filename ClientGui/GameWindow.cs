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
    public partial class GameWindow : Form
    {
        ClientComunicator comunicator = new ClientComunicator();
        TcpClient client;
        NetworkStream stream;
        int permision;
        public GameWindow(TcpClient client, int permision)
        {
            InitializeComponent();
            stream = client.GetStream();
            this.client = client;
            comunicator.SendMessage(stream,"1");
            this.permision = permision;
        }


        private void sendButton_Click(object sender, EventArgs e)
        {
            comunicator.SendMessage(stream, textBox1.Text);
            var response = comunicator.ReadResponse(stream);
            gameStatus.Text = response;

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            comunicator.SendMessage(stream, "10001");
            if (permision == 0)
            {
                Hide();
                InteractionAdminWindow adminWindow = new InteractionAdminWindow(client, 0);
                adminWindow.ShowDialog();
            }
            else
            {
                Hide();
                InteractionWindow userWindow = new InteractionWindow(client, 1);
                userWindow.ShowDialog();
            }
        }

    }
}
