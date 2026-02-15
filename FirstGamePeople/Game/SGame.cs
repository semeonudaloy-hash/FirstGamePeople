using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGamePeople.Game
{
    public class SGame
    {
        private SScreen _screen = null;
        private SCharacter _human = null;
        private List<SFruit> _fruits = new List<SFruit>(); 
        private List<SWall> _walls = new List<SWall>();

        public string Initialize()
        {
            _screen = new SScreen(29, 100);
            _human = new SCharacter(20, 20, 100);
            return "";
        }

        public void Start()
        {
            _screen.Clear();
            _human.Draw(_screen);
            _screen.Draw();
        }

        public void EventFromUser(ConsoleKeyInfo keyInfo)
        {

        }

        public void Process()
        {

        }
    }
}
