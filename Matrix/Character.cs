using Matrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Matrix.Location;
namespace Matrix
{
    public class Character
    {
        private string name;
        private Location location;
        private int age;
        /// <summary>
        /// Constructor de los personajes
        /// </summary>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// <param name="age"></param>
        public Character(string name, Location location, int age)
        {
            this.name=name;
            this.location=location;
            this.age=age;
        }

        public string Name { get => name; set => name = value; }
        public Location Ubicacion { get => location; set => location = value; }
        public int Age { get => age; set => age=value; }


        public override string ToString() {
            return "Nombre: " + name + "\nUbicación: " + location + "\nEdad: " + age;
        }
    }
}
