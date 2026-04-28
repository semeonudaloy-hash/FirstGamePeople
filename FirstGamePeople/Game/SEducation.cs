using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGamePeople.Game
{
    public  class SEducation : SRenderObject
    {
        private int _num = 0;
        public int Num
        {
            get => _num;
            set
            {
                //if (value < 0 || value > 5) return;
                _num = value;
            }
        }

       
        public SEducation() : base()
        {
          
        }
       
       
       
       
        public override void Draw(SScreen screen)
        {
            int width = "                                     ".Length;
            int height = 9;
            Position.Location.X = screen.Cols / 2 - width / 2;
            Position.Location.Y = screen.Rows / 2 - height / 2;

            int x = Position.Location.X;
            int y = Position.Location.Y;

            screen.DrawString(x, y + 0, "                Оглавление                ");
            screen.DrawString(x, y + 1, " Эта игра, в которой вам предстоит бегать ");
            screen.DrawString(x, y + 2, " и собирать фрукты. По достижению 0 очков ");
            screen.DrawString(x, y + 3, "жизни, ваш персонаж умирает. По достяжению");
            screen.DrawString(x, y + 4, "                                    ");
            screen.DrawString(x, y + 5, " По достижению 0 очков ");
            screen.DrawString(x, y + 6, " |                                 | ");
            screen.DrawString(x, y + 7, " =================================== ");
            screen.DrawString(x, y + 8, "                                     ");

        }
        public void RunToFriut()
        {
            // y = kx + b

        }

        //screen.DrawString(x, y + 1, "Для перемещения персонажа используйте");
        //    screen.DrawString(x, y + 2, "         клавиши W, A, S, D                   ");
        //    screen.DrawString(x, y + 3, "Для выхода из игры используйте Esc");


    }
}
