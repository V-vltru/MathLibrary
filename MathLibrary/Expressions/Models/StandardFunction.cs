namespace Expressions.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The model which represents standard function operating tools 
    /// </summary>
    public class StandardFunction
    {
        /// <summary>
        /// Dictionary which contains the explanation of each function
        /// </summary>
        private static readonly Dictionary<string, string> WellKnownFunctionsExplanation = new Dictionary<string, string>
        {
            { "sin", "Sinus(x)" },
            { "cos", "Cosinus(x)" },
            { "tan", "Tangens(x)" },
            { "log", "Log10(x)" },
            { "ln", "Ln(x) - natural logarithm" },
            { "exp", "e^(x)" }
        };

        /// <summary>
        /// Error message which will be printed when user attempts to specify 
        /// </summary>
        private static string errorMessage;

        /// <summary>
        /// Name of the standard function.
        /// </summary>
        private string name;

        /// <summary>
        /// Initializes static members of the <see cref="StandardFunction" /> class.
        /// Static constructor which specifies the the error message for the user.
        /// It shows the list of allowable parameters to help.
        /// </summary>
        static StandardFunction()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("The function %f% is not accessable. Here is the list of allowable functions:");

            foreach (string function in WellKnownFunctions)
            {
                stringBuilder.Append(string.Format("\n{0} - {1}", function, WellKnownFunctionsExplanation[function]));
            }

            errorMessage = stringBuilder.ToString();
        }

        /// <summary>
        /// Initializes static members of the <see cref="StandardFunction" /> class.
        /// Constructor sets the parameters of the class.
        /// </summary>
        /// <param name="index">Current index of standard function.</param>
        /// <param name="functionName">Name of the standard function.</param>
        public StandardFunction(int index, string functionName)
        {
            this.Index = index;
            this.Name = functionName;
        }

        /// <summary>
        /// Gets the list of allowed functions.
        /// </summary>
        public static List<string> WellKnownFunctions { get; } = new List<string>
        {
            "sin", "cos", "tan", "log", "ln", "exp"
        };

        /// <summary>
        /// Gets or sets the position of standard function in the expression
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Gets or sets the name of the function
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (WellKnownFunctions.Contains(value))
                {
                    this.name = value;
                }
                else
                {
                    throw new Exception(errorMessage.Replace("%f%", value));
                }
            }
        }

        /// <summary>
        /// Method which returns the result of the function 
        /// </summary>
        /// <param name="value">The parameter of the function</param>
        /// <param name="functionName">The name of the function</param>
        /// <returns>The result of the function</returns>
        public static double GetResultOfStandardFunction(double value, string functionName)
        {
            switch (functionName)
            {
                case "sin": return Math.Sin(value);
                case "cos": return Math.Cos(value);
                case "tan": return Math.Tan(value);
                case "log": return Math.Log10(value);
                case "ln": return Math.Log(value);
                case "exp": return Math.Exp(value);
                default: throw new Exception(errorMessage.Replace("%f%", functionName));
            }
        }
    }
}
