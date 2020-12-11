using System;
using System.Collections.Generic;
using System.Text;

namespace _1988285_LTDT_Project02
{
    class BELLMAN_FORD
    {

		const int maxValue = int.MaxValue;

		public int[] P;

		public int[] L;

		public void bellmanFord(int source,int target, GRAPH g)
		{
			// Buoc 1: Khoi tao
			int n = g.soDinh;
			P = new int[n];
			L = new int[n];
			for (int i = 0; i < L.Length; i++)
			{
				L[i] = maxValue;
			}
			L[source] = 0;
			//Buoc 2: tim L va P
			bool stop = false;
			int k = 0;
			while (!stop)
			{
				stop = true;
				k = k + 1;

				for (int i = 0; i < L.Length; i++)
				{
					for (int j = 0; j < L.Length; j++)
					{
						if (g.mtKe[i, j] != 0 && L[i] != maxValue)
						{

							if (L[j] > L[i] + g.mtKe[i, j])
							{
								//Console.WriteLine(i + " " + j + " " + g.mtKe[i, j]);
								L[j] = L[i] + g.mtKe[i, j];
								P[j] = i;
								stop = false;
							}
						}
					}
				}
			//kiem tra mach am cua do thi
				if (k > n)
				{
					if (stop == false)
						Console.WriteLine("Do thi co mach am");
					stop = true;
				}
				
			}
			viewPath(g, source, target, P, L);
		}

		public void viewPath(GRAPH g, int source, int target, int[] path, int[] weight)
		{
			
			
			for (int i = 0; i < g.soDinh; i++)
			{				
				int dinhDangXet = i;
				List<int> dsDinh = new List<int>();
				while (dinhDangXet != path[source])
				{
					
					dsDinh.Add(dinhDangXet);
					
					dinhDangXet = path[dinhDangXet];
				}
				
				
				if (weight[i] == maxValue)
				{
					Console.WriteLine($"khong co duong di tu { source} den {i}");
				}
				else
				{
					Console.Write($"Duong di ngan nhat tu {source} den {i}: ");
					Console.WriteLine(string.Join(" <- ", dsDinh));					
					Console.WriteLine($"Chi phi duong di ngan nhat: {weight[i]}");
				}
			}

		}
		//initial and run algorythm 
		public void RunModule(string filePath)
		{
			GRAPH g = new GRAPH();			
			g = g.docDoThi(filePath);
			//in do thi khao sat
			g.inDoThi(g);
			Console.Write("Dinh bat dau: ");			
			int source = int.Parse(Console.ReadLine());
			Console.Write("Dinh ket thuc: ");
			int target = int.Parse(Console.ReadLine());
			bellmanFord(source,target, g);
		}
	}

}
