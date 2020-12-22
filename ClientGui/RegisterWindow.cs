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
    public partial class RegisterWindow : Form
    {
        ClientComunicator comunicator = new ClientComunicator();
        TcpClient client;
        NetworkStream stream;
        int permision;
        public RegisterWindow(TcpClient client, int permision)
        {
            InitializeComponent();
            this.client = client;
            this.permision = permision;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (permision == 0)
            {
                Hide();
                InteractionAdminWindow adminWindow = new InteractionAdminWindow(client, permision);
                adminWindow.ShowDialog();
            }
            else
            {
                Hide();
                InteractionWindow userWindow = new InteractionWindow(client, permision);
                userWindow.ShowDialog();
            }
        }
    }
}
