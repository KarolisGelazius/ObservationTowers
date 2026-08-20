using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LD_18
{
    public partial class Forma1 : System.Web.UI.Page
    {
        /// <summary>
        /// Page load event method.
        /// </summary>
        /// <param name="sender">The source of the event (page object)</param>
        /// <param name="e">Event arguments containing event data</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/App_Data/U3.txt");
            List<Tower> towers = InOutUtils.ReadTowers(path);
            int gridSize = InOutUtils.ReadGridSize(path);
            Label2.Text = TaskUtils.MatrixToString(towers, gridSize);
        }

        /// <summary>
        /// Button1 press event method
        /// </summary>
        /// <param name="sender">The source of the event (button object)</param>
        /// <param name="e">Event arguments containing event data</param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/App_Data/U3.txt");
            int gridSize = InOutUtils.ReadGridSize(path);
            List<Tower> towers = InOutUtils.ReadTowers(path);

            List<Tower> moved = TaskUtils.MoveTowersToCorrectLocation(towers);

            int moves = TaskUtils.CountMovesBetween(towers, moved);

            Label1.Text = "Minimalus perkėlimų skaičius: " + moves;
            Label3.Text = TaskUtils.MatrixToString(moved, gridSize);
            Label5.Text = "Perkeltos apžvalgos bokštų pozicijos:";
            string resultPath = Server.MapPath("~/App_Data/Rezultatai.txt");
            InOutUtils.Print(resultPath, towers, moved, gridSize, moves);
        }
    }
}