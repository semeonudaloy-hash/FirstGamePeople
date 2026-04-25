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
        private SFruit _fruit = null;
        public SEducationScene(SGame game) : base(game) { }

        private int _Yrandom = 0;
        private int _Xrandom = 0;
        private Random _rand = null;

        public int Yrandom { get => _Yrandom; set => _Yrandom = value; }
        public int Xrandom { get => _Xrandom; set => _Xrandom = value; }

        public override void Initialize()
        {
            _human2 = new SCharacter(15, 10, 0);
            _fruit = new SFruit(30, 10, 0);
            _human2.NotSeeTable();
            _rand = new Random();
            _rand = new Random(_rand.Next(0, 500));

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
           
            if (Game.Timers.GetTimer("education") == 0)
            {
                _human2.Position.Location.X = _rand.Next(0, 100-6);
                _human2.Position.Location.Y = _rand.Next(0, 29-7);
                _fruit.Position.Location.X = _rand.Next(0, 100 - 6);
                _fruit.Position.Location.Y = _rand.Next(0, 29 - 7);
                Game.Timers.StartTimer("education", 50);

            }
   
        }
        public void RunToFriut()
        {
            
        }
    }
}


   

