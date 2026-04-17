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
               "В гланых ролях в качестве разработчиков выступают:",
               "Николай Лямкин",
               "Семён Лямкин",
               "В гланой роли в качестве моральной поддержки выступает:",
               "Василий Лямкин",
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
