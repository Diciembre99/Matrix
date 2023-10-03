using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
     class GenericCharFactory
    {
        /// <summary>
        /// Metodo de construccion de un personaje generico
        /// </summary>
        /// <param name="lenght"></param>
        /// <returns></returns>
        public static GenericChar CreateGenericChar(int lenght)
        {
            RandomNumber rng = new RandomNumber();
            Location location = new Location(rng.GiveCity());
            GenericChar character = new GenericChar(rng.GiveNames(),location, RandomNumber.GiveNumber(0,100), RandomNumber.GiveNumber(0,7));
            return character;
        }
    }
}
