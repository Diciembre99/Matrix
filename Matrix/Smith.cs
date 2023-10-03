using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class Smith : Character
    {
        //Capacidad de infectar
        private double infectionProb;
        private int idNum;
        private List<Location> history = new();

        /// <summary>
        /// Constructor de Smith 
        /// </summary>
        /// <param nombre="name"></param>
        /// <param ubicacion="location"></param>
        /// <param edad="age"></param>
        /// <param probabilidad de infecion="infectionProb"></param>
        public Smith(string name, Location location, int age, double infectionProb) : base(name, location, age)
        {
            this.infectionProb = infectionProb;
            this.IdNum = idNum;
        }

        public double InfectionProb { get => infectionProb; set => infectionProb = value; }
        public int IdNum { get => idNum; set => idNum=value; }
        public List<Location> History { get => history; set => history=value; }

        /// <summary>
        /// Metodo de movimiento de smith segun su ubicacion
        /// </summary>
        /// <param ubicacion="x"></param>
        /// <param ubicacion="y"></param>
        /// <param matriz="matrix"></param>
        public void MoveSmith(int x, int y, Matrix matrix)
        {
            int sX = (int)this.Ubicacion.X;
            int sY = (int)this.Ubicacion.Y;



            if (x > sX) sX++;
            else sX--;
            if (y > sY) sY++;
            else sY--;

            if (sX >= 0 && sX < 15 && sY >= 0 && sY < 15)
            {
                if (matrix.MatrixChar[sX][sY] is not Neo &&
                    matrix.MatrixChar[sX+1][sY] is not Neo)
                {
                    Location location = new(sX, sY);
                    History.Add(location);
                    Thread.Sleep(300);
                    matrix.MatrixChar[sX][sY] = this;
                    matrix.MatrixChar[(int)this.Ubicacion.X][(int)this.Ubicacion.Y] = null;
                    this.Ubicacion.X = sX;
                    this.Ubicacion.Y = sY;
                    Utility.ChangeLocation(sX, sY, this);
                    Utility.PrintMatrix(matrix.MatrixChar, this);

                    // Llamar a la función recursivamente con las nuevas coordenadas
                    MoveSmith(x, y, matrix);
                }
            }

        }


        public override string ToString()
        {
            return base.ToString() + "\nProbabilidad de infectar: " + infectionProb + "\nnumero de identificacion: "+idNum;
        }
    }


}
