namespace Ecom.API.Helper
{
    public class ResponseAPI
    {
        public ResponseAPI(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetMessageFromStatusCode(StatusCode);
        }
        private string GetMessageFromStatusCode(int statuscode)
        {
            return statuscode switch
            {
                200 => "Done",
                400 => "Bad Request",
                401 => "Unauthorized",
                404 => "Resource not found",
                500 => "Server error",
                _ => null,
            };
        }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
    }
}

