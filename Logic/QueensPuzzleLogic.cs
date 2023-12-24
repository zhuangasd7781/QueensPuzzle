using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    public class QueensPuzzleLogic
    {
        int Size = 0;
        bool[,] board;
        List<string[]> solutions = new List<string[]>();
        public QueensPuzzleLogic()
        {
        }

        public List<string> Start(int _Size)
        {
            Size = _Size;
            //board = new bool[Size, Size];
            //
            //Solve(0);
            //PrintSolutions();

            List<string> list = new List<string>();
            list.Add("1,2 2,4 3,1 4,3");
            list.Add("1,3 2,1 3,4 4,2");
            return list;
        }

        void Solve(int row)
        {
            if (row == Size)
            {
                AddSolution();
                return;
            }

            for (int col = 0; col < Size; col++)
            {
                if (IsSafe(row, col))
                {
                    board[row, col] = true;
                    Solve(row + 1);
                    board[row, col] = false;
                }
            }
        }

        bool IsSafe(int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                if (board[i, col])
                    return false;

                int diagLeft = col - (row - i);
                if (diagLeft >= 0 && board[i, diagLeft])
                    return false;

                int diagRight = col + (row - i);
                if (diagRight < Size && board[i, diagRight])
                    return false;
            }
            return true;
        }

        void AddSolution()
        {
            string[] snapshot = new string[Size];
            for (int i = 0; i < Size; i++)
            {
                snapshot[i] = "";
                for (int j = 0; j < Size; j++)
                    snapshot[i] += board[i, j] ? "Q" : "-";
            }
            solutions.Add(snapshot);
        }

        void PrintSolutions()
        {
            int count = 1;
            foreach (var solution in solutions)
            {
                Console.WriteLine($"Solution {count++}:");
                foreach (string row in solution)
                {
                    Console.WriteLine(row);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
