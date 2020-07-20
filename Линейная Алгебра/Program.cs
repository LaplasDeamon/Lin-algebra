using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Прямой_обратный
{
	class Program
	{
		static void Main(string[] args)
		{
			double[,] data = new double[3, 3]
			{
				{1,0,1},
				{5,2,0},
				{1,1,1}
			};


			double[] a = new double[3] { 0, 1, 2};
			double[] b = new double[3] { 5, 6, 0};
			double[] c = new double[3] { 4, 8, 9 };


			double[] d = new double[3] {2,2.5,11 };

			Vector aa = new Vector(a);
			Vector bb = new Vector(b);
			Vector cc = new Vector(c);
			Vector dd = new Vector(d);


			Matrix matrix = new Matrix(3,3,data);
			double[,] data1 = new double[3, 3]
			{
				{10,2,-1},
				{-2,-6,-1},
				{1,-3,12}
			};


			double[] b1 = new double[3] {5, 24.42, 36};
			Vector bb1 = new Vector(b1);


			Matrix matrix1 = new Matrix(3,3,data1);
			//Console.WriteLine(Gauss.GaussMethod(matrix,bb));
			Console.WriteLine(SimpleInterations.ApproximationMethod(matrix1,bb1,0.01));
			Console.ReadKey();
		}
	}
}
