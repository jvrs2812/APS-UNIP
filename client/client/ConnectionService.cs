using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public class ConnectionService
    {
        public string NomeUsuario = "Desconhecido";

        public int porta = 0;

        public StreamWriter stwEnviador;

        public StreamReader strReceptor;

        public TcpClient tcpServidor;

        public Thread mensagemThread;

        public IPAddress enderecoIP;

        public bool Conectado;

        public static string nomeAbreviadoArquivo = "";

   


        public void IniciaConexao(MSG msg) {
            try
            {
                tcpServidor.Connect(enderecoIP, porta);

                // verifica se Cliente/Servidor estão conectados
                Conectado = true;
                // Envia o nome do usuário ao servidor para que as mensagens sejam identificadas. 
                stwEnviador = new StreamWriter(tcpServidor.GetStream());
                stwEnviador.WriteLine(NomeUsuario);
                stwEnviador.Flush();

                //Inicia a thread para receber mensagens e uma nova comunicação
                mensagemThread = new Thread(new ThreadStart(msg.RecebeMensagens));
                mensagemThread.Start();
            }
            catch (Exception err) {
                Conectado = false;
                MessageBox.Show(err.Message);
                msg.Close();
            }
            

        }

        public void FechaConexao(string motivo)
        {
            if (Conectado) {
                Conectado = false;
                stwEnviador.Close();
                strReceptor.Close();
                tcpServidor.Close();
            }
        }

    }
}
