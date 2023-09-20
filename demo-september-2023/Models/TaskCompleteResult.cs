namespace TaskManagerDemo.Models
{
    public class TaskCompleteResult
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }

        public TaskCompleteResult(bool succeeded, string message)
        {
            Succeeded = succeeded;
            Message = message;
        }
    }
}
