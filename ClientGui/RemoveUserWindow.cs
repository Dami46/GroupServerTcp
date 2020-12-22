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
            this.client = client;
            this.permision = permision;
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

        }
    }
}
