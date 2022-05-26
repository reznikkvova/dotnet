using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks.Dataflow;
using System.Collections.Generic;
using static System.Console;

namespace lab7 {
    internal class Program {
         public static int[][] GenerateMatrix(int n, int m)  {
             Random random = new Random();
             int[][] matrix = new int[n][];

             for (int i = 0; i < n; i++) {
                 matrix[i] = new int[m];
                 for (int j = 0; j < m; j++){
                     matrix[i][j] = random.Next(-100, 100);
                 }
             }
             return matrix;
         }
        
         public static void Main(string[] args) {
              int RowsNfirst = -1;
              int ColumnsNfirst = -1;
              int RowsNsecond = -2;
              int ColumnsNsecond = -2;
              WriteLine("Кількість рядків - стовпців першої матриці через кому");
              string[] firstDimension = ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);
              WriteLine("Кількість рядків - стовпців другої матриці через кому");
              string[] secondDimension = ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);
              try {
                   RowsNfirst = Convert.ToInt32(firstDimension[0]);
                   ColumnsNfirst = Convert.ToInt32(firstDimension[1]);
                   RowsNsecond = Convert.ToInt32(secondDimension[0]);
                   ColumnsNsecond = Convert.ToInt32(secondDimension[1]);
                if (ColumnsNfirst == RowsNsecond) {
                    int[][] firstMatrix = GenerateMatrix(RowsNfirst, ColumnsNfirst);
                    int[][] secondMatrix = GenerateMatrix(RowsNsecond, ColumnsNsecond);
                    WriteLine("Another result");
                    for (int i = 0; i < RowsNfirst; i++) {
                        for (int j = 0; j < ColumnsNsecond; j++) {
                            int sum = 0;
                            for (int k = 0; k < ColumnsNfirst; k++) {
                                sum += firstMatrix[i][k] * secondMatrix[k][j];
                            }
                            WriteLine(sum);
                        }
                    }
                    var bufferBlock = new BufferBlock<int[][]>();
                    for (int i = 0; i < RowsNfirst; i++){
                        for (int k = 0; k < ColumnsNsecond; k++) {
                            int[][] data = new int[2][];
                            data[0] = firstMatrix[i];
                            data[1] = new int[RowsNsecond];
                            for (int j = 0; j < RowsNsecond; j++) {
                                    data[1][j] = secondMatrix[j][k];
                            }
                            bufferBlock.Post(data);
                        }
                    }
                    var actionBlock = new ActionBlock<int[][]>(n =>  {
                        int sum = 0;
                        WriteLine("IN BLOCK");
                        for(int i=0; i < RowsNsecond; i++) {
                            sum += n[0][i] * n[1][i];
                        }
                        WriteLine("SUM " + sum);
                    });  
                     for(int i=0; i <= RowsNfirst * ColumnsNsecond; i++){
                        actionBlock.Post(bufferBlock.Receive());
                    }
                } else {
                      WriteLine("Матриці перемножити не можна, так як кількість стовпців першої не дорівнює кількості рядків другої матриці");
                  }
              } catch(Exception e) {
                  WriteLine($"Error\n{e}\n");
              }     
        }
       
    }

}