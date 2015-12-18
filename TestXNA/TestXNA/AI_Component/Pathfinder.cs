using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestXNA.AI_Component
{
    enum SquareContent
    {
        Empty,
        Coin,
        Water,
        Wall,
        Brick,
        Health,
        Tank,
    };
    class Pathfinder
    {
        Objects.Item[,] _squares = new Objects.Item[10, 10];

        static private bool ValidCoordinates(int x, int y)
        {
            // Our coordinates are constrained between 0 and 9.
            if (x < 0)   {return false; }
            if (y < 0) { return false;}
            if (x > 9){return false; }
            if (y > 9){ return false;}
            return true;
        }
    }
}
