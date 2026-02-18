using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FirstGamePeople.Game
{
    public class SGame
    {
        private SScreen _screen = null;
        private SCharacter _human = null;
        private SCharacter _human1 = null;
        private List<SFruit> _fruits = new List<SFruit>();
        private List<SWall> _walls = new List<SWall>();
        
        public string Initialize()
        {
            _screen = new SScreen(100, 29);
            _walls.Add(new SWall(1, 1, 10));
            _walls.Add(new SWall(5, 5, 0));
            _walls.Add(new SWall(10, 10, -10));
            _walls.Add(new SWall(15, 15, -20));
            _fruits.Add(new SFruit(40, 10, -10));
            _fruits.Add(new SFruit(50, 10, 10));
            _fruits.Add(new SFruit(40, 20, 10));
            _fruits.Add(new SFruit(50, 20, -10));
            _human = new SCharacter(80, 10, 100);
            
            return "";
        }

        public void Start()
        {
            ConsoleKeyInfo keyInfo;

            int numFrame = 1;

            while (true)
            {
                //Опрос клавиатуры и реакция на нажатые клавиши
                if (Console.KeyAvailable)
                {
                    keyInfo = Console.ReadKey(true);

                    while (Console.KeyAvailable)
                    {
                        keyInfo = Console.ReadKey(true);
                    }

                    if(keyInfo.Key == ConsoleKey.Escape)
                    {
                        break;
                    }

                    EventFromUser(keyInfo);
                }

                Process(numFrame);
                
                if(numFrame >= 50)
                {
                    numFrame = 1;
                }
                else
                {
                    numFrame++;
                }

                //отрисовка всех игровых объектов
                _screen.Clear();
                for (int i = 0; i < SRenderObject.RenderList.Count; i++)
                {
                    SRenderObject.RenderList[i].Draw(_screen);
                }
                _screen.Draw();

                Thread.Sleep(20);
            }

            Console.Clear();

            Console.WriteLine("Good bye!!!");
        }

        public void EventFromUser(ConsoleKeyInfo keyInfo)
        {
            //////////////////////////
            if (keyInfo.Key == ConsoleKey.W)
            {
                _human?.RunTop();
            }
            if (keyInfo.Key == ConsoleKey.S)
            {
                _human?.RunBottom();
            }
            if (keyInfo.Key == ConsoleKey.D)
            {
                _human?.RunRight();
            }
            if (keyInfo.Key == ConsoleKey.A)
            {
                _human?.RunLeft();
            }
            if (keyInfo.Key == ConsoleKey.E)
            {
                _human?.IncreaseSpeed();
            }
            if (keyInfo.Key == ConsoleKey.Q)
            {
                _human?.DecreaseSpeed();
            }
            if (keyInfo.Key == ConsoleKey.P)
            {
                for (int i = 0; i < SRenderObject.RenderList.Count; i++)
                {
                    if (SRenderObject.RenderList[i] is SCharacter)
                    {
                        SRenderObject.RenderList[i].Unregister();
                        _human = null;
                        break;
                    }
                }
            }
            if (keyInfo.Key == ConsoleKey.N)
            {
                if(_human == null)
                    _human = new SCharacter(1, 1, 100);
            }
        }

        public void Process(int numFrame)
        {
            if(numFrame < 40)
            {
                _human?.OpenEyes();
            }
            else
            {
                _human?.CloseEyes();
            }
        }
    }
}
