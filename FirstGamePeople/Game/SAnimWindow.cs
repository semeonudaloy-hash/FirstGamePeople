using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FirstGamePeople.Game
{
    public class SAnimWindow : SRenderObject
    {
        private int _num = 0;

        public SAnimWindow() : base()
        {
            
        }

        public int Num 
        { 
            get => _num;
            set
            {
                //if (value < 0 || value > 5) return;
                _num = value;
            }
        }

        public override void Draw(SScreen screen)
        {
            int cx = screen.Cols / 2;
            int cy = screen.Rows / 2;

            //switch(_num)
            //{
            //    case 0:
            //        break;
            //    case 1:
            //        screen.DrawString(x, y, "0");
            //        break;
            //    case 2:
            //        screen.DrawString(x-1, y, "(0)");
            //        break;
            //    case 3:
            //        screen.DrawString(x - 3, y-1, "( / \\ )");
            //        screen.DrawString(x - 2, y,  "( 0 )");
            //        screen.DrawString(x - 3, y+1, "( \\ / )");
            //        break;
            //    case 4:
            //        screen.DrawString(x, y - 2, "^");
            //        screen.DrawString(x - 2, y - 1, "(   )");
            //        screen.DrawString(x - 4, y + 0, "(   0   )");
            //        screen.DrawString(x - 2, y + 1, "(   )");
            //        screen.DrawString(x, y + 2, "_");
            //        break;
            //    case 5:
            //        screen.DrawString(x - 6, y - 2, "(           )");
            //        //screen.DrawString(x - 4, y - 1, " ");
            //        screen.DrawString(x - 10, y + 0, "(         0         )");
            //        //screen.DrawString(x - 4, y + 1, " ");
            //        screen.DrawString(x - 6, y + 2, "(           )");
            //        break;
            //}

            for(int i = 0;i<7*_num;i++)
            {
                screen.DrawPixel(cx - 7/2 * _num + i, cy - _num, '=');
                screen.DrawPixel(cx - 7/2 * _num + i, cy + _num, '=');

                //screen.DrawPixel(cx - 7 / 2 * _num + i, cy - _num, '=');
                //screen.DrawPixel(cx - 7 / 2 * _num + i, cy + _num, '=');
            }
        }
    }
}
