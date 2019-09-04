namespace Expressions.Models
{
    /// <summary>
    /// Types that undefined essence may have
    /// Nothing: undefined
    /// </summary>
    public enum EssenceType
    {
        /// <summary>
        /// Means that type is not defined.
        /// </summary>
        Nothing,

        /// <summary>
        /// Means that unit is number.
        /// </summary>
        Number,

        /// <summary>
        /// Means that unit is variable.
        /// </summary>
        Variable,

        /// <summary>
        /// Means that unit is standard function.
        /// </summary>
        StandardFunction,

        /// <summary>
        /// Means that unit is operator.
        /// </summary>
        Operator,

        /// <summary>
        /// Means that unit is cascade.
        /// </summary>
        Cascade
    }
}
