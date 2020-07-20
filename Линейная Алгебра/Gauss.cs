using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Прямой_обратный
{
	class Gauss
	{

		private static int MaxRowIndex(int coloumn, Matrix matrix)
		{
			int size = matrix.GetRank();

			double max = matrix[coloumn, coloumn];
			int MaxRowIndex = coloumn;

			for (int row = coloumn; row < size; row++)
			{


				if (max < matrix[row, coloumn])
				{
					max = matrix[row, coloumn];
					MaxRowIndex = row;
				}



			}


			return MaxRowIndex;


		}



		public static Vector GaussMethod(Matrix matr,Vector b)
		{
			int size = matr.GetRank();

			double[,] SupMatrix;
			double[] SupVector;
			SupMatrix = new double[size, size];
			SupVector = new double[size];
			Matrix matrix = matr;
			
			Vector rez;

			for (int j = 0; j < size; j++)
			{
				int maxInRow = MaxRowIndex(j, matr);


				for (int i = 0; i < size; i++)
				{
					SupMatrix[j, i] = matrix[j, i];
					matrix[j, i] = matrix[maxInRow, i];
					matrix[maxInRow, i] = SupMatrix[j, i];

					SupVector[j] = b[j];
					b[j] = b[maxInRow];
					b[maxInRow] = SupVector[j];



				}

				Vector UpVector = matrix.GetRow(j);

				for (int row = j + 1; row < size; row++)
				{
					double c = matrix[row, j] / matrix[j, j];

					Vector DownVector = matrix.GetRow(row);
					b[row] = b[row] - c * b[j];

					rez = DownVector + UpVector * (-c);

					for (int coloumn = 0; coloumn < size; coloumn++)
					{
						matrix[row, coloumn] = rez[coloumn];
					}



				}



			}
			return SolveTriangularMatrix.UP_STEP(matrix, b); 
		}

	}
}
