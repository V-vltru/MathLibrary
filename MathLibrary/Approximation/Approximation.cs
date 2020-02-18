namespace Approximation
{
    using System;
    using System.Linq;

    /// <summary>
    /// Main approximation class.
    /// </summary>
    public class Approximation
    {
        /// <summary>
        /// Function table as array of points.
        /// </summary>
        private Point[] functionTable;

        /// <summary>
        /// X-offset for centralization.
        /// </summary>
        protected double DX { get; set; }

        /// <summary>
        /// Y-offset for centralization.
        /// </summary>
        protected double DY { get; set; }

        public Approximation(Point[] points)
        {
            this.FunctionTable = points;
        }

        public Approximation()
        {
        }

        /// <summary>
        /// Gets or sets the tabled function as an array of points.
        /// </summary>
        public Point[] FunctionTable
        {
            get { return functionTable; }
            set
            {
                bool hasDuplicate = value.Where(item => value.Count(s => s.X == item.X) > 1).Any();
                if (hasDuplicate)
                {
                    throw new Exception("Found duplicate arguments!");
                }

                this.functionTable = value.OrderBy(x => x.X).ToArray();
            }
        }

        /// <summary>
        /// Method is used to centralize coordinates of function.
        /// To cut the unnecessary volume from calculation. 
        /// </summary>
        protected void Centralize()
        {
            double centralX = (this.FunctionTable[this.FunctionTable.Length - 1].X - this.FunctionTable[0].X) / 2.0;

            double minY = this.FunctionTable.Min((item) => item.Y);
            double maxY = this.FunctionTable.Max((item) => item.Y);
            double centralY = (maxY - minY) / 2.0;

            double xCentral = this.FunctionTable[0].X + centralX;
            double yCentral = minY + centralY;

            foreach(Point point in this.FunctionTable)
            {
                point.X -= xCentral;
                point.Y -= yCentral;
            }

            this.DX = xCentral;
            this.DY = yCentral;
        }
    }
}
