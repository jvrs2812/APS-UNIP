using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace servidor
{
    public class StatusChangedEventArgs : EventArgs
    {
        private string EventMsg;

        public string EventMessage
        {
            get { return EventMsg; }
            set { EventMsg = value; }
        }

        
        public StatusChangedEventArgs(string strEventMsg)
        {
            EventMsg = strEventMsg;
        }
    }

    // Este delegate é necessário para especificar os parametros que estamos pasando com o nosso evento
    public delegate void StatusChangedEventHandler(object sender, StatusChangedEventArgs e);

    class ChatServidor
    {
        public static Hashtable htUsuarios = new Hashtable(30); 
       
        public static Hashtable htConexoes = new Hashtable(30); 
        
        private IPAddress enderecoIP;
        private int Nporta;
        public TcpClient tcpCliente;

        public static event StatusChangedEventHandler StatusChanged;
        private static StatusChangedEventArgs e;

        
        public ChatServidor(IPAddress endereco, int porta)
        {
            enderecoIP = endereco;
            Nporta = porta;
        }

    
        private Thread thrListener;

        private TcpListener tlsCliente;

        bool ServRodando = false;

        public static void IncluiUsuario(TcpClient tcpUsuario, string strUsername)
        {
         
            ChatServidor.htUsuarios.Add(strUsername, tcpUsuario);
            ChatServidor.htConexoes.Add(tcpUsuario, strUsername);

            EnviaMensagemAdmin("1|"+htConexoes[tcpUsuario] + " entrou..");
        }

        public static void RemoveUsuario(TcpClient tcpUsuario)
        {
            // Se o usuário existir
            if (htConexoes[tcpUsuario] != null)
            {
                String user = ChatServidor.htConexoes[tcpUsuario].ToString();
                ChatServidor.htUsuarios.Remove(ChatServidor.htConexoes[tcpUsuario]);
                ChatServidor.htConexoes.Remove(tcpUsuario);

                EnviaMensagemAdmin("1|" + user + " saiu...");

            }
        }

        public static void OnStatusChanged(StatusChangedEventArgs e)
        {
            StatusChangedEventHandler statusHandler = StatusChanged;
            if (statusHandler != null)
            {
                statusHandler(null, e);
            }
        }

        // Envia mensagens administratias
        public static void EnviaMensagemAdmin(string Mensagem)
        {
            StreamWriter swSenderSender;

            e = new StatusChangedEventArgs(Mensagem);
            OnStatusChanged(e);

          
            TcpClient[] tcpClientes = new TcpClient[ChatServidor.htUsuarios.Count];
            
            ChatServidor.htUsuarios.Values.CopyTo(tcpClientes, 0);
            
            for (int i = 0; i < tcpClientes.Length; i++)
            {
                
                try
                {
                   
                    if (Mensagem.Trim() == "" || tcpClientes[i] == null)
                    {
                        continue;
                    }
               
                    swSenderSender = new StreamWriter(tcpClientes[i].GetStream());
                    swSenderSender.WriteLine(Mensagem);
                    swSenderSender.Flush();
                    swSenderSender = null;
                }
                catch
                {
                    RemoveUsuario(tcpClientes[i]);
                }
            }
        }

        public static void EnviaArquivo(string Origem, string arquivo) {
            StreamWriter swSenderSender;

            e = new StatusChangedEventArgs(Origem + ": Está enviando um arquivo");
            OnStatusChanged(e);

            TcpClient[] tcpClientes = new TcpClient[ChatServidor.htUsuarios.Count];


            ChatServidor.htUsuarios.Values.CopyTo(tcpClientes, 0);

            for (int i = 0; i < tcpClientes.Length; i++)
            {
                try
                {

                    if (arquivo.Trim() == "" || tcpClientes[i] == null)
                    {
                        continue;
                    }

                    swSenderSender = new StreamWriter(tcpClientes[i].GetStream());
                    swSenderSender.WriteLine(arquivo);
                    swSenderSender.Flush();
                    swSenderSender = null;
                }
                catch
                {
                    RemoveUsuario(tcpClientes[i]);
                }
            }

        }

        public static void EnviaMensagem(string Origem, string Mensagem)
        {
            StreamWriter swSenderSender;

            e = new StatusChangedEventArgs(Origem + ":" + Mensagem);
            OnStatusChanged(e);

            
            TcpClient[] tcpClientes = new TcpClient[ChatServidor.htUsuarios.Count];
          
            ChatServidor.htUsuarios.Values.CopyTo(tcpClientes, 0);
          
            for (int i = 0; i < tcpClientes.Length; i++)
            {
               
                try
                {
                    
                    if (Mensagem.Trim() == "" || tcpClientes[i] == null)
                    {
                        continue;
                    }
                   
                    swSenderSender = new StreamWriter(tcpClientes[i].GetStream());
                    swSenderSender.WriteLine("1|"+Origem + ":" + Mensagem);
                    swSenderSender.Flush();
                    swSenderSender = null;
                }
                catch 
                {
                   RemoveUsuario(tcpClientes[i]);
                }
            }
        }

        public void IniciaAtendimento()
        {
            try
            {

                
                IPAddress ipaLocal = enderecoIP;
                int portaLocal = Nporta;
                
                tlsCliente = new TcpListener(ipaLocal, Nporta);

               
                tlsCliente.Start();

                
                ServRodando = true;

               
                thrListener = new Thread(MantemAtendimento);
                thrListener.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void MantemAtendimento()
        {
            
            while (ServRodando == true)
            {
                
                tcpCliente = tlsCliente.AcceptTcpClient();
                Conexao newConnection = new Conexao(tcpCliente);
            }
        }
    }

    
    class Conexao
    {
        TcpClient tcpCliente;
      
        private Thread thrSender;
        private StreamReader srReceptor;
        private StreamWriter swEnviador;
        private string usuarioAtual;
        private string strResposta;

        
        public Conexao(TcpClient tcpCon)
        {
            tcpCliente = tcpCon;
            
            thrSender = new Thread(AceitaCliente);
            
            thrSender.Start();
        }

        public void FechaConexao()
        {
            // Fecha os objetos abertos
            tcpCliente.Close();
            srReceptor.Close();
            swEnviador.Close();
        }

        private void AceitaCliente()
        {
            srReceptor = new System.IO.StreamReader(tcpCliente.GetStream());
            swEnviador = new System.IO.StreamWriter(tcpCliente.GetStream());

           
            usuarioAtual = srReceptor.ReadLine();

            
            if (usuarioAtual != "")
            {
                
                if (ChatServidor.htUsuarios.Contains(usuarioAtual) == true)
                {
                    
                    swEnviador.WriteLine("0|Este nome de usuário já existe.");
                    swEnviador.Flush();
                    FechaConexao();
                    return;
                }
                else if (usuarioAtual == "Administrator")
                {
                    
                    swEnviador.WriteLine("0|Este nome de usuário é reservado.");
                    swEnviador.Flush();
                    FechaConexao();
                    return;
                }
                else
                {
                    
                    swEnviador.WriteLine("1|");
                    swEnviador.Flush();

                
                    ChatServidor.IncluiUsuario(tcpCliente, usuarioAtual);
                }
            }
            else
            {
                FechaConexao();
                return;
            }
            try
            {


          
                    while ((strResposta = srReceptor.ReadLine()) != "")
                    {

                        if (strResposta == null)
                        {
                            ChatServidor.RemoveUsuario(tcpCliente);
                        }
                        else
                        {
                           ChatServidor.EnviaMensagem(usuarioAtual, strResposta);

                        }
                    }

            }
            catch
            {
                ChatServidor.RemoveUsuario(tcpCliente);
            }
        }
    }

}
