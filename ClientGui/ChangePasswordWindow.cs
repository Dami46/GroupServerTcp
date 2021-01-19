using ServerLibrary;
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

        private void backButton_Click(object sender, EventArgs e)
        {
            Hide();
            InteractionWindow interactionWindow = new InteractionWindow(client, permision);
            interactionWindow.ShowDialog();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            ClientComunicator comunicator = new ClientComunicator();
            comunicator.SendMessage(stream, "3");

            if (textBoxName.Text.Length != 0 || textBoxPass.Text.Length != 0 || newPasswordBox.Text.Length != 0)
            {
                String credentials = textBoxName.Text + ";" + textBoxPass.Text;
                comunicator.SendMessage(stream, credentials);
                var response = comunicator.ReadResponse(stream);
                if (response.Equals("DEC"))
                {
                    responseLabel.ForeColor = Color.Red;
                    responseLabel.Text = "Invalid Credentials";
                }
                else
                {
               
                    credentials = newPasswordBox.Text;
                    comunicator.SendMessage(stream, credentials);

                    response = comunicator.ReadResponse(stream);
                    if(response == "BAD")
                    {
                        responseLabel.ForeColor = Color.Red;
                        responseLabel.Text = "Bad new password";
                    }
                    else
                    {

                    }

                }

            }
            else
            {
                responseLabel.ForeColor = Color.Red;
                responseLabel.Text = "Invalid Credentials";
            }
        }

    }
}
