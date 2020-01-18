using System;
using System.Collections.Generic;
using System.Xml;
using Interpolation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InterpolationUnitTests
{
    [TestClass]
    [DeploymentItem("InterpolationUnitTests\\Resources\\Points.xml", "InterpolationUnitTests\\Resources")]
    public class NewtonTest
    {
        public Point[] Points { get; }

        public double LeftX { get; }

        public double RightX { get; }

        public double MiddleX { get; }

        public double MiddleXLeft { get; }

        public double MiddleXRight { get; }

        public NewtonTest()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("InterpolationUnitTests\\Resources\\Points.xml");

            XmlNodeList pointsNodes = xmlDocument.SelectNodes("Points/Point");

            this.Points = new Point[pointsNodes.Count];
            for (int i = 0; i < pointsNodes.Count; i++)
            {
                this.Points[i] = new Point
                {
                    X = double.Parse(pointsNodes[i].Attributes["x"].Value),
                    Y = double.Parse(pointsNodes[i].Attributes["y"].Value)
                };
            }

            this.LeftX = -12;
            this.RightX = 13;
            this.MiddleX = 0.1;
            this.MiddleXLeft = -8.1;
            this.MiddleXRight = 8.1;
        }

        [TestMethod]
        public void SetNextIndexesTest()
        {
            Newton newton = new Newton(this.Points);
            int actualLeft, actualRight;

            // left case
            int expectedLeftIndex = -1;
            int expectedRightIndex = 0;
            newton.SetNextIndexes(out actualLeft, out actualRight, this.LeftX);
            Assert.AreEqual(expectedLeftIndex, actualLeft);
            Assert.AreEqual(expectedRightIndex, actualRight);

            // right case
            expectedLeftIndex = this.Points.Length - 1;
            expectedRightIndex = -1;
            newton.SetNextIndexes(out actualLeft, out actualRight, this.RightX);
            Assert.AreEqual(expectedLeftIndex, actualLeft);
            Assert.AreEqual(expectedRightIndex, actualRight);

            // middle case
            expectedLeftIndex = 20;
            expectedRightIndex = 21;
            newton.SetNextIndexes(out actualLeft, out actualRight, this.MiddleX);
            Assert.AreEqual(expectedLeftIndex, actualLeft);
            Assert.AreEqual(expectedRightIndex, actualRight);
        }

        [TestMethod]
        public void GetPointsAround()
        {
            int MaxDotsInArea = 20;
            List<Point> expectedPointsForLeft = new List<Point>();
            for (int i = 0; i < MaxDotsInArea; i++)
            {
                expectedPointsForLeft.Add(this.Points[i]);
            }

            Newton newton = new Newton(this.Points);
            List<Point> actualCollection = newton.GetPointsAround(this.LeftX, MaxDotsInArea);
            this.AssertPoints(expectedPointsForLeft, actualCollection);

            // right checking
            List<Point> expectedPointsForRight = new List<Point>();
            for (int i = 21; i < this.Points.Length; i++)
            {
                expectedPointsForRight.Add(this.Points[i]);
            }

            newton = new Newton(this.Points);
            actualCollection = newton.GetPointsAround(this.RightX, MaxDotsInArea);
            this.AssertPoints(expectedPointsForRight, actualCollection);

            // middle checking
            List<Point> expectedpointsForMiddle = new List<Point>();
            for (int i = 11; i <= 30; i++)
            {
                expectedpointsForMiddle.Add(this.Points[i]);
            }

            newton = new Newton(this.Points);
            actualCollection = newton.GetPointsAround(this.MiddleX, MaxDotsInArea);
            this.AssertPoints(expectedpointsForMiddle, actualCollection);

            // middle left checking
            List<Point> expectedPointsForLeftMiddle = new List<Point>();
            for (int i = 0; i < MaxDotsInArea; i++)
            {
                expectedPointsForLeftMiddle.Add(this.Points[i]);
            }

            actualCollection = newton.GetPointsAround(this.MiddleXLeft, MaxDotsInArea);
            this.AssertPoints(expectedPointsForLeftMiddle, actualCollection);

            List<Point> expectedpointsForRightMiddle = new List<Point>();
            for (int i = 21; i < this.Points.Length; i++)
            {
                expectedpointsForRightMiddle.Add(this.Points[i]);
            }

            actualCollection = newton.GetPointsAround(this.MiddleXRight, MaxDotsInArea);
            this.AssertPoints(expectedpointsForRightMiddle, actualCollection);
        }

        [TestMethod]
        public void TestMethod1()
        {
            //Point[] points = new Point[5];
            //points[0] = new Point(0, 1000);
            ////points[0].X = 0; points[0].Y = 1000;
            //points[1] = new Point(25, 997);
            ////points[1].X = 25; points[1].Y = 997;
            //points[2] = new Point(50, 988);
            ////points[2].X = 50; points[2].Y = 988;
            //points[3] = new Point(75, 975);
            ////points[3].X = 75; points[2].Y = 975;
            //points[4] = new Point(100, 960);
            ////points[4].X = 100; points[2].Y = 960;

            //Newton newton = new Newton(points);

            //double result = checked(newton.GetInterpolatedValue(12));

            //Assert.AreEqual(999.35, result, 0.01);
        }

        private void AssertPoints(List<Point> expectedPoints, List<Point> actualPoints)
        {
            if (expectedPoints.Count != actualPoints.Count)
            {
                throw new Exception("Lists capacities are not equal!");
            }

            for (int i = 0; i < expectedPoints.Count; i++)
            {
                Assert.AreEqual(expectedPoints[i].X, actualPoints[i].X);
                Assert.AreEqual(expectedPoints[i].Y, actualPoints[i].Y);
            }
        }
    }
}
