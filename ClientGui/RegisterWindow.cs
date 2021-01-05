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
            stream = client.GetStream();
            this.client = client;
            this.permision = permision;
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            comunicator.SendMessage(stream, "2");
            if (textBoxName.Text.Length != 0 || textBoxPass.Text.Length != 0)
            {
                
                int permit = 1;
                if (checkBox1.Checked)
                {
                    permit = 0;
                }

                String credentials = textBoxName.Text + ";" + textBoxPass.Text + ";" + permit;
                comunicator.SendMessage(stream, credentials);
                var response = comunicator.ReadResponse(stream);
                if (!response.Equals("ACK"))
                {
                    responseLabel.ForeColor = Color.Red;
                    responseLabel.Text = response;
                }
                else
                {
                    responseLabel.ForeColor = Color.Green;
                    responseLabel.Text = "Successfully registered";
                }

            }
            else
            {
                String credentials = "a2z;b;1" ;
                comunicator.SendMessage(stream, credentials);
                responseLabel.ForeColor = Color.Red;
                responseLabel.Text = "Invalid Credentials";
            }
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
                InteractionWindow userWindow = new InteractionWindow(client, permision);
                userWindow.ShowDialog();
            }
            else
            {
                Hide();
                comunicator.SendMessage(stream, "BCK");
                LoginWindow loginWindow = new LoginWindow(client);
                loginWindow.ShowDialog();
            }
        }

    }
}
