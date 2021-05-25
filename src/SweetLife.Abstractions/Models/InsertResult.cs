namespace SweetLife.Abstractions.Models
{
    public class InsertResult
    {
        public long Id { get; set; }

        public bool Success { get; set; }

        public string ErrorMessage { get; set; }
    }
}