using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGamePeople.Game
{
    public class SRenderObject
    {
        private static List<SRenderObject> _renderList = new List<SRenderObject>(); // создаем список

        private SPosition _position = new SPosition();  // создаем объект классаа позицион

        public static List<SRenderObject> RenderList // статическое свойство
        {
            get
            {
                return _renderList;
            }
        }

        public SPosition Position { get => _position; set => _position = value; } // свойство для объекта

        public virtual void Draw(SScreen screen) // виртуальный метод дроу
        {

        }

        public SRenderObject() // конструктор с добавлением списка
        {
            _renderList.Add(this);
        }

        public void Unregister() // удалить список
        {
            _renderList.Remove(this);
        }

        public static void Clear() // очистить список
        {
            _renderList.Clear();
        }

        // архив детей и 1 человек с которым мы все это сравниваем
        public static List<SRenderObject> CheckCollision(SRenderObject obj, SDirect direct, int move)
        {
            var res = new List<SRenderObject>();

            if(obj == null) return res;

            SPosition newRect = obj.Position.GetMoveRect(direct, move);

            for (int i = 0; i < _renderList.Count; i++)
            {
                var checkObj = _renderList[i];

                if (checkObj.Equals(obj))
                {
                    continue;
                }

                if(newRect.IntersectRect(checkObj._position))
                    res.Add(checkObj);
            }

            return res;
        }
    }
}
