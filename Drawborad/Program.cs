using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawborad
{
    internal class Program
    {
        static int b_size = 4;
        static int[] qPosition = new int[2];
        //static List<string[]> solutions = new List<string[]>();
        static void Main(string[] args)
        {
            //回傳list 每個list有Q的座標

            QueensPuzzleLogic logic = new QueensPuzzleLogic();


            while (true)
            {
                Console.Write("請輸入棋盤大小: ");

                string input = Console.ReadLine();
                List<string> val = logic.Start(Convert.ToInt32(input));
                if (int.TryParse(input, out b_size) && b_size > 0)
                {
                    //Console.Write("請輸入要放置 'Q' 的座標（例如 2,2 2,3）: ");
                    int i = 1;
                    foreach (string v in val)
                    {
                        bool chk_xy_result = 檢查座標集合(v, out List<string[]> 皇后座標);
                        if (chk_xy_result)
                        {
                            Console.WriteLine($"解方 {i} :");
                            建置棋盤(b_size, 皇后座標);
                        }

                        Console.WriteLine();
                        i += 1;
                    }
                }
                else
                {
                    Console.WriteLine("請輸入有效的數字！");
                }
            }
        }
        static bool 檢查座標集合(string xy, out List<string[]> 皇后座標)
        {
            皇后座標 = new List<string[]>();
            string[] qPositions = xy.Split(' ');

            foreach (string p in qPositions)
            {
                string[] parts = p.Split(',');
                if (parts.Length == 2 && int.TryParse(parts[0], out int row) && int.TryParse(parts[1], out int col))
                {
                    if (row > 0 && row <= b_size && col > 0 && col <= b_size)
                    {
                        皇后座標.Add(parts);
                    }
                    else
                    {
                        Console.WriteLine($"無效座標: {p}");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine($"無法解析座標: {p}");
                    return false;

                }
            }
            return true;

        }
        static void 建置棋盤(int row, List<string[]> 皇后座標)
        {
            if (row == 0)
            {
                繪製頂部數字();
                return;
            }

            建置棋盤(row - 1, 皇后座標);
            繪製棋格與皇后(true, row, 皇后座標);
            繪製棋格與皇后(false, row, 皇后座標);

            if (row == b_size)
            {
                繪製棋格與皇后(true, row, 皇后座標);
            }
        }
        static void 繪製棋格與皇后(bool isEdge, int row, List<string[]> 皇后座標)
        {
            Console.Write(!isEdge ? $"{row} " : $"  ");

            for (int col = 1; col <= b_size; col++)
            {
                if (!isEdge)
                {
                    bool isQueenPlaced = false;
                    foreach (string[] p in 皇后座標)
                    {
                        int Q_Row = int.Parse(p[0]);
                        int Q_Col = int.Parse(p[1]);
                        if (row == Q_Row && col == Q_Col)
                        {
                            Console.Write("| Q ");
                            isQueenPlaced = true;
                            break;
                        }
                    }

                    if (!isQueenPlaced)
                    {
                        Console.Write("|   ");
                    }
                }
                else
                {
                    Console.Write("+---");
                }
            }
            Console.WriteLine(isEdge ? "+" : "|");
        }
        static void 繪製頂部數字()
        {
            Console.Write("  "); // 頂部數字的起始空格
            for (int i = 1; i <= b_size; i++)
            {
                Console.Write($"  {i} ");
            }
            Console.WriteLine();
        }
    }
}
