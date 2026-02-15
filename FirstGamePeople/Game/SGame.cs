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
            _screen = new SScreen(100, 29);
            _human = new SCharacter(80, 10, 100);
            _walls.Add(new SWall(1,1,10));
            _walls.Add(new SWall(5, 5, 0));
            _walls.Add(new SWall(10, 10, -10));
            _walls.Add(new SWall(15, 15, -20));
            return "";
        }

        public void Start()
        {
            _screen.Clear();
            for(int i = 0; i < _walls.Count; i++)
            {
                _walls[i].Draw(_screen);
            }
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
