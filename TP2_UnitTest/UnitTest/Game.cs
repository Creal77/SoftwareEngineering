using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Game
    {
        Random rng = new Random();

        public void Move(Direction d)
        {
            player.Move(d);
            PlayTurn();
            arrow_thrown = false;
        }
        void PlayTurn()
        {
            CheckForBats();
            CheckForWumpus();
            CheckForPits();
        }
        void CheckForBats()
        {
            bats_found = false;
            if (bats.Contains(player.Location))
            {
                TransportPlayer();
                PlayTurn();
                bats_found = true;
            }
        }
        void TransportPlayer()
        {
            int room = rng.Next(width * height);
            PutPlayerInRoom(room);
        }
    }
}
}
