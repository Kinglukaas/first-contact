using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class Wall : Sprite
    {

        public Wall(int x, int y) : base ("colors.png", addCollider: true)
        {
            this.x = x;
            this.y = y;
        }
    }
}
