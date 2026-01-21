using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlasePascal.GooseGame.Domain
{
    public class Board
    {
        public List<Square> Squares { get; private set; }
        public Random random { get; private set; }
        public Board(Random rnd) 
        { 
            random = rnd;
        }
        public Board() : this(new Random()){}

        public void createBoard() 
        { 
            for (int i = 1; i <= 101; i++) 
            {
                Squares.Add(new Square(i));
            }


        }

        public void createTraps() 
        {
            HashSet<int> trapPositions = new HashSet<int>();
            while (trapPositions.Count < 10)
            {
                trapPositions.Add(random.Next(1, 101));
            }
            for (int i = 0; i <= trapPositions.Count; i++)
            {
                Squares[i].SetTrap(random.Next(1, 4));
            }
        }
    }
}
