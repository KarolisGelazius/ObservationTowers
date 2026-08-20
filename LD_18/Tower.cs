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
    /// Observation tower
    /// </summary>
    public class Tower
    {
        public int PosX { get; set; }   /// X coordinates
        public int PosY { get; set; }   /// Y coordinates

                                        /// <summary>
                                        /// Tower constructor
                                        /// </summary>
                                        /// <param name="posX">X coordinate</param>
                                        /// <param name="posY">Y coordinate</param>
        public Tower(int posX, int posY)
        {
            PosX = posX;
            PosY = posY;
        }
    }

    //public partial class Forma1 : System.Web.UI.Page
    //{

    //}
}