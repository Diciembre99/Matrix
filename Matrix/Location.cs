using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class Location
    {
        private double x;
        private double y;
        private string city;
        /// <summary>
        /// Ubicacion de los personajes solo con atributo de la ciudad
        /// </summary>
        /// <param name="city"></param>
        public Location(string city)
        {
            this.city = city;
        }
        public Location( double x, double y)
        {
            this.x=x;
            this.y=y;
        }

        /// <summary>
        /// Constructor de la ubicacion con todos los atributos
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="ciudad"></param>
        public Location(double x, double y, string ciudad)
        {
            this.x=x;
            this.y=y;
            this.city=ciudad;
        }

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public string City { get => city; set => city=value; }

        public override string ToString()
        {
            return city;
        }
    }
}
