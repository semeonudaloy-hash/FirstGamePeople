using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
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
        private SAnimWindow _explosive = null;
        public SEducationScene(SGame game) : base(game) { }

        private int _Yrandom = 0;
        private int _Xrandom = 0;
        private float _Ugol = 0;
        private float _HeightLine = 0;
        private Random _rand = null;

        public int Yrandom { get => _Yrandom; set => _Yrandom = value; }
        public int Xrandom { get => _Xrandom; set => _Xrandom = value; }
       

        public override void Initialize()
        {
            _fruit = new SFruit(30, 10, 0);
            _human2 = new SCharacter(15, 10, 0);

            //K
            _Ugol = (1.0f * (_human2.Position.Location.Y - _fruit.Position.Location.Y)) / (1.0f * (_human2.Position.Location.X - _fruit.Position.Location.X));


            // находим B через y - k*x
            _HeightLine = _fruit.Position.Location.Y - _Ugol * _fruit.Position.Location.X;

            _human2.NotSeeTable();
            _fruit.ZeroFruit(); 
            _rand = new Random();
            _rand = new Random(_rand.Next(0, 500));

            _explosive = new SAnimWindow(new List<string>()
           {
               "Собирайте на время фрукты и будет вам счастье!!!! ",
               "                                                  ",
               "- Для перехода c меню в игру используйте Enter    ",
               "- Для передвижения используйте клавиши(W, A, S, D)",
               "- Для приостановки игры нажите Space bar          ",
               "- Для выхода из игры в главное меню нажмите Esc   ",
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


            if (Game.Timers.GetTimer("blink") == 0)
            {
                if (_human2.IsOpenEyes)
                {
                    _human2.CloseEyes();

                    Game.Timers.StartTimer("blink", 5);
                }
                else
                {
                    _human2.OpenEyes();

                    Game.Timers.StartTimer("blink", 20);
                }
            }
            if (Game.Timers.GetTimer("explosive") == 0)
            {
                int num = _explosive.Num;

                num++;
                if (num == 6)
                {
                    num++;
                }

                if (num > 11)
                {
                    num = 11;
                }

                _explosive.Num = num;

                Game.Timers.StartTimer("explosive", 15);

            }

            if (Game.Timers.GetTimer("education") == 0)
            {

                if (_fruit.Position.Location.X > _human2.Position.Location.X)
                {
                    _human2.Position.Location.X++;
                    
                }
                if (_fruit.Position.Location.X < _human2.Position.Location.X)
                {
                    _human2.Position.Location.X--;
                    
                }

                if (_human2.Position.Location.X != _fruit.Position.Location.X)
                {

                    // это и есть само y = kx + b
                    _human2.Position.Location.Y = (int)(_Ugol * _human2.Position.Location.X + _HeightLine);
                }
                else
                {
                    _fruit.Position.Location.X = _rand.Next(0, 120 - 6);
                    _fruit.Position.Location.Y = _rand.Next(0, 29 - 7);
                    _fruit.Health.Health = _rand.Next(0, 2);

                    //K
                    _Ugol = (1.0f * (_human2.Position.Location.Y - (_fruit.Position.Location.Y))) / (1.0f * (_human2.Position.Location.X - (_fruit.Position.Location.X)));


                    // находим B через y - k*x
                    _HeightLine = (_fruit.Position.Location.Y) - _Ugol * (_fruit.Position.Location.X);
                }

                

                
                //if (_human2.Position.Location.X == _fruit.Position.Location.X && _human2.Position.Location.Y == _fruit.Position.Location.Y)
                //{
                   
                //    _fruit.Position.Location.X = _rand.Next(0, 100 - 6);
                //    _fruit.Position.Location.Y = _rand.Next(0, 29 - 7);
                //}
                // y = kx + b

               

               

                Game.Timers.StartTimer("education", 2);
            }
            //if (_human2.Position.Location.Y == _fruit.Position.Location.Y)
            //{
            //    // это и есть само y = kx + b
            //    _human2.Position.Location.Y = Ugol * _human2.Position.Location.X + HeightLine;
            //}

        }
        
    }
}


   

