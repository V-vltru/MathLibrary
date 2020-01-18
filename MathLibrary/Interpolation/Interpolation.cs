namespace Interpolation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Interpolation
    {
        private Point[] functionTable { get; set; }

        public Interpolation(IEnumerable<Point> functionTable)
        {
            this.FunctionTable = functionTable.ToArray();
        }

        public Interpolation()
        {
        }

        public Point[] FunctionTable
        {
            get
            {
                return this.functionTable;
            }
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

        public abstract double GetInterpolatedValue(double argument);

        public void SetNextIndexes(out int leftIndex, out int rightIndex, double x)
        {
            leftIndex = -1;
            rightIndex = -1;
            if (x < this.FunctionTable[0].X)
            {
                rightIndex = 0;
            }
            else if (x > this.FunctionTable[this.FunctionTable.Length - 1].X)
            {
                leftIndex = this.FunctionTable.Length - 1;
            }
            else
            {
                for (int i = 0; i < this.FunctionTable.Length - 2; i++)
                {
                    if (x > this.FunctionTable[i].X && x < this.FunctionTable[i + 1].X)
                    {
                        leftIndex = i;
                        rightIndex = i + 1;
                        break;
                    }
                }
            }
        }

        public List<Point> GetPointsAround(double x, int MaxDotsInArea)
        {
            List<Point> result = new List<Point>();
            int nextIndex, prevIndex;
            this.SetNextIndexes(out prevIndex, out nextIndex, x);

            // if x is outside the left border
            if (prevIndex < 0 && nextIndex == 0)
            {
                for (int i = 0; i < MaxDotsInArea; i++)
                {
                    result.Add(this.FunctionTable[i]);
                }
            } // if x is outside the right border
            else if (prevIndex == this.FunctionTable.Length - 1 && nextIndex < 0)
            {
                for (int i = this.FunctionTable.Length - MaxDotsInArea; i < this.FunctionTable.Length; i++)
                {
                    result.Add(this.FunctionTable[i]);
                }
            }
            else // otherwise, the point is located inside two borders
            {
                int expectedNextValues = MaxDotsInArea / 2;
                int expectedPrevValues = MaxDotsInArea / 2;

                int startIndex = -1;
                int endIndex = -1;
                if (prevIndex - expectedPrevValues + 1 < 0)
                {
                    startIndex = 0;
                }

                if (nextIndex + expectedNextValues - 1 > this.FunctionTable.Length - 1)
                {
                    endIndex = this.FunctionTable.Length - 1;
                }

                int loopParFrom, loopParTo;

                if (startIndex == 0)
                {
                    loopParFrom = startIndex;
                    loopParTo = MaxDotsInArea - 1;
                }
                else if (endIndex == this.FunctionTable.Length - 1)
                {
                    loopParFrom = this.FunctionTable.Length - MaxDotsInArea;
                    loopParTo = this.FunctionTable.Length - 1;
                }
                else
                {
                    loopParFrom = prevIndex - MaxDotsInArea / 2 + 1;
                    loopParTo = nextIndex + MaxDotsInArea / 2 - 1;
                }

                for (int i = loopParFrom; i <= loopParTo; i++)
                {
                    result.Add(this.FunctionTable[i]);
                }
            }

            return result;
        }

        public double GetStep(List<Point> points)
        {
            return (points[points.Count - 1].X - points[0].X) / points.Count;
        }
    }
}
