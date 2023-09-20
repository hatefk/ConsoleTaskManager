using TaskManagerDemo.Models;
using TaskManagerDemo.Services;
using System.Collections.ObjectModel;
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
            task.CompletedTimeStamp = DateTime.UtcNow;

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
            var taskStatusDisplay = task.IsCompleted ?  Strings.CompleteTaskIcon : Strings.OpenTaskIcon;
            var taskTimingDisplay = String.Empty;
            try
            {
                if (task.IsCompleted)
                {
                    var timeDiff = TimeHelper.GetTimeDifferenceInMinSec(DateTime.UtcNow, task.CompletedTimeStamp);
                    taskTimingDisplay = String.Format(Strings.CompleteTaskTimingFormat, timeDiff);
                }
                else
                {
                    var timeDiff = TimeHelper.GetTimeDifferenceInMinSec(DateTime.UtcNow, task.CreatedTimeStamp);
                    taskTimingDisplay = String.Format(Strings.OpenTaskTimingFormat, timeDiff); ;
                }
            }
            catch(Exception ex)
            {
                taskTimingDisplay = Strings.TaskTimingError;
                // In Real Life, we will not hit this exception at all because we control start and end time
                // However, If this happened, I would log this to a logging mechanism such as Sentry or CloudWatch..
                Display.Error(ex.Message);
            }
            return String.Format(Strings.TaskListItemFormat, task.Id, taskStatusDisplay, task.Description, taskTimingDisplay);
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
