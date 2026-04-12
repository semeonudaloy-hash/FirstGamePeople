using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGamePeople.Game
{
    public class SHeroBlock : SRenderObject
    {
        public override void Draw(SScreen screen)
        {
            int width = "                                     ".Length;
            int height = 9;
            Position.Location.X = screen.Cols / 2 - width / 2;
            Position.Location.Y = screen.Rows / 2 - height / 2;

            int x = Position.Location.X;
            int y = Position.Location.Y;
            //screen.DrawString(x, y + 0, "                                     ");
            //screen.DrawString(x, y + 1, " =================================== ");
            //screen.DrawString(x, y + 2, " |                                 | ");
            //screen.DrawString(x, y + 3, " |                                 | ");
            //screen.DrawString(x, y + 4, " |            P A U S E            | ");
            //screen.DrawString(x, y + 5, " |                                 | ");
            //screen.DrawString(x, y + 6, " |                                 | ");
            //screen.DrawString(x, y + 7, " =================================== ");
            //screen.DrawString(x, y + 8, "                                     ");



        }
        
    }
}
