using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectionService conection = new ConnectionService();
            try
            {
                if (!conection.Conectado)
                {
                    conection.NomeUsuario = txtNome.Text;
                    conection.enderecoIP = IPAddress.Parse(txtServidor.Text);
                    conection.porta = int.Parse(txtPorta.Text);
                    conection.tcpServidor = new TcpClient();
                    MSG msg = new MSG(conection);
                    this.Hide();
                    conection.IniciaConexao(msg);
                    if (conection.Conectado)
                    {
                        msg.Show();
                    }
                }
            }
            catch (Exception error) {
                MessageBox.Show($"Erro ao conectar ao servidor {error.Message}");
                this.Show();
            }

        }

        private void Form1_Activated(object sender, EventArgs e)
        {

        }
    }
}
