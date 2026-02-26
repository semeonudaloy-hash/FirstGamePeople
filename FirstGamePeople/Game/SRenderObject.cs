using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGamePeople.Game
{
    public class SRenderObject
    {
        private static List<SRenderObject> _renderList = new List<SRenderObject>();

        private SPosition _position = new SPosition(); 

        public static List<SRenderObject> RenderList
        {
            get
            {
                return _renderList;
            }
        }

        public SPosition Position { get => _position; set => _position = value; }

        public virtual void Draw(SScreen screen)
        {

        }

        public SRenderObject()
        {
            _renderList.Add(this);
        }

        public void Unregister()
        {
            _renderList.Remove(this);
        }

        // архив детей и 1 человек с которым м все это сравниваем
        public List<SRenderObject> CheckCollision(SRenderObject obj, SDirect direct, int move, out int avaliableMove)
        {
            var res = new List<SRenderObject>();

            avaliableMove = 0;

            for (int i = 0; i < _renderList.Count; i++)
            {
                var checkObj = _renderList[i];

                if (checkObj.Equals(obj))
                {
                    continue;
                }


            }

            return res;
        }

    }
}
