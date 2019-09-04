/// <summary>
/// Namespace contains all models which are operated by <see cref="Expressions.Expression" /> class.
/// </summary>
namespace Expressions.Models
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Entire struct represents the interval
    /// forbidden for the parses
    /// </summary>
    public class Interval
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Interval" /> class.
        /// [indexStart; indexEnd]
        /// </summary>
        /// <param name="indexFrom">The start index of the interval</param>
        /// <param name="indexTo">The end index of the interval</param>
        public Interval(int indexFrom, int indexTo)
        {
            this.IndexFrom = indexFrom;
            this.IndexTo = indexTo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Interval" /> class.
        /// </summary>
        /// <param name="interval">Instance of the interval which will be copied to the current one</param>
        public Interval(Interval interval)
        {
            this.IndexFrom = interval.IndexFrom;
            this.IndexTo = interval.IndexTo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Interval" /> class.
        /// Default constructor
        /// </summary>
        public Interval()
        {
        }

        /// <summary>
        /// Gets or sets the start index of the interval
        /// </summary>
        public int IndexFrom { get; set; }

        /// <summary>
        /// Gets or sets the end index of the interval
        /// </summary>
        public int IndexTo { get; set; }

        /// <summary>
        /// Method defines whether the specified index belongs to at least one interval from the list of them
        /// </summary>
        /// <param name="currentIndex">Index (position in string) to define if it belongs to intervals</param>
        /// <param name="intervals">List of the intervals</param>
        /// <returns>the flag: true - belongs to at least one interval; false - does not belong to any of the intervals</returns>
        public static bool BelongsToIntevals(int currentIndex, List<Interval> intervals)
        {
            int indexInIntervalsCount = (from g in intervals
                                         where currentIndex >= g.IndexFrom && currentIndex <= g.IndexTo
                                         select g).Count();

            if (indexInIntervalsCount == 0)
            {
                return false;
            }

            return true;
        }
    }
}
