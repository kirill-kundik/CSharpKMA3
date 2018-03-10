using System;

namespace Lab3.Exceptions
{
    class IllegalEmailException : Exception
    {
        private string _message;

        public IllegalEmailException(string message)
        {
            _message = $"Received incorrect email address: {message}";
        }

        public override string Message
        {
            get => _message;
        }
    }
}
