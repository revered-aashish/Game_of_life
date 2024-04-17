namespace GameOfLife_CodeInput
{
    internal class Program
    {
        static int cntLiveNeighbour(int[,] grid, int i, int j, int M, int N)
        {
            int[] di = { -1, -1, 0, 1, 1, 1, 0, -1 };
            int[] dj = { 0, 1, 1, 1, 0, -1, -1, -1 };

            int live = 0;

            for (int ind = 0; ind < 8; ind++)
            {
                int ni = i + di[ind];
                int nj = j + dj[ind];

                if (ni >= 0 && ni < M && nj >= 0 && nj < N)
                {
                    if (grid[ni, nj] == 1)
                    {
                        live++;
                    }
                }
            }
            return live;
        }
        static int[,] nextGeneration(int[,] grid,
                              int M, int N)
        {
            int[,] next = new int[M, N];

            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {


                    int liveNeighbours = cntLiveNeighbour(grid, i, j, M, N);

                    next[i, j] = grid[i, j];


                    if (grid[i, j] == 1 && liveNeighbours < 2)
                        next[i, j] = 0;

                    else if (grid[i, j] == 1 && liveNeighbours > 3)
                        next[i, j] = 0;

                    else if (grid[i, j] == 0 && liveNeighbours == 3)
                        next[i, j] = 1;

          
                }
            }

            return next;


        }
        static void print(int[,] grid, int m, int n)
        {
            //  0 -> .
            //  1 -> *

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i, j] == 0)
                        Console.Write("." + " ");
                    else
                        Console.Write("*" + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            //   Console.WriteLine("Hello, World!");
            int m = 10, n = 10;

            // Initializing the grid.
            int[,] grid = {
            { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 1, 1, 1, 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0, 0, 1, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 1, 1, 1, 0, 1, 0, 0, 0 },
            { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 }
        };



            Console.WriteLine("Current Scenario");
            print(grid, m, n);





            int[,] newArr = nextGeneration(grid, m, n);
            Console.WriteLine("Next Scenario");
            print(newArr, m, n);



        }

    }
}
