using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestFunctions
{
    internal class Program
    {
        static void Main(string[] args)
        {

             var x = count( new List<int>() { 2,1,3});

            //   var sum = SumSubarray(weight, false) - SumSubarray(weight, true);
            //return sum;
            Console.WriteLine("");


        }

        public static int SumSubarray(List<int> arr, bool min)
        {
            var sum = 0;
            var valueStack = new Stack<int>();
            var countStack = new Stack<int>();
            int curSum = 0;
            foreach (var curValue in arr)
            {
                int curCount = 1;
                while (valueStack.Count > 0)
                {
                    if (min && valueStack.Peek() < curValue)
                    {
                        break;
                    }
                    else if (!min && valueStack.Peek() > curValue)
                    {
                        break;
                    }


                    int value = valueStack.Pop();
                    int count = countStack.Pop();
                    curCount += count;
                    curSum -= value * count;
                }
                valueStack.Push(curValue);
                countStack.Push(curCount);
                curSum += curValue * curCount;
                sum += curSum;
            }
            return sum;
        }
        public static long count (List<int> ratings)
        {

            var count = 0;
            for(int i = 0; i < ratings.Count; i++)
            {
                count += 1;
                if(i != ratings.Count -1)
                {
                    var sumVar = 1;
                    for (int x = i +1; x < ratings.Count; x++)
                    {
                        var selectedRating = ratings[i]; var AfterIndex = (ratings[x]);
                        if (selectedRating == AfterIndex + sumVar)
                        {
                            count += 1;
                            sumVar += 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

            }
            return count;
            
        }


        public static int solution(string S, int[] C)
        {
            var result = 0;

            for(int i = 0; i < S.Length -1; i++)
            {
                if(S[i] == S[i+1])
                {
                    int cost = C[i] > C[i+1] ? C[i+1] : C[i]; 
                    result += cost;   
                } 

            }

            return result;

        }

        public static int solutionTree(Tree T)
        {
            var result=  GetVisibleNodes(T.l, T.r, T.x);
            return result +1;
        }


        public static int GetVisibleNodes (Tree LT  , Tree RT , int root)
        {

            var count = 0;

            if(LT != null)
            {
                if (LT.x >= root) { count += 1; };
                count += GetVisibleNodes(LT.l, LT.r,root);

            }

            if (RT != null)
            {
                if (RT.x >= root) { count += 1; };
                count += GetVisibleNodes(RT.l, RT.r, root);

            }

            return count;
        }

        public  class Tree
        {
            public int x;
            public Tree l;
            public Tree r;
        };
    }


}



