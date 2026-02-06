using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGamePeople.Game
{
    public class SGame
    {
        private SScreen _screen = new SScreen();
        private SCharacter _human = new SCharacter();
        private List<SFruit> _fruits = new List<SFruit>(); 
        private List<SWall> _walls = new List<SWall>();

        public string Initialize()
        {
            return "Выкинь видеокарту дурень, она говно";
        }

        public void Start()
        {

        }

        public void EventFromUser(ConsoleKeyInfo keyInfo)
        {

        }

        public void Process()
        {

        }
    }
}
