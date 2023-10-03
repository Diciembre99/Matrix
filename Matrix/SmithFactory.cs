using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public static class SmithFactory
    {
        /// <summary>
        /// Creacion de el personaje Smith
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public static Smith createSmith(int max)
        {
            //Llamamos al metodo de genracion de datos aleatorios para completar los campos
            RandomNumber rng = new RandomNumber();
            int x = RandomNumber.GiveNumber(0,max);
            int y = RandomNumber.GiveNumber(0,max);
            //Asignamos una ciudad aleatoria
            Location location = new Location(x,y,rng.GiveCity());
            Smith smith = new Smith("Smith",location, RandomNumber.GiveNumber(0,70),20);
            return smith;

        }
    }
}
