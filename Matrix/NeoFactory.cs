using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
     class NeoFactory
    {
        /// <summary>
        /// Fabrica de Neo generacion aleatoria de datos
        /// </summary>
        /// <param Ancho maximo de la matriz="lenght"></param>
        /// <returns></returns>
        public static Neo CreateNeo(int lenght)
        {
            RandomNumber rng = new ();
            Location location = new (RandomNumber.GiveNumber(0,15), RandomNumber.GiveNumber(0, 15), rng.GiveCity());
            Neo neo = new("Neo",location,25);
            return neo;
        }
    }
}
