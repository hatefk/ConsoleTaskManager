// See https://aka.ms/new-console-template for more information
using TaskManagerDemo.Services;
using TaskManagerDemo.ViewModels;
using TaskManagerDemo.Resources;

var taskViewModel = new TaskViewModel();

Display.Info(Strings.WelcomeMessage);

while (true)
{
    Display.Info(Strings.LineDivider);
    Display.Info(Strings.DisplayOptions);
    if (int.TryParse(Console.ReadLine(), out int choice))
    {
        switch (choice)
        {
            case 1:
                Display.Info(Strings.NewTaskPrompt);
                string description = Console.ReadLine();
                taskViewModel.AddTask(description);
                break;
            case 2:
                Display.Info(Strings.TaskCompletePrompt);
                string taskIdByUser = Console.ReadLine();
                var taskUpdateResult = taskViewModel.MarkTaskAsCompleted(taskIdByUser);
                if(taskUpdateResult.Succeeded)
                    Display.Info(taskUpdateResult.Message);
                else
                    Display.Error(taskUpdateResult.Message);
                break;
            case 3:
                Display.Info(Strings.TaskListTitle);
                taskViewModel.ListTasks();
                break;
            case 4:
                Environment.Exit(0);
                break;
            default:
                Display.Warning(Strings.InvalidOptionSelectionWarning);
                break;
        }
    }
    else
    {
        Display.Error(Strings.InvalidOptionsInputError);
    }
}