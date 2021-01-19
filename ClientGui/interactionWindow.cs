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
    public partial class InteractionWindow : Form
    {
        TcpClient client;
        NetworkStream stream;
        ClientComunicator comunicator = new ClientComunicator();
        int permision;
        public InteractionWindow(TcpClient client, int permision)
        {
            InitializeComponent();
            stream = client.GetStream();
            this.client = client;
            this.permision = permision;
        }

        private void rankingButton_Click(object sender, EventArgs e)
        {
            Hide();
            RankingWindow rankingWindow = new RankingWindow(client, permision);
            rankingWindow.ShowDialog();
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            Hide();
            ChangePasswordWindow changePassword = new ChangePasswordWindow(client,permision);
            changePassword.ShowDialog();
        }

        //begin game
        private void beginButton_Click(object sender, EventArgs e)
        {
            Hide();
            GameWindow gameWindow = new GameWindow(client, permision);
            gameWindow.ShowDialog();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            comunicator.SendMessage(stream, "4");
            Hide();
            LoginWindow loginWindow = new LoginWindow(client);
            loginWindow.ShowDialog();
        }
    }
}
