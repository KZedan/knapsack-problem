using System;

namespace knapsack_problem
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] profits = new double[100];
            double[] weights = new double[100];
            double[] pbyw = new double[100];
            int[] items = new int[100];
            int[] result = new int[100];
            double temp, m, netProfit = 0;
            int temp1;
            int i, j, n, k = 0;
            try
            {
                Console.WriteLine("Enter number of elements\t:");
                n = int.Parse(Console.ReadLine());
                Console.WriteLine("Capacity of knapsack\t:");
                m = double.Parse(Console.ReadLine());
                for(i = 0; i < n; i++)
                {
                    items[i] = i;
                }
                for(i = 0; i < n; i++)
                {
                    Console.WriteLine("ITEM NUMBER " + i);
                    Console.WriteLine("Enter profit\t:");
                    profits[i] = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter weight\t:");
                    weights[i] = double.Parse(Console.ReadLine());
                    pbyw[i] = profits[i] / weights[i];
                }
                for(i = 0; i < n; i++)
                {
                    for(j = i + 1; j < n; j++)
                    {
                        if(pbyw[j] > pbyw[i])
                        {
                            temp = pbyw[j];
                            pbyw[j] = pbyw[i];
                            pbyw[i] = temp;
                            temp1 = items[i];
                            items[i] = items[j];
                            items[j] = temp1;
                            temp = weights[i];
                            weights[i] = weights[j];
                            weights[j] = temp;
                            temp = profits[i];
                            profits[i] = profits[j];
                            profits[j] = temp;
                        }
                    }
                }
                for(i = 0; i < n; i++)
                {
                    Console.WriteLine("Item number " + items[i] + "Profit " + profits[i]
                        + " Weight " + weights[i] + "profit/Weight\t:" + pbyw[i]);
                }
                Console.WriteLine("m = " + m.ToString());
                //Console.ReadKey();
                k = 0;
                while(weights[k] < m)
                {
                    result[k] = items[k];
                    m = m - weights[k];
                    netProfit = netProfit + profits[k];
                    k++;
                }
                netProfit = netProfit + ((m / weights[k]) * profits[k]);
                double fraction = (m / weights[k]);
                Console.WriteLine("Items selected");
                for(i = 0; i < k; i++)
                {
                    Console.WriteLine(result[i].ToString() + " ");
                }
                if(fraction != 0)
                {
                    Console.WriteLine("The fraction of " + k + " item selected " +
                        fraction);
                }
                Console.WriteLine("Profit " + netProfit);
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception " + e.ToString());
            }
            Console.ReadKey();
        }
    }
}
