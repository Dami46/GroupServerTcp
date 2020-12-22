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
    public partial class LoginWindow : Form
    {
        TcpClient client;
        NetworkStream stream;
        public LoginWindow(TcpClient client)
        {
            InitializeComponent();
            stream = client.GetStream();
            this.client = client;
        }

        //register button
        private void registerButton_Click(object sender, EventArgs e)
        {
            Hide();
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.ShowDialog();
        }

        //login button
        private void loginButton_Click(object sender, EventArgs e)
        {
            ClientComunicator comunicator = new ClientComunicator();
            comunicator.SendMessage(stream, "1");

            if (textBoxName.Text.Length != 0 || textBoxPass.Text.Length != 0)
            {
                String credentials = textBoxName.Text + ";" + textBoxPass.Text;
                comunicator.SendMessage(stream, credentials);
                var response = comunicator.ReadResponse(stream);
                comunicator.SendMessage(stream, "NONE");
                if (response.Equals("DEC"))
                {
                    responseLabel.ForeColor = Color.Red;
                    responseLabel.Text = "Invalid Credentials";
                }
                else
                {
                    response = comunicator.ReadResponse(stream);
                    if (response.Equals("ADM"))
                    {
                        Hide();
                        InteractionAdminWindow adminWindow = new InteractionAdminWindow(client);
                        adminWindow.ShowDialog();
                    }
                    else
                    {
                        Hide();
                        InteractionWindow userWindow = new InteractionWindow(client);
                        userWindow.ShowDialog();
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
