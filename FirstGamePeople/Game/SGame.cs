using FirstGamePeople.Game.Scenes;
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
        private STimers _timers = null;
        private SScene _activeScene = null; // текущая сцена
        private Dictionary<string, SScene> _scenes = new Dictionary<string, SScene>(); // список сцен

        public STimers Timers { get => _timers;}
        public SScreen Screen { get => _screen;}

        /// <summary>
        /// содание сцены, иниализация сцены, создаем объекты Timers, SScreen c параметрами 
        /// </summary>
        public string Initialize()
        {   
            _timers = new STimers();
            
            _screen = new SScreen(Console.WindowWidth-1,Console.WindowHeight-1);

            //создаём все наши сцены
            _scenes.Add("Menu", new SMenuScene(this));
            _scenes.Add("Game", new SGameScene(this));
            _scenes.Add("About", new SHeroesScene(this));
            _scenes.Add("Education", new SEducationScene(this));
            _scenes.Add("Over", new SOverScene(this));

            //берём главную сцену и инициализируем её
            _activeScene = _scenes["Menu"];
            _activeScene.Initialize();

            return "";
        }

        /// <summary>
        /// метод с циклом,внутри которого есть опрос клавиатуры, формируется очередной кадр, отрисовываются все игровые объекты
        /// </summary>
        public void Start()
        {
            ConsoleKeyInfo keyInfo;

            //игровой цикл
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

                    if(_activeScene.EventKey(keyInfo))
                    {
                        break;
                    }
                }

                //формирование очередного кадра
                _activeScene.Process();
                
                //отрисовка всех игровых объектов
                _screen.Clear();
                for (int i = 0; i < SRenderObject.RenderList.Count; i++)
                {
                    SRenderObject.RenderList[i].Draw(_screen);
                }
                _screen.Draw();

                _timers.Tick();

                Thread.Sleep(20);
            }

            Console.Clear();

            Console.WriteLine("Good bye!!!");
        }
        //?
        public void MoveToScene(string name)
        {
            if (!_scenes.ContainsKey(name)) return;

            _activeScene = _scenes[name];

            _timers.ResetAllTimers();

            SRenderObject.Clear();

            _activeScene.Initialize();
        }
    }
}
