using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGamePeople.Game.Scenes
{
    public class SHeroesScene : SScene
    {
        private SAnimWindow _explosive = null;
        public SHeroesScene(SGame game) : base(game) { }

        public override void Initialize()
        {
           _explosive = new SAnimWindow();
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
            if (Game.Timers.GetTimer("explosive") == 0)
            {
                int num = _explosive.Num;

                num++;

                if(num > 15)
                {
                    num = 0;
                }

                _explosive.Num = num;

                Game.Timers.StartTimer("explosive", 5);
                
            }
        }
    }
}
