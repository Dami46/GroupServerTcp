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

namespace ClientGui
{
    public partial class ChangePasswordWindow : Form
    {
        TcpClient client;
        NetworkStream stream;
        int permision;
        public ChangePasswordWindow(TcpClient client, int permision)
        {
            InitializeComponent();
            stream = client.GetStream();
            this.client = client;
            this.permision = permision;
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Hide();
            InteractionWindow interactionWindow = new InteractionWindow(client, permision);
            interactionWindow.ShowDialog();
        }
    }
}
