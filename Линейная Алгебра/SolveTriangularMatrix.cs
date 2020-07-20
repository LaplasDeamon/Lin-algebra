using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Прямой_обратный
{
	class SolveTriangularMatrix
	{
		public static  Vector UP_STEP(Matrix A, Vector B)
		{
			int An = A.GetRow(), Am = A.GetRow(), BSize = B.GetSize();
			if (An != Am || An != BSize)
			{
				return null;
			}
			for (int i = An - 1; i >= 0; i--)
			{
				if (A[i, i] == 0)
					return null;
				for (int j = i - 1; j >= 0; j--)
				{
					if (A[i, j] != 0) return null;
				}

			}

			Vector X = new Vector(An);
			for (int i = 0; i < An; i++)
			{
				int m = An - i - 1;
				double s = 0;
				for (int j = m; j < An; j++)
				{
					s += A[m, j] * X[j];
				}
				X[m] = (B[m] - s) / A[m, m];
			}
			X[An - 1] = B[An - 1] / A[An - 1, An - 1];
			return X;
		}


	


		public static Vector   DOWN_STEP(Matrix a, Vector b)
		{
			int rows = a.GetRow();
			int columns = a.GetColoumn();

			if (columns != rows || rows != b.GetSize()) return null;
			for (int i = 0; i < rows; i++)
			{
				if (a[i, i] == 0) return null;
				for (int j = i + 1; j < rows; j++)
					if (a[i, j] != 0) return null;
			}
			Vector x = new Vector(rows);
			x[0] = b[0] / a[0, 0];
			for (int i = 1; i < rows; i++)
			{
				double s = 0;
				for (int k = 0; k < i; k++)
					s += a[i, k] * x[k];
				x[i] = (b[i] - s) / a[i, i];
			}

			return x;
		}
	}
	
}
