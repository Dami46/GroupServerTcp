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
        public InteractionWindow(TcpClient client)
        {
            InitializeComponent();
            stream = client.GetStream();
            this.client = client;
        }

        private void rankingButton_Click(object sender, EventArgs e)
        {
            Hide();
            RankingWindow rankingWindow = new RankingWindow();
            rankingWindow.ShowDialog();
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            Hide();
            ChangePasswordWindow changePassword = new ChangePasswordWindow();
            changePassword.ShowDialog();
        }

        //begin game
        private void beginButton_Click(object sender, EventArgs e)
        {
            Hide();
            GameWindow gameWindow = new GameWindow();
            gameWindow.ShowDialog();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            comunicator.SendMessage(stream, "DIS");
            Hide();
            LoginWindow loginWindow = new LoginWindow(client);
            loginWindow.ShowDialog();
        }
    }
}
