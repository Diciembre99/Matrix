using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix;
namespace Matrix
{

    public class Matrix
    {
        private int cont;
        private Character[][] matrixChar;
        private List<GenericChar> cola = new List<GenericChar>();
        private int row;
        private int col;

        /// <summary>
        /// Constructor de Matrix
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public Matrix(int row, int col)
        {
            this.row = row;
            this.col = col;
            this.matrixChar = new Character[col][];
            for (int i = 0; i < row; i++)
            {
                matrixChar[i] = new Character[col];
            }
        }

        public void addMatrix() {
            try
            {

                int x = (int)this.cola[0].Ubicacion.X;
                int y = (int)this.cola[0].Ubicacion.Y;
                if (MatrixChar[x][y] is null)
                {
                    this.MatrixChar[x][y] = this.cola[0];
                    this.cola.RemoveAt(0);
                }

            }
            catch(ArgumentOutOfRangeException) { }

        }
        public int Cont { get => cont; set => cont = value; }
        public Character[][] MatrixChar { get => matrixChar; set => matrixChar=value; }
        public int Row { get => row; set => row = value; }
        public int Col { get => col; set => col=value; }
        public List<GenericChar> Cola { get => cola; set => cola=value; }
    }




}
