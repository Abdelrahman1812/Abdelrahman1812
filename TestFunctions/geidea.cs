using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFunctions
{
    internal static class geidea
    {

        public static List<string> solution(int N, int[] R, int[] C)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            // var AllmatrixValues = getAllCells(N);
            var result = new List<string>();
            var BoombsCells = getBombCells(R, C);


            for (int i = 0; i < N; i++)
            {
                string RowResult = string.Empty;
                for (int x = 0; x < N; x++)
                {

                    var selectedCell = new MatrixCells() { Row = i, Col = x };
                    bool isBombCell = BoombsCells.Any(p => p.Col == selectedCell.Col && p.Row == selectedCell.Row);

                    if (isBombCell)
                    {
                        RowResult += 'B';
                    }
                    else
                    {
                        var neighboursCells = getNeigbourCells(i, x, N - 1, N - 1);
                        int numberofboombCells = 0;
                        foreach (var item in neighboursCells)
                        {
                            bool isEist = BoombsCells.Any(p => p.Col == item.Col && p.Row == item.Row);
                            if (isEist)
                            {
                                numberofboombCells += 1;
                            }
                        }
                        RowResult += numberofboombCells;
                    }
                }

                result.Add(RowResult);
            }

            return result;



        }


        public static List<MatrixCells> getBombCells(int[] R, int[] C)
        {
            var values = new List<MatrixCells>();
            for (int i = 0; i < R.Length; i++)
            {
                values.Add(new MatrixCells { Col = C[i], Row = R[i] });
            }

            return values;
        }

        public static List<MatrixCells> getNeigbourCells(int R, int C, int maxColNumber, int maxRowNumber)
        {
            var values = new List<MatrixCells>();
            for (int i = R - 1; i <= R + 1; i++)
            {
                if (i < 0 || i > maxRowNumber) continue;

                for (int x = C - 1; x <= C + 1; x++)
                {
                    if (x < 0 || x > maxColNumber) continue;

                    if (R == i && C == x) continue;
                    values.Add(new MatrixCells { Col = x, Row = i });

                }
            }

            return values;
        }

        public class MatrixCells
        {
            public int Col { get; set; }
            public int Row { get; set; }
        }
    }
}
