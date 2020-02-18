using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Graph
    {
        public Point[] Points { get; private set; }

        public Edge[] Edges { get; private set; }

        protected Edge GetEdge(Point a, Point b)
        {
            IEnumerable<Edge> edges = from reb in Edges
                                      where (reb.FirstPoint == a & reb.SecondPoint == b) || (reb.SecondPoint == a & reb.FirstPoint == b)
                                      select reb;

            if (edges.Count() > 1 || edges.Count() == 0)
            {
                throw new Exception("Couldn't find an edge between two points.");
            }
            else
            {
                return edges.First();
            }
        }

        protected bool CheckPointsNames()
        {
            for (int i = 0; i < this.Points.Length; i++)
            {
                for (int j = 0; j < this.Points.Length; j++)
                {
                    if (i != j && this.Points[i].Name == this.Points[j].Name)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
