using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class RandomNumber
    {
        readonly string[] citys = { "New York","Boston","Baltimore","Atlanta","Detroit", "Dallas","Denver"  };
        readonly string[] names = { "Michelle", "Alexander", "James", "Caroline", "Claire", "Jessica", "Erik", "Mike" };

        /// <summary>
        /// Genera un numero aleatorio entre un minimo y un numero maximo
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int GiveNumber(int min, int max)
        {
            Random random = new ();
            return random.Next(min,max);
        }

        /// <summary>
        /// Metodo que otorga una ciudad aleatoria de una lista predeterminada
        /// </summary>
        /// <returns></returns>
        public string GiveCity()
        {
            Random random = new();
            int index = random.Next(citys.Length);
            return citys[index];
        }
        /// <summary>
        /// Otorga un numero aleatorio de una lista
        /// </summary>
        /// <returns></returns>
        public string GiveNames() {
            Random random = new ();
            int index = random.Next(names.Length);
            return names[index];
        }
    }
}
