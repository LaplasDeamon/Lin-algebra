using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Прямой_обратный
{
	class QR_Solve
	{

		//метод Грама-Шмидта, Разложение на треугольную матрицу Т и на ортогональную R
		public static Vector QR_SOLVE(Matrix matrix,Vector b)
		{
			
			Matrix matrixA = matrix;// начальная матрица

			int size = matrix.GetRank();

			Matrix Rmatrix = new Matrix(size, size);
			Matrix T = FirstFillingTMatrix(size);
			
			List<Vector> vectors = new List<Vector>(); // список с ортогональными векторами матрицы R

			for (int row = 0; row < size; row++)
			{
				//вычисление ряда для R вектора
				Vector R = matrixA.GetColoumn(row);
				for (int j = 0;  j<row ; j++)
				{						
					  R += (-T[j, row]) * vectors[j ];
				}
			
				vectors.Add(R);
			
				//формирование значения матрицы Т[row,k]
				for (int k=row+1;k<size;k++)
				{
					T[row, k] = (matrixA.GetColoumn(k) * vectors[row]) / (vectors[row] * vectors[row]);

					
				}

			}
			//установка в Rmatrix полученных векторов R
			for (int i = 0; i < size; i++)
			{
				Matrix.SetColoumn(vectors[i], Rmatrix, i);
			}


	
			
			return SOLVE_LES(Rmatrix, T, b);
			
		}


		// первичное заполнение матрицы Т ( на главной диалгонали 1, вне ее 0)
		private static Matrix FirstFillingTMatrix(int size)
		{
			Matrix T = new Matrix(size, size);



			for (int row = 0; row < size; row++)
			{
				for (int col = 0; col < size; col++)
				{
					if (row >= col)
					{
						if (row == col)
						{
							T[row, col] = 1;	
						}
						else
						{
							T[row, col] = 0;
						}
					}
				}
			}
			return T;
		}

		// метод решающий СЛАУ
		private  static Vector SOLVE_LES(Matrix R, Matrix T, Vector b)
		{
			
			Matrix Rmatrix = R.Copy();
			
			Matrix R_Transponent = Matrix.Transparent(R);
			

			Matrix D = R_Transponent * Rmatrix;
			
			MakeNulls(D);
			D *= T;

			Vector Beta = R_Transponent * b;
		
			
			return SolveTriangularMatrix.UP_STEP(D, Beta) ;
		}

		// устранение погрешностей диагональной матрицы D
		private static Matrix MakeNulls(Matrix matrix)
		{

			for (int row = 0; row < matrix.Rows; row++)
			{
				for (int col = 0; col < matrix.Cols; col++)
				{
					if (row >col)
						matrix[row, col] = 0;
				}
			}
			return matrix;
		}
	

	}

	
}
