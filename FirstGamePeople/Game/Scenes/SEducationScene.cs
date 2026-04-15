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
        public SEducationScene(SGame game) : base(game) { }



        public override void Initialize()
        {
            _educ = new SEducation(new List<string>()
           {

               "В гланых ролях в качестве разработчиков выступают:",
               "Николай Лямкин",
               "Семён Лямкин",
              
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



    }
}
