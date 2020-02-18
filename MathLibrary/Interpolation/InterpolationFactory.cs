namespace Interpolation
{
    using System;

    public static class InterpolationFactory
    {
        /// <summary>
        /// Gets interpolation method instance.
        /// </summary>
        /// <param name="type">Interpolation method.</param>
        /// <param name="points">The list of points as a table function.</param>
        /// <returns>Interpolation instance.</returns>
        public static Interpolation GetInterpolationProvider(InterpolationType type, Point[] points)
        {
            switch(type)
            {
                case InterpolationType.Lagrange: return new Lagrange(points);
                case InterpolationType.CubicSpline: return new CubicSpline(points);
                case InterpolationType.Line: return new Line(points);
                case InterpolationType.Newton: return new Newton(points);
                case InterpolationType.CanonicalPolynomial: return new CanonicalPolynomial(points);
                default: throw new ArgumentException("Interpolation type is not specified.");
            }
        }
    }
}
