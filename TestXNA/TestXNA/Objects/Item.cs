using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Text;
using System.Threading;

namespace TestXNA.Objects
{
    public class Item
    {
        private String X_cor;
        private String Y_cor;
        public int type;
        public String Direction;
        //public Vector2 Position;
        public int user;
        public Item() {
            this.Direction = "north";
            this.user = 0;
        }

        public void setX_cor(String cor)
        {
            this.X_cor = cor;
        }
        public void setY_cor(String cor)
        {
            this.Y_cor = cor;
        }
        public int getX_cor()
        {
            return Int32.Parse(X_cor);
        }
        public int getY_cor()
        {
            return Int32.Parse(Y_cor);
        }
        public void settype(int type)
        {
            this.type = type;
        }
        public int gettype()
        {
            return type;
        }
        public void setDirection(String dir)
        {
            this.Direction = dir;
        }
        public String getDirection()
        {
            return Direction;
        }
        public void Resetuser()
        {
            this.user=0;
        }
    }
    }

