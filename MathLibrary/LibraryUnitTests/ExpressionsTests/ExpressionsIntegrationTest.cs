namespace LibraryUnitTests.ExpressionsTests
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Expressions;
    using Expressions.Models;
    using System;
    using System.Globalization;
    using System.Xml;

    [TestClass]
    public class ExpressionsIntegrationTest
    {
        [TestMethod]
        [DeploymentItem("ExpressionsTests\\Resources\\TestCases.xml", "ExpressionsTests\\Resources")]
        public void IntegrationTest()
        {
            string fileName = "ExpressionsTests\\Resources\\TestCases.xml";
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);

            XmlNodeList testsList = xmlDocument.SelectNodes("Expressions/Expression");

            foreach (XmlNode test in testsList)
            {
                string id = test.Attributes["id"].Value;

                List<Variable> vars = new List<Variable>();
                XmlNodeList varsList = test.SelectNodes("Parameters/Parameter");

                foreach (XmlNode var in varsList)
                {
                    vars.Add(new Variable(var.Attributes["Name"].Value, double.Parse(var.Attributes["Value"].Value, CultureInfo.InvariantCulture.NumberFormat)));
                }

                string expression = test.SelectSingleNode("Value").InnerText;
                double result = double.Parse(test.SelectSingleNode("Result").InnerText, CultureInfo.InvariantCulture.NumberFormat);

                Expression exp = new Expression(expression, vars);

                Assert.AreEqual(result, exp.GetResultValue(vars), 0.01, string.Format("Iteration: {0}", id));
            }
        }
    }
}
