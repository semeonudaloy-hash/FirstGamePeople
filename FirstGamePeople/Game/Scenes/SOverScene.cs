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
               "Собирайте на время фрукты и будет вам счастье!!!! ",
               "                                                  ",
               "- Для перехода c меню в игру используйте Enter    ",
               "- Для передвижения используйте клавиши(W, A, S, D)",
               "- Для приостановки игры нажите Space bar          ",
               "- Для выхода из игры в галвное меню нажмите Esc   ",
               "               Приятной игры!                     ",
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
            if (Game.Timers.GetTimer("OverTimer") == 0)
            {
                int num = _overtext.Num;

                Game.Timers.StartTimer("OverTimer", 15);
            }
        }
    }   
}
