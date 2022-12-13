namespace Marvel.Domain.Util
{
    public static class ExceptionExtensions
    {
        public static string GetInnerExceptions(this Exception ex, string msgs = "")
        {
            if (ex == null)
                throw new ArgumentNullException("ex");

            if (msgs == "")
                msgs = ex.Message;

            if (ex.InnerException != null)
                msgs += String.Format("\n InnerException : {0}", GetInnerExceptions(ex.InnerException));

            return msgs;
        }
    }
}
