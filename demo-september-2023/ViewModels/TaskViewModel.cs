using TaskManagerDemo.Models;
using TaskManagerDemo.services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = TaskManagerDemo.Models.Task;
using TaskManagerDemo.Resources;

namespace TaskManagerDemo.ViewModels
{
    internal class TaskViewModel
    {
        public ObservableCollection<Task> Tasks { get; } = new ObservableCollection<Task>();

        public void AddTask(string description)
        {
            var id = NextId();
            Tasks.Add(new Task { Id = id, Description = description });
        }

        public TaskCompleteResult MarkTaskAsCompleted(string idFromUser)
        {
            string result = string.Empty;
            if (!Int32.TryParse(idFromUser, out int taskId))
            {
                return new TaskCompleteResult(false, Strings.InvalidOptionsInputError);
            }

            var task = Tasks.FirstOrDefault(t => t.Id == taskId);

            if (task == null)
            {
                return new TaskCompleteResult(false, Strings.InvalidOptionSelectionWarning);
            }

            task.IsCompleted = true;

            return new TaskCompleteResult(true, String.Format(Strings.TaskCompleteMessageFormat, task.Description));
        }

        public void ListTasks(bool showCompleted = true)
        {
            foreach (var task in Tasks)
            {
                if (showCompleted || !task.IsCompleted)
                {
                    Display.Info(GetAsListItem(task));
                }
            }
        }

        private string GetAsListItem(Task task)
        {
            var taskStatusDisplay = task.IsCompleted ? "[X]" : "[ ]";
            return String.Format(Strings.TaskListItemFormat, task.Id, taskStatusDisplay, task.Description);
        }

        private int NextId()
        {
            if(Tasks == null || Tasks.Count == 0)
            {
                return 1;
            }
            var latestTaskId = Tasks.OrderByDescending(t => t.Id).FirstOrDefault().Id;
            return latestTaskId + 1;
        }
    }
}
