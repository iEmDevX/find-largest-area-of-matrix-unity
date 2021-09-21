using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixProblem
{
    class Matrix
    {
        public List<MatrixValue> BiggestArea { get; private set; } = new List<MatrixValue>();
        private List<MatrixValue> AreaSet = new List<MatrixValue>();

        public int X { get; private set; }
        public int Y { get; private set; }

        private int[,] Tab;

        public Matrix(int x, int y)
        {
            if (x <= 0 || y <= 0)
                throw new System.ArgumentException("Invalid arguments");

            X = x;
            Y = y;

            Tab = new int[Y, X];
            for (int i = 0; i < X; ++i)
            {
                for (int j = 0; j < Y; ++j)
                {
                    Tab[j, i] = 0;
                }
            }
        }

        public Matrix(int[,] values)
        {
            if (values == null)
                throw new System.ArgumentException("Invalid arguments");

            X = values.GetLength(1);
            Y = values.GetLength(0);

            Tab = new int[Y, X];
            for (int i = 0; i < X; ++i)
            {
                for (int j = 0; j < Y; ++j)
                {
                    Tab[j, i] = values[j, i];
                }
            }
        }

        public int GetValue(int x, int y)
        {
            if (x < 0 || x >= X || y < 0 || y >= Y)
                throw new System.ArgumentException("Invalid arguments");

            return Tab[y, x];
        }

        public void Print()
        {
            for (int y = 0; y < Y; ++y)
            {
                if (y == 0 || y == Y - 1) Console.Write("[");
                else Console.Write("|");

                for (int x = 0; x < X; ++x)
                {
                    Console.Write("" + GetValue(x, y));
                    if (x < X - 1) Console.Write(" ");
                }

                if (y == 0 || y == Y - 1) Console.WriteLine("]");
                else Console.WriteLine("|");
            }
        }

        //find the biggest area (the area composed with the biggest number of elements)
        //return the number of elements from this area.
        public int FindCountElementOfBiggestArea()
        {
            int[,] tabClone = (int[,])Tab.Clone();
            int max = 0;

            AreaSet.Clear();
            BiggestArea.Clear();

            // loop area
            for (int y = 0; y < Y; ++y)
            {
                for (int x = 0; x < X; ++x)
                {
                    var count = GetCountConnectDirection(tabClone, y, x, Tab[y, x]);

                    // Keep Biggest Area
                    if (max < count)
                    {
                        BiggestArea.Clear();
                        AreaSet.ForEach(item => BiggestArea.Add(item));
                    }
                    else if (max == count)
                    {
                        AreaSet.ForEach(item => BiggestArea.Add(item));
                    }
                    AreaSet.Clear();

                    max = Math.Max(max, count);
                }
            }
            return max;
        }

        //  Count it like same in area
        private int GetCountConnectDirection(int[,] grid, int y, int x, int number)
        {
            if (y < 0 || y >= grid.GetLength(0) || x < 0 || x >= grid.GetLength(1) || grid[y, x] == -1 || grid[y, x] != number)
            {
                return 0;
            }

            AreaSet.Add(new MatrixValue( x, y ));
            grid[y, x] = -1;
            int count = 1;

            // Find Count Connect 4 direction
            count += GetCountConnectDirection(grid, y + 1, x, number);
            count += GetCountConnectDirection(grid, y - 1, x, number);
            count += GetCountConnectDirection(grid, y, x + 1, number);
            count += GetCountConnectDirection(grid, y, x - 1, number);
            return count;
        }

    }

    class MatrixValue
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public MatrixValue(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
