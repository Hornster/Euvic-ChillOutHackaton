using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackatonProj.Data;
using SFML.System;
using SFML.Window;

namespace HackatonProj.Logics
{
    public class KeyEventResolver
    {
        public bool ResolveKeyPressedEndProgram(KeyEventArgs args)
        {
            return args.Code == Keyboard.Key.Escape;
        }

        public bool ResolveKeyPressedResetState(KeyEventArgs args)
        {
            return args.Code == Keyboard.Key.Q;
        }
        /// <summary>
        /// Resolves the keyPressedEvents.
        /// </summary>
        /// <param name="args">Arguments of the pressed key</param>
        /// <param name="player">The ID of the player that is being checked.</param>
        /// <returns>Tuple with axis multipliers of movement for the player and a boolean indicating shot.</returns>
        public bool ResolveKeyPressedEventPlayers(KeyEventArgs args, Enums.players player)
        {
            switch (player)
            {
                case Enums.players.Player1:
                    return CheckMovementKeysPlayer1Dark(args);
                case Enums.players.Player2:
                    return CheckMovementKeysPlayer2Light(args);
            }

            return false;
        }

        public Vector2i ListenForPlayersInput(Enums.players player)
        {
            switch (player)
            {
                case Enums.players.Player1:
                    return ListenForInputPlayer1Dark();
                case Enums.players.Player2:
                    return ListenForInputPlayer2Light();
            }

            return new Vector2i(0, 0);
        }
        private Vector2i ListenForInputPlayer1Dark()
        {
            Vector2i velocityVect = new Vector2i();
            if (Keyboard.IsKeyPressed(Keyboard.Key.T))
            {
                velocityVect.Y = -1;
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.G))
            {
                velocityVect.Y = 1;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.F))
            {
                velocityVect.X = -1;
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.H))
            {
                velocityVect.X = 1;
            }

            return velocityVect;
        }
        private Vector2i ListenForInputPlayer2Light()
        {
            Vector2i velocityVect = new Vector2i();

            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                velocityVect.Y = -1;
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                velocityVect.Y = 1;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                velocityVect.X = -1;
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                velocityVect.X = 1;
            }

            return velocityVect;
        }
        private  bool CheckMovementKeysPlayer1Dark(KeyEventArgs args)
        {
            
            bool isFiring = false;

            
            isFiring = args.Code == Keyboard.Key.Z;

            return isFiring;
        }
        private  bool CheckMovementKeysPlayer2Light(KeyEventArgs args)
        {
            bool isFiring = false;
            

            isFiring = args.Code == Keyboard.Key.Period;

            return isFiring;
        }
    }
}
