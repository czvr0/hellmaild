﻿using System;
using System.Net;

namespace HellMail {

    class MainClass {

        public static void Main(string[] args) {

            string mailData = 
                "From: kent@hellmail.dk\n" +
                "To: christian@hellmail.dk\n" +
                "Subject: Test\n" + 
                "\n" +
                "To: Hej med jer alle sammen TO: \n" +
                "To: Hej med jer alle sammen TO: \n" +
                "To: Hej med jer alle sammen TO: \n" +
                "To: Hej med jer alle sammen TO: \n" +
                "To: Hej med jer alle sammen TO: \n" +
                ".\n"
            ;


            Mail mail = new Mail();

            mail.Parse(mailData);



            /*
            for(int i = 0; i < args.Length; i++) {
                Console.WriteLine(i + ":" + args[i]);
            }

            try {
                POPServer hpop = new POPServer("0.0.0.0", int.Parse(args[1]), args[0]);

                hpop.Start();

            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
           
            */
            /*
            try {
                SMTPServer server = new SMTPServer("0.0.0.0", int.Parse(args[1]), args[0]);

                server.Start();

            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
            */
        }
    }
}
