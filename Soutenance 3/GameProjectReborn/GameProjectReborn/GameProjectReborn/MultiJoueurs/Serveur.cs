using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameProjectReborn.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Net;

namespace GameProjectReborn.MultiJoueurs
{
    class Serveur
    {
        private NetworkSession session;

        public Serveur(bool local)
        {
            Guide.ShowSignIn(1,false);
            if (local)
                session = NetworkSession.Create(NetworkSessionType.Local, 2,31);
        }

        public void Update()
        {
            if (session.IsHost)
                Console.WriteLine("Je suis le serveur (" + session.SessionState.ToString() + ")");
            if (session != null)
                session.Update();
        }
    }
}
