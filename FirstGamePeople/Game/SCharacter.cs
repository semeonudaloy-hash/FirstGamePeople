using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGamePeople.Game
{
    public class SCharacter : SRenderObject
    {

        private SHealth _health = new SHealth();
        private SPosition _position = new SPosition();


        public SHealth Health { get => _health; set => _health = value; }
        public SPosition Position { get => _position; set => _position = value; }

        public override void Draw(SScreen screen)
        {
            throw new NotImplementedException();
        }
    }
}
 