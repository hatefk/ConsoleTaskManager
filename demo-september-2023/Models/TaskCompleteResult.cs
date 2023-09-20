using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
