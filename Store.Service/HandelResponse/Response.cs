using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.HandelResponse
{
    public class Response
    {
        public int StatusCode { get; set; }

        public string ?Message { get; set; }

        public Response(int statusCode, string? message=null)
        {
            StatusCode = statusCode;
            Message = GetDefaultMessageForStatutsCode(statusCode);
        }

        private string GetDefaultMessageForStatutsCode(int statusCode)
        {
            return statusCode switch
            {
                100 => "100 Continue",
                101 => "101 Switching Protocols",

                // 2xx: Success
                200 => "200 OK",
                201 => "201 Created",
                202 => "202 Accepted",
                204 => "204 No Content",

                // 3xx: Redirection
                301 => "301 Moved Permanently",
                302 => "302 Found",
                304 => "304 Not Modified",

                // 4xx: Client Error
                400 => "400 Bad Request",
                401 => "401 Unauthorized",
                403 => "403 Forbidden",
                404 => "404 Not Found",

                // 5xx: Server Error
                500 => "500 Internal Server Error",
                502 => "502 Bad Gateway",
                503 => "503 Service Unavailable",

                // Default case for unknown status codes
                _ => $"Unknown Status Code: {statusCode}"
            }; 
          
        }


    }
}
