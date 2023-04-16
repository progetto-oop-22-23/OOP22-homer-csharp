namespace Homer
{
    /// <summary>
    /// This exception indicates that lower and upper boundary numbers were passed in
    /// an incorrect order.
    /// </summary>
    public class InvertedBoundsException : Exception
    {
        private static readonly string s_defaultMessage = "lower and upper bounds are inverted";

        /// <summary>
        /// Constructs an <see cref="InvertedBoundsException"/> with a default error message. 
        /// </summary>
        public InvertedBoundsException() : base(s_defaultMessage)
        {
        }

        /// <summary>
        /// Constructs an <see cref="InvertedBoundsException"/> with an error message.
        /// </summary>
        /// <param name="message">the error message.</param>
        public InvertedBoundsException(string? message) : base(message)
        {
        }
    }
}
