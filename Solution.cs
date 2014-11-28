using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    public class Position
    {
        public int x { get; set; }
        public int y { get; set; }
        public Position(int _x, int _y)
        {
            this.x = _x;
            this.y = _y;
        }
    }
    static void nextMove(int n, int r, int c, String[] grid)
    {
        String[,] realGrid = PopulateGrid(grid, n);
        Position princessPosition = FindPrincess(realGrid, n);
        Position hero = new Position(r, c);

        Console.Write(GetMove(princessPosition, hero));
    }
    public static String GetMove(Position princess, Position hero)
    {
        if (hero.x > princess.x)
        {
            return "UP";
        }
        else if (hero.x < princess.x)
        {
            return "DOWN";
        }
        else
        {
            if (hero.y > princess.y)
                return "LEFT";
            else
                return "RIGHT";
        }
    }
    static String[,] PopulateGrid(String[] grid, int n)
    {
        String[,] realGrid = new String[n, n];
        for (int x = 0; x < n; x++)
        {
            for (int y = 0; y < n; y++)
            {
                var row = grid[x].ToCharArray();
                realGrid[x, y] = row[y].ToString();
            }
        }
        return realGrid;
    }
    static Position FindPrincess(String[,] grid, int n)
    {
        for (int x = 0; x < n; x++)
        {
            for (int y = 0; y < n; y++)
            {
                var item = grid[x, y];
                if (item.ToLower().CompareTo("p") == 0)
                    return new Position(x, y);
            }
        }
        throw new Exception("Your Princess is in another castle!");
    }
    static void Main(String[] args)
    {
        int n;

        n = int.Parse(Console.ReadLine());
        String pos;
        pos = Console.ReadLine();
        String[] position = pos.Split(' ');
        int[] int_pos = new int[2];
        int_pos[0] = Convert.ToInt32(position[0]);
        int_pos[1] = Convert.ToInt32(position[1]);
        String[] grid = new String[n];
        for (int i = 0; i < n; i++)
        {
            grid[i] = Console.ReadLine();
        }

        nextMove(n, int_pos[0], int_pos[1], grid);

    }
}
