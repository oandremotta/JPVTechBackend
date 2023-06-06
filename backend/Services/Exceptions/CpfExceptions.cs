namespace backend.Services.Exceptions
{
    public class CpfExceptions
    {
        public class CpfInvalidoException : Exception
        {
            public CpfInvalidoException(string message) : base(message)
            {
            }
        }

        public class CpfDuplicadoException : Exception
        {
            public CpfDuplicadoException(string message) : base(message)
            {
            }
        }
    }
}
