namespace LinearAlgebraicEquationsSystem
{
    public class IntermediateResult
    {
        private MatrixT<double> matrix;

        private double[] rightPart;

        public IntermediateResult(string description, MatrixT<double> matrix, double[] rightPart)
        {
            this.Description = description;
            this.Matrix = matrix;
        }

        public IntermediateResult()
        {
        }

        /// <summary>
        /// Gets or sets intermediate results description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the matrix of intermediate result.
        /// </summary>
        public MatrixT<double> Matrix
        {
            get { return this.matrix; }
            set
            {
                if (value != null)
                {
                    this.matrix = new MatrixT<double>(value.Rows, value.Columns);

                    for (int i = 0; i < value.Rows; i++)
                    {
                        for (int j = 0; j < value.Columns; j++)
                        {
                            this.matrix[i, j] = value[i, j];
                        }
                    }
                }
                else
                {
                    this.matrix = null;
                }
            }
        }

        /// <summary>
        /// Gets or sets the right part values for the current result.
        /// </summary>
        public double[] RightPart
        {
            get { return this.rightPart; }
            set
            {
                if (value != null)
                {
                    this.rightPart = new double[value.Length];
                    for (int i = 0; i < value.Length; i++)
                    {
                        this.rightPart[i] = value[i];
                    }
                }
                else
                {
                    this.rightPart = null;
                }
            }
        }
    }
}
