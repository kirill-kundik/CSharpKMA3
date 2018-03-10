using System;

namespace Lab3.Exceptions
{
    class FutureDateException : Exception
    {
        private string _message;
        private DateTime? _receivedDate;

        public FutureDateException(string message)
        {
            _message = message;
        }

        public FutureDateException(DateTime badDate)
        {
            _receivedDate = badDate;
            _message = $"Received date from future: {_receivedDate.ToString()}";
        }

        public FutureDateException(DateTime badDate, string message)
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
