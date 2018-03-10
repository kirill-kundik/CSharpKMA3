using System;

namespace Lab3.Exceptions
{
    class PastDateException : Exception
    {
        private string _message;
        private DateTime? _receivedDate;

        public PastDateException(string message)
        {
            _message = message;
        }

        public PastDateException(DateTime badDate)
        {
            _receivedDate = badDate;
            _message = $"Received date from further past: {_receivedDate.ToString()}";
        }

        public PastDateException(DateTime badDate, string message)
        {
            _receivedDate = badDate;
            _message = message;
        }

        public override string Message
        {
            get => _message;
        }
    }
}
