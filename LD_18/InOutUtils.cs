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
        public partial class Forma1 : System.Web.UI.Page
        {
            public static class InOutUtils
            {
                /// <summary>
                /// Reads the tower starting positions
                /// </summary>
                /// <param name="path">input file path</param>
                /// <returns>a list of every tower</returns>
                public static List<Tower> ReadTowers(string path)
                {
                    string[] lines = File.ReadAllLines(path);

                    List<int> xPos = lines[1].Split(' ').Select(int.Parse).ToList();
                    List<int> yPos = lines[2].Split(' ').Select(int.Parse).ToList();

                    List<Tower> towers = new List<Tower>();
                    for (int i = 0; i < xPos.Count; i++)
                    {
                        towers.Add(new Tower(xPos[i], yPos[i]));
                    }

                    return towers;
                }

                /// <summary>
                /// Reads the grids size
                /// </summary>
                /// <param name="path">input file path</param>
                /// <returns>the grid size</returns>
                public static int ReadGridSize(string path)
                {
                    string[] lines = File.ReadAllLines(path);

                    return int.Parse(lines[0]);
                }

                /// <summary>
                /// Prints results to file.
                /// </summary>
                /// <param name="path">File path</param>
                /// <param name="original">Original towers</param>
                /// <param name="moved">Moved towers</param>
                /// <param name="gridSize">Grid size</param>
                /// <param name="moves">Move count</param>
                public static void Print(string path, List<Tower> original, List<Tower> moved, int gridSize, int moves)
                {
                    string result = "";

                    result += "Pradinės apžvalgos bokštų pozicijos:\n";
                    result += TaskUtils.MatrixToString(original, gridSize).Replace("<br/>", "\n");
                    result += "\n";

                    result += "Minimalus perkėlimų skaičius: " + moves + "\n\n";

                    result += "Perkeltos apžvalgos bokštų pozicijos:\n";
                    result += TaskUtils.MatrixToString(moved, gridSize).Replace("<br/>", "\n");

                    File.WriteAllText(path, result);
                }
            }
        }
    }
