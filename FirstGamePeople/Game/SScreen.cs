using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGamePeople.Game
{
    public class SScreen
    {
        private char[,] array = null;
        private int _rows = 0; //29
        private int _cols = 0; //100

        public SScreen(int cols,int rows)
        {
            _rows = rows;
            _cols = cols;
            array = new char[rows, cols];

            Clear();
        }

        public int Rows { get => _rows; }
        public int Cols { get => _cols; }

        /// <summary>
        /// Очистка экранного буфера
        /// </summary>
        public void Clear()
        {
            // Заполняем пробелами
            for (int i = 0; i < _rows; i++) //
            {
                for (int j = 0; j < _cols; j++)
                {
                    array[i, j] = ' ';  // Записываем пробел
                }
            }
        }

        /// <summary>
        /// Отрисовка экранного буфера
        /// </summary>
        public void Draw()
        {
            //Console.Clear();
            Console.CursorLeft = 0;
            Console.CursorTop = 0;

            string buffer = "";
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    buffer += array[i, j]; 
                }

                buffer += "\r\n";
            }

            Console.Write(buffer);
        }

        public void DrawPixel(int x, int y,char ch)
        {
            if (x < 0 || x >= _cols) return;
            if (y < 0 || y >= _rows) return;

            array[y,x] = ch;
        }

        public void DrawString(int x, int y, string text,int gap)
        {
            for(int  i = 0; i < text.Length; i++)
            {
                DrawPixel(x+i*gap, y, text[i]);
            }
        }

        public void DrawString(int x, int y, string text)
        {
            DrawString(x, y, text, 1);
        }

        public void DrawString(SPosition position, string text)
        {
            DrawString(position.Location.X, position.Location.Y, text);
        }
    }
}
