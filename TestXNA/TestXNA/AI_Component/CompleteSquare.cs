using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestXNA.AI_Component
{
    class CompleteSquare
    {
        SquareContent _contentCode = SquareContent.Empty;
        public SquareContent ContentCode
        {
            get { return _contentCode; }
            set { _contentCode = value; }
        }

        int _distanceSteps = 100;
        public int DistanceSteps
        {
            get { return _distanceSteps; }
            set { _distanceSteps = value; }
        }

        bool _isPath = false;
        public bool IsPath
        {
            get { return _isPath; }
            set { _isPath = value; }
        }

        public void FromChar(char charIn)
        {
            // Use a switch statement to parse characters.
            switch (charIn)
            {
                case 'W':
                    _contentCode = SquareContent.Wall;
                    break;
                case 'B':
                    _contentCode = SquareContent.Brick;
                    break;
                case 'H':
                    _contentCode = SquareContent.Water;
                    break;
                case 'C':
                    _contentCode = SquareContent.Coin;
                    break;
                case 'T':
                    _contentCode = SquareContent.Tank;
                    break;
                case 'L':
                    _contentCode = SquareContent.Health;
                    break;
                case ' ':
                default:
                    _contentCode = SquareContent.Empty;
                    break;
            }
        }
    }
}
