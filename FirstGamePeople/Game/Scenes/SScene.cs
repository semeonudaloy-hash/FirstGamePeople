using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGamePeople.Game.Scenes
{
    public class SScene
    {
        private SGame _game = null;

        public SGame Game { get => _game;}

        public SScene(SGame game)
        {
            this._game = game;
        }

        public virtual void Initialize() { }

        public virtual bool EventKey(ConsoleKeyInfo keyInfo) { return true; }

        public virtual void Process() { }
    }
}
