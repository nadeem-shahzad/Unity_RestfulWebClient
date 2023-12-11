namespace RestfulWebClient.Core.Models
{
    
    /// <summary>
    /// The RequestHeader abstract class provides a blueprint for representing HTTP request headers in the associated code.
    /// It includes properties for the header key (Key) and its corresponding value (Value).
    /// This class serves as a base structure for creating specific header instances,
    /// facilitating the organization and customization of headers for HTTP requests.
    /// </summary>
    public class RequestHeader
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
