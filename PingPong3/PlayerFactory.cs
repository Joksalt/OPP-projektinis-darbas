using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PingPong3
{
    class PlayerFactory
    {
        public static GameItem CreateOtherPayers(int ScreenWidth, int ScreenHeight)
        {
            return new GameItem
            {
                Position = new Point(ScreenWidth - 3, ScreenHeight / 2)
            };
        }
    }
}
