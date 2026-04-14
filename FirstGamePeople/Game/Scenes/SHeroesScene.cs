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
           _explosive = new SAnimWindow(new List<string>()
           {
               "Hello world 1 Hello world 1 ",
               "Hello world 2",
               "Hello world 3 Hello world 1 ",
               "Hello world 1",
               "Hello world 2 Hello world 1 ",
               "Hello world 3",
               "Hello world 1 Hello world 1 ",
               "Hello world 2",
               "Hello world 3 Hello world 1 ",
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
            if (Game.Timers.GetTimer("explosive") == 0)
            {
                int num = _explosive.Num;

                num++;

                if(num > 11)
                {
                    num = 11;
                }

                _explosive.Num = num;

                Game.Timers.StartTimer("explosive", 5);

                

            }
        }
    }
}
