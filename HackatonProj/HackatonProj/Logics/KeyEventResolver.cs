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
        /// <summary>
        /// Resolves the keyPressedEvents.
        /// </summary>
        /// <param name="args">Arguments of the pressed key</param>
        /// <param name="player">The ID of the player that is being checked.</param>
        /// <returns>Tuple with axis multipliers of movement for the player and a boolean indicating shot.</returns>
        public Tuple<Vector2i, bool>ResolveKeyPressedEventPlayers(KeyEventArgs args, Enums.players player)
        {
            switch (player)
            {
                case Enums.players.Player1:
                    return CheckMovementKeysPlayer1Dark(args);
                case Enums.players.Player2:
                    return CheckMovementKeysPlayer2Light(args);
            }

            return Tuple.Create(new Vector2i(0, 0), false);
        }

        private Tuple<Vector2i, bool> CheckMovementKeysPlayer1Dark(KeyEventArgs args)
        {
            Vector2i velocityVect = new Vector2i();
            bool isFiring = false;
            switch (args.Code)
            {
                case Keyboard.Key.W:
                    velocityVect.Y = -1;
                    break;
                case Keyboard.Key.S:
                    velocityVect.Y = 1;
                    break;
                case Keyboard.Key.A:
                    velocityVect.X = -1;
                     break;
                case Keyboard.Key.D:
                    velocityVect.X = 1;
                    break;
            }

            isFiring = args.Code == Keyboard.Key.Z;

            return Tuple.Create(velocityVect, isFiring);
        }
        private Tuple<Vector2i, bool> CheckMovementKeysPlayer2Light(KeyEventArgs args)
        {
            Vector2i velocityVect = new Vector2i();
            bool isFiring = false;
            switch (args.Code)
            {
                case Keyboard.Key.Up:
                    velocityVect.Y = -1;
                    break;
                case Keyboard.Key.Down:
                    velocityVect.Y = 1;
                    break;
                case Keyboard.Key.Left:
                    velocityVect.X = -1;
                    break;
                case Keyboard.Key.Right:
                    velocityVect.X = 1;
                    break;
            }

            isFiring = args.Code == Keyboard.Key.Slash;

            return Tuple.Create(velocityVect, isFiring);
        }
    }
}
