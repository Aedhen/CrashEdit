using System;

namespace Crash
{
    public class ErrorSignalEventArgs : EventArgs
    {
        public ErrorSignalEventArgs(string message)
        {
            Message = message;
            Response = ErrorResponse.Abort;
            CanSkip = false;
            CanIgnore = false;
        }

        public string Message { get; set; }
        public ErrorResponse Response { get; set; }
        public bool CanSkip { get; set; }
        public bool CanIgnore { get; set; }
    }
}
