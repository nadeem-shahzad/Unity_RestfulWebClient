using System.Collections.Generic;
namespace RestfulWebClient.Core.Models
{
    /// <summary>
    /// The Response class defines a data structure for handling HTTP responses in the associated code.
    /// It includes properties for the response status code (StatusCode), any error information (Error),
    /// the response data as a string (Data), and a dictionary of response headers (Headers).
    /// This class encapsulates essential information about an HTTP response for convenient processing and analysis in the codebase.
    /// </summary>
    public class Response
    {
        public long StatusCode { get; set; }
        public string Error { get; set; }
        public string Data { get; set; }
        public Dictionary<string, string> Headers { get; set; }
    }
}