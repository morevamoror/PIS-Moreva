using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace игра
{
    public class Image
    {
        public string[] words = { "facebook", "авокадо", "самолет", "банан", "бокал", "майка", "бриллиант", "кольцо", "вишня", "бант", "дом", "скамейка", "звезда", "фотоаппарат", "карусель", "колокол", "морковь", "елка", "треугольник", "принтер", "шоколад", "варежка", "свеча", "конфета", "пингвин", "подарок", "букет", "конверт", "сумка", "сыр", "twitter", "телефон", "хлеб", "яблоко" };

            public string value;
        public int number;

            public Image(int nomer)
            {
                value = words[nomer];
                number = nomer;
            }

            public string ToString( Image c)
            {
                return value;
            }
        public int Nomer(Image c)
        {
            return number;
        }
        public string[] Words()
        {
            return words;
        }
        }

    }

