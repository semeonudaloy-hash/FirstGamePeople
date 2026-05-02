using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGamePeople.Game.Scenes
{
    public class SOverScene : SScene
    {
        public SOverScene(SGame game) : base(game) { }

        private SAnimWindow _overtext = null;

        public override void Initialize()
        {
            _overtext = new SAnimWindow(new List<string>()
           {
               "Сожалею, но вы проиграли",
               "           ",
               "   |   |   ",
               "   |   |   ",
               "           ",
               "  _______  ",
               " /       \\",
           });


        }
        public override bool EventKey(ConsoleKeyInfo keyInfo)
        {

            switch (keyInfo.Key)
            {
                case ConsoleKey.Escape:
                    Game.MoveToScene("Menu");
                    break;
                default:
                    return false;
            }
            return false;
        }
        public override void Process()
        {
            if (Game.Timers.GetTimer("Over") == 0)
            {
                int num = _overtext.Num;

                num++;
                if (num == 6)
                {
                    num++;
                }

                if (num > 8)
                {
                    num = 8;
                }

                _overtext.Num = num;

                Game.Timers.StartTimer("Over", 1);
            }
        }
        public void MoveDownSmiley()
        {
            //if()
        }
    }   
}
