using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGamePeople.Game.Scenes
{
    public class SEducationScene : SScene
    {
        private SEducation _educ = null;
        private SCharacter _human2 = null;
        public SEducationScene(SGame game) : base(game) { }



        public override void Initialize()
        {
           

            Random _rand2 = new Random();
            _rand2 = new Random(_rand2.Next(1, 11));
            _human2 = new SCharacter(15, 10, 0);
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
            if(Game.Timers.GetTimer("education") == 0)
            {
                Game.Timers.StartTimer("education", 10);
            }
   
        }
       
       


    }
}


   

