using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LD_18
{
        /// <summary>
        /// Contains all task logic methods
        /// </summary>
        public static class TaskUtils
        {
            /// <summary>
            /// Calculates total distance between original and moved tower positions
            /// </summary>
            /// <param name="original">Original tower list</param>
            /// <param name="moved">Moved tower list</param>
            /// <returns>Total number of moves</returns>
            public static int CountMovesBetween(List<Tower> original, List<Tower> moved)
            {
                int moves = 0;
                for (int i = 0; i < original.Count; i++)
                {
                    moves += Math.Abs(original[i].PosX - moved[i].PosX);
                    moves += Math.Abs(original[i].PosY - moved[i].PosY);
                }
                return moves;
            }

            /// <summary>
            /// Converts tower list into visual matrix string.
            /// </summary>
            /// <param name="towers">Tower list</param>
            /// <param name="gridSize">Grid size</param>
            /// <returns>Formatted matrix as string</returns>
            public static string MatrixToString(List<Tower> towers, int gridSize)
            {
                bool[,] grid = BuildGrid(towers, gridSize);
                return GridToString(grid, gridSize);
            }

            /// <summary>
            /// Moves towers so that no two towers share the same row or column
            /// </summary>
            /// <param name="towers">Original towers</param>
            /// <returns>New list of moved towers</returns>
            public static List<Tower> MoveTowersToCorrectLocation(List<Tower> towers)
            {
                List<Tower> moved = new List<Tower>();
                Dictionary<int, bool> usedCols = new Dictionary<int, bool>();
                Dictionary<int, bool> usedRows = new Dictionary<int, bool>();

                Move(towers, moved, usedCols, usedRows, 0);

                return moved;
            }

            /// <summary>
            /// Recursive method that processes towers one by one and assigns free rows and columns
            /// </summary>
            /// <param name="towers">Tower list</param>
            /// <param name="moved">Moved tower list</param>
            /// <param name="usedCols">Collection of occupied columns</param>
            /// <param name="usedRows">Collection of occupied rows</param>
            /// <param name="index">starting index</param>
            private static void Move(List<Tower> towers, List<Tower> moved, Dictionary<int, bool> usedCols, Dictionary<int, bool> usedRows, int index)
            {
                if (index >= towers.Count)
                {
                    return; 
                }

                Tower tower = new Tower(towers[index].PosX, towers[index].PosY);

                tower.PosX = GetNextAvailable(tower.PosX, usedCols, towers.Count);
                tower.PosY = GetNextAvailable(tower.PosY, usedRows, towers.Count);

                moved.Add(tower);

                Move(towers, moved, usedCols, usedRows, index + 1);
            }

            /// <summary>
            /// Finds next available free position in dictionary.
            /// </summary>
            /// <param name="desired">Preferred position</param>
            /// <param name="used">Dictionary of used positions</param>
            /// <param name="count">Maximum size</param>
            /// <returns>Free position</returns>
            private static int GetNextAvailable(int desired, Dictionary<int, bool> used, int count)
            {
                if (!used.ContainsKey(desired))
                {
                    used[desired] = true;
                    return desired;
                }

                for (int i = 1; i <= count; i++)
                {
                    if (!used.ContainsKey(i))
                    {
                        used[i] = true;
                        return i;
                    }
                }

                return desired;
            }

            /// <summary>
            /// Builds boolean grid representation of towers
            /// </summary>
            /// <param name="towers">Tower list</param>
            /// <param name="gridSize">Grid size</param>
            /// <returns></returns>
            private static bool[,] BuildGrid(List<Tower> towers, int gridSize)
            {
                bool[,] grid = new bool[gridSize + 1, gridSize + 1];
                for (int i = 0; i < towers.Count; i++)
                {
                    grid[towers[i].PosX, towers[i].PosY] = true;
                }
                return grid;
            }

            /// <summary>
            /// Converts boolean grid into printable string.
            /// </summary>
            /// <param name="grid">Grid of empty spaces and towers</param>
            /// <param name="gridSize">Grid size</param>
            /// <returns>a string of towers and empty spaces</returns>
            private static string GridToString(bool[,] grid, int gridSize)
            {
                string result = "";
                for (int y = 1; y <= gridSize; y++)
                {
                    for (int x = 1; x <= gridSize; x++)
                    {
                        if (grid[x, y] == true)
                        {
                            result += "🗼 ";
                        }
                        else
                        {
                            result += "⬜ ";
                        }
                    }
                    result += "<br/>";
                }
                return result;
            }
        }
    //public partial class Forma1 : System.Web.UI.Page
    //{
    //}
}