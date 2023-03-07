namespace NetCoreWebApi.Models
{
    public class ErrorCode
    {
        public bool Succes { get; set; }
        public string Message { get; set; }
        public User Result { get; set; }
    }
}
