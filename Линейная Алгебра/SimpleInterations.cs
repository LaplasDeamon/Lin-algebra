using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Прямой_обратный
{
	class SimpleInterations
	{
		//функия принимает матрцу, вектор и погрешность измерения, а возвращает вектор-результат
		public static Vector ApproximationMethod(Matrix mtr, Vector b, double accuracy)
		{
			int size = mtr.GetRank();
			//создание матрицы вида x=β - αx
			for (int row = 0; row < size; row++)
			{
				double coef = mtr[row, row];
				mtr[row, row] = 0;
				if (mtr[row, row] < 0)
				{
					coef = -coef;
					b[row] = -b[row] / coef;
					for (int col = 0; col < size; col++)
					{
						mtr[row, col] = mtr[row, col] / coef;
					}
				}
				else
				{
					b[row] = b[row] / coef;
					for (int col = 0; col < size; col++)
					{
						mtr[row, col] = -mtr[row, col] / coef;
					}
				}
			}
			//проверка на сходимость для матрицыы коэффициентов
			for(int row=0; row < mtr.GetRank(); row++)
			{
				double sum = 0;
				for (int col = 0; col < mtr.GetRank(); col++)
				{
					sum += mtr[row, col];
				}
				if (sum > 1)
					throw new Exception("матрица плохо обусловлена");
			}
				
			return Rec(mtr, b, accuracy);
			
		}

		// функция подсчитывает новые значения x для каждой новой итерции
		private static Vector Rec(Matrix matrix,Vector b,double accuracy)
		{
			int size = matrix.GetRank();
			double e = 100;
			
			//начальное заполнение значений x
			List<double> xList = new List<double>() {0,0,0};
			
			// проверка заданой  погрешности и вычисленной
			while (e>accuracy)
			{
				List<double> FreeXList = new List<double>();
				for (int row = 0; row < size; row++)
				{

					double x = b[row];
					for(int col = 0; col < size; col++)
					{
						x += matrix[row, col] * xList[col];
						
					}
					FreeXList.Add(x);
				}
				
				e = CountE(xList, FreeXList);
				xList.Clear();
				for(int i = 0; i < size; i++)
				{
					xList.Add(FreeXList[i]);
				}
				
			}
			Vector rez = new Vector(xList);

			return rez;
		}

		// вычисляет погрешность итерации
		private static double CountE(List<double> xList, List<double> freeXList)
		{
			double e = 0;

			for (int i = 0; i < xList.Count; i++)
			{
				e += Math.Abs(xList[i] - freeXList[i]);
				
			}
			
			return e;
		}
		
	}
}
