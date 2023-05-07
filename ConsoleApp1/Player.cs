using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Player
    {
        private static int score = 0;

        public static int Score
        {
            get
            {
                return score;
            }

            set
            {
                score = value;
            }
        }

        public static void addScore()
        {
            score += 10;
        }
    }
}
