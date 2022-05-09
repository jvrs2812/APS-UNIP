using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class MSG : Form
    {
        ConnectionService conect;
        public MSG(ConnectionService conect)
        {
            this.conect = conect;
            InitializeComponent();
        }

        private void MSG_Load(object sender, EventArgs e)
        {

        }
    

        private delegate void AtualizaLogCallBack(string strMensagem);

        private delegate void FechaConexaoCallBack(string strMotivo);

        private void EnviarMensagem(string message) {
            if (message.Length >= 1)
            {   
                conect.stwEnviador.WriteLine(message);
                conect.stwEnviador.Flush();
            }
        }

        private void AtualizaLog(string strMensagem)
        {
           memoConv.AppendText(strMensagem.Substring(strMensagem.IndexOf("|") + 1) + "\r\n");
            

        }

        public void RecebeMensagens()
        {
            
            conect.strReceptor = new StreamReader(conect.tcpServidor.GetStream());
            string ConResposta = conect.strReceptor.ReadLine();
            
            if (ConResposta[0] == '1')
            {
                
                this.Invoke(new AtualizaLogCallBack(this.AtualizaLog), new object[] { "Conectado com sucesso!" });
            }
            else 
            {
                string Motivo = "Não Conectado: ";
                
                Motivo += ConResposta.Substring(2, ConResposta.Length - 2);
                
                MessageBox.Show(Motivo);
                this.Close();
                this.Invoke(new FechaConexaoCallBack(conect.FechaConexao), new object[] { Motivo });
                // Sai do método
                return;
            }

            
            while (conect.Conectado)
            {
                
                this.Invoke(new AtualizaLogCallBack(this.AtualizaLog), new object[] { conect.strReceptor.ReadLine()});
            }
        }

        private void textMem_Click(object sender, EventArgs e)
        {
            EnviarMensagem(txtEnvio.Text);
            txtEnvio.Clear();
        }

        private void MSG_FormClosed(object sender, FormClosedEventArgs e)
        {
            conect.FechaConexao("Fechou");
        }


        private void txtEnvio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EnviarMensagem(txtEnvio.Text);
                txtEnvio.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
              
                string caminhoArquivo = "C:\\Users\\jvrs_\\Downloads\\";
                string nomeArquivo = "APS - Apresentação da Ferramenta - 2022.pdf";
                while (nomeArquivo.IndexOf("/") > -1)
                {
                    caminhoArquivo += nomeArquivo.Substring(0, nomeArquivo.IndexOf("/") + 1);
                    nomeArquivo = nomeArquivo.Substring(nomeArquivo.IndexOf("/") + 1);
                }
                byte[] nomeArquivoByte = Encoding.UTF8.GetBytes(nomeArquivo);
                if (nomeArquivoByte.Length > 5000 * 1024)
                {
                    MessageBox.Show("O tamanho do arquivo é maior que 5Mb, tente um arquivo menor.");
                    return;
                }
                string caminhoCompleto = caminhoArquivo + nomeArquivo;
                byte[] fileData = File.ReadAllBytes(caminhoCompleto);
                EnviarMensagem("2|"+ Encoding.Default.GetString(fileData));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
