﻿using System;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace HellMail {

    public class TCPServer {

        private string name = "TCP";

        private X509Certificate2 serverCertificate = null;

        private readonly TcpListener listener;

        public TCPServer(string IP, int portNumber, string cert) {

            // Set TLS protocol 
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // Set Self Signed Certificate 
            serverCertificate = new X509Certificate2(cert);

            listener = new TcpListener(IPAddress.Parse(IP), portNumber);
        }

        public void Start() {
            // Start listening 
            listener.Start();
            Console.WriteLine(name + " FQDN: " + Helper.GetFQDN());
            Console.WriteLine(name + " Server started");

            while (true) {
                // Wait for a client to connect
                TcpClient client = listener.AcceptTcpClient();

                Console.WriteLine(name + ": Client connection accepted");

                SslStream sslStream = new SslStream(client.GetStream(), false, (a,b,c,d) => true);
           
                sslStream.AuthenticateAsServer(serverCertificate, false, SslProtocols.Tls12, false);

                if (sslStream.IsAuthenticated) {
                    Console.WriteLine(name + ": Client SSL authenticated");
                } else {
                    throw new Exception("SSL Authentication failed");
                }

                // Start ProcessClient() on a new Thread
                var clientThread = new Thread(() => ProcessClient(sslStream));
                clientThread.Start();
            }

        }

        // A way for the deprived classes to process the clients
        protected virtual void ProcessClient(SslStream client) { }

        // Set the name of the server protocol, e.g. SMTP or POP3
        protected void setName(string name) {
            this.name = name;
        }

        // StreamWrite() is used to write a message to the client
        protected void StreamWrite(SslStream client, string message) {
            byte[] msg = Encoding.ASCII.GetBytes(message + "\n");
            client.Write(msg);
        }

        // StreamRead() is used to read a message from the client
        protected string StreamRead(SslStream client) {
            byte[] buffer = new byte[1024];

            int n = client.Read(buffer, 0, buffer.Length);

            string _message = Encoding.UTF8.GetString(buffer, 0, n);

            return _message;
        }

    }
}
