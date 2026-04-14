using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGamePeople.Game.Scenes
{
    public class SMenuScene : SScene
    {
        SMenu _menu = null;
        public SMenuScene(SGame game) : base(game) { }

        public override void Initialize() 
        {
            _menu = new SMenu(
                new List<string>()
                {
                    "Новая игра",
                    "Обучение",
                    "Об авторах",
                    "Выход",
                   
                },
                0);
        }
        /// <summary>
        /// кнопки их привязка к действиям 
        /// </summary>
        public override bool EventKey(ConsoleKeyInfo keyInfo) 
        {
           
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    _menu.PreviousItem();
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    _menu.NextItem();
                    break;
                case ConsoleKey.Enter:
                    switch (_menu.SelectedIndex)
                    {
                        case 0:
                            Game.MoveToScene("Game");
                            return false;
                        case 1:
                            return false;
                        case 2:
                            Game.MoveToScene("About");
                            return false;
                        case 3:
                            return true;
                        default:
                            return false;
                    }
                default:
                    return false;
            }
            return false; 
        }

        public override void Process() 
        {
            if (Game.Timers.GetTimer("blink") == 0)
            {
                _menu.NextCadr();
                Game.Timers.StartTimer("blink", 5);
            }
        }
    }
}
