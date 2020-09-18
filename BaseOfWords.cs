using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallows
{
    class BaseOfWords
    {
        private List<string> words;

        public List<string> GetWords()
        {
            return words;
        }


        public BaseOfWords()
        {
            words = new List<string> { "солома", "дипломат", "матрос", "вездеход", "киносеанс", "дорога", "катамаран", "лошадь", "веретено", "деревня", "ливень", "слон", "резервуар" };
        }
    }
}
