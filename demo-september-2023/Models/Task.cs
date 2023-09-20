namespace TaskManagerDemo.Models
{
    internal class Task
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
        /// <summary>
        /// Task Created Timestamp in UTC
        /// </summary>
        public DateTime CreatedTimeStamp { get; set; } = DateTime.UtcNow;
        /// <summary>
        /// Task Completed Timestamp in UTC
        /// </summary>
        public DateTime CompletedTimeStamp { get; set; }

    }
}
