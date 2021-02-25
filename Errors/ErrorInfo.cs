using System.Text.Json;

namespace Tasks.API.Errors
{
    public class ErrorInfo
    {

        public ErrorInfo(int errorCode, string errorMessage, string errorTrace = null)
        {
            this.ErrorCode = errorCode;
            this.ErrorMessage = errorMessage;
            this.ErrorStackTrace = errorTrace;
        }

        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public string ErrorStackTrace { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}