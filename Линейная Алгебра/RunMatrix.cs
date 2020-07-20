using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Прямой_обратный
{
	class RunMatrix
	{

		/**
	 * n - число уравнений (строк матрицы)
	 * b - диагональ, лежащая над главной (нумеруется: [0;n-2])
	 * c - главная диагональ матрицы A (нумеруется: [0;n-1])
	 * a - диагональ, лежащая под главной (нумеруется: [1;n-1])
	 * f - правая часть (столбец)
	 * x - решение, массив x будет содержать ответ
	 */

		public static Vector  solveMatrix( Vector a, Vector c, Vector b, Vector f)
		{
			
			int n = a.GetLen();
			Vector x = new Vector(n);
			double m;
			for (int i = 1; i < n; i++)
			{
				m = a[i] / c[i - 1];
				c[i] = c[i] - m * b[i - 1];
				f[i] = f[i] - m * f[i - 1];
			}

			x[n - 1] = f[n - 1] / c[n - 1];

			for (int i = n - 2; i >= 0; i--)
			{
				x[i] = (f[i] - b[i] * x[i + 1]) / c[i];
			}
			return x;
		}
		

	}
}
