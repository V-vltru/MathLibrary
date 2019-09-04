namespace Expressions.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Main tree contains the expression.
    /// </summary>
    public class Tree
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tree" /> class.
        /// </summary>
        public Tree()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tree" /> class.
        /// </summary>
        /// <param name="data">The data of the tree</param>
        /// <param name="dataType">The type of data (Nothing, Number, Standard function, Operator)</param>
        /// <param name="leftOperand">The operand of LEFT sub tree</param>
        /// <param name="rightOperand">The operand of RIGHT sub tree</param>
        /// <param name="stringLeft">The string which is supposed to be sent to LEFT sub tree as 'Data' parameter</param>
        /// <param name="stringRight">The the string which is supposed to be sent to RIGHT sub tree as 'Data' parameter</param>
        public Tree(string data, EssenceType dataType, double leftOperand, double rightOperand, string stringLeft, string stringRight)
        {
            this.Data = data;
            this.DataType = dataType;
            this.LeftOperand = leftOperand;
            this.RightOperand = rightOperand;
            this.StringLeft = stringLeft;
            this.StringRight = stringRight;
        }

        #region Class properties

        /// <summary>
        /// Gets or sets the left sub tree
        /// </summary>
        public Tree LeftLeave { get; set; }

        /// <summary>
        /// Gets or sets the right sub tree
        /// </summary>
        public Tree RightLeave { get; set; }

        /// <summary>
        /// Gets or sets the tree cascade.
        /// </summary>
        public List<Tree> Cascade { get; set; }

        /// <summary>
        /// Gets or sets the operators for cascade units.
        /// </summary>
        public List<Operator> CascadeOperators { get; set; }

        /// <summary>
        /// Gets or sets the data of the tree
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Gets or sets the type of data (Nothing, Number, Standard function, Operator)
        /// </summary>
        public EssenceType DataType { get; set; }

        /// <summary>
        /// Gets or sets the operand of LEFT sub tree
        /// </summary>
        public double LeftOperand { get; set; }

        /// <summary>
        /// Gets or sets the operand of RIGHT sub tree
        /// </summary>
        public double RightOperand { get; set; }

        /// <summary>
        /// Gets or sets the string which is supposed to be sent to LEFT sub tree as 'Data' parameter 
        /// </summary>
        public string StringLeft { get; set; }

        /// <summary>
        /// Gets or sets the the string which is supposed to be sent to RIGHT sub tree as 'Data' parameter 
        /// </summary>
        public string StringRight { get; set; }

        #endregion
    }
}
