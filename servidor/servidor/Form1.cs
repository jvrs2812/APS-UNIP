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

namespace servidor
{
    public partial class FServidor : Form
    {
        private delegate void AtualizaStatusCallback(string strMensagem);

        private ChatServidor conection;
        public FServidor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPAddress ip =  IPAddress.Parse(txtIpServidor.Text);

            if (txtPort.Text == "") {
                MessageBox.Show("Informe uma porta válida.");
                txtPort.Focus();
                return;
            }

            try
            {
                int porta = int.Parse(txtPort.Text);

                ChatServidor mainServidor = new ChatServidor(ip, porta);
                conection = mainServidor;

                // Vincula o tratamento de evento StatusChanged a mainServer_StatusChanged
                ChatServidor.StatusChanged += new StatusChangedEventHandler(mainServidor_StatusChanged);

                // Inicia o atendimento das conexões
                mainServidor.IniciaAtendimento();

                // Mostra que nos iniciamos o atendimento para conexões
                memoLog.AppendText("Monitorando as conexões...\r\n");

                btInicia.Enabled = false;
                txtPort.Enabled = false;
            }
            catch (Exception erro) { 
                MessageBox.Show("Erro de conexão : " + erro.Message);
            }

        }

        public void mainServidor_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            this.Invoke(new AtualizaStatusCallback(this.AtualizaStatus), new object[] { e.EventMessage });
        }
        private void AtualizaStatus(string strMensagem)
        {
            // Atualiza o logo com mensagens
            memoLog.AppendText(strMensagem + "\r\n");
            txtUsersConnect.Clear();
            foreach (string value in ChatServidor.htUsuarios.Keys) {
                txtUsersConnect.AppendText(value + "\r\n");
            }
        }

        private void FServidor_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
