using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class GenericChar:Character
    {
        private int deathPer;
        private int idNum;

        /// <summary>
        /// Constructor de personaje generico
        /// </summary>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// <param name="age"></param>
        /// <param name="deathPer"></param>
        public GenericChar(string name, Location location, int age,int deathPer) : base(name, location, age)
        {
            this.deathPer = deathPer;

        }
        //Getters y Setters
        public int DeathPer { get => deathPer; set => deathPer=value; }
        public int IdNum { get => idNum; set => idNum=value; }

        /// <summary>
        /// Clase que calcula la probabilidad de muerte de un personaje
        /// </summary>
        /// <param name="matrix"></param>
        public void death(Matrix matrix)
        {
            int x = (int)this.Ubicacion.X;
            int y = (int)this.Ubicacion.Y;
            if (this.DeathPer > 7)
            {
                matrix.MatrixChar[x][y] = null;
                matrix.addMatrix();
            }else
            {
                this.deathPer++;
            }

        }
    }


}
