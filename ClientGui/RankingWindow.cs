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
    public partial class RankingWindow : Form
    {
        ClientComunicator comunicator = new ClientComunicator();
        TcpClient client;
        NetworkStream stream;
        int permision;
        public RankingWindow(TcpClient client, int permision)
        {
            InitializeComponent();
            stream = client.GetStream();
            this.client = client;
            this.permision = permision;
           
            if (permision == 1)
            {
                comunicator.SendMessage(stream, "2");
            }
            else
            {
                comunicator.SendMessage(stream, "4");
            }
            var response2 = comunicator.ReadResponse(stream);
            rankingTextBox.Text = response2;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (permision == 0)
            {
                Hide();
                InteractionAdminWindow adminWindow = new InteractionAdminWindow(client, permision);
                adminWindow.ShowDialog();
            }
            else if (permision == 1)
            {
                Hide();
                InteractionWindow interaction = new InteractionWindow(client, permision);
                interaction.ShowDialog();
            }
            else
            {
                Hide();
                LoginWindow loginWindow = new LoginWindow(client);
                loginWindow.ShowDialog();
            }
        }
    }
}
