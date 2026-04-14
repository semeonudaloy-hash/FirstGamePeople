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
        private List<string> text = new List<string>();
        

        public SAnimWindow(List<string> text) : base()
        {
            this.text = text;
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

            if(_num >= 6)
            {
                for (int i = 0; i < text.Count; i++)
                {
                    string str = text[i];
                    screen.DrawString(cx-str.Length/2,cy+i-text.Count/2,str);
                }
            }
            
            for (int i = 0; i < _num * 2; i++)
            {
                screen.DrawPixel(cx - _num * 4, cy - i + _num, '|');
                screen.DrawPixel(cx + _num * 4 - 1, cy - i + _num, '|');


            }
            //for (int i1 = 0; i1 < text.Count; i1++)
            //{
            //    screen.DrawString(Position.Location.X + width / 2 - text [i1].Length / 2, Position.Location.Y + 3 * i1 + 1, text[i1]);
            //}

                for (int i = 0; i < 8 * _num; i++)
            {
                char c = '=';
                if(i == 0)
                {
                    c = '/';
                }
                if (i == 8*_num - 1)
                {
                    c = '\\';
                }
                screen.DrawPixel(cx - 8 / 2 * _num + i, cy - _num, c);
                if (i == 0)
                {
                    c = '\\';
                }
                if (i == 8 * _num - 1)
                {
                    c = '/';
                }
                screen.DrawPixel(cx - 8 / 2 * _num + i, cy + _num, c);
                    

                //screen.DrawPixel(cx - 7 / 2 * _num + i, cy - _num, '=');
                //screen.DrawPixel(cx - 7 / 2 * _num + i, cy + _num, '=');
            }
           

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
        }
    }
}
