namespace TaskManagerDemo.Resources
{
    public static class Strings
    {
        public static string WelcomeMessage = "\nTask Management Console App";
        public static string LineDivider = "--------------------";
        public static string DisplayOptions = $"Please choose one of the following: {Environment.NewLine} " +
            $"1. Add Task \t 2. Mark Task as Completed " +
            $"3. List Tasks \t 4. Exit. {Environment.NewLine} " +
            $"Enter Your Choice (Number 1~4)";
        public static string NewTaskPrompt = "Enter task description: ";
        public static string TaskCompletePrompt = "Enter task title to mark as completed: ";
        public static string TaskListTitle = "Tasks:";
        public static string InvalidOptionSelectionWarning = "Invalid choice. Please try again.";
        public static string InvalidOptionsInputError = "Invalid input. Please enter a number corresponding to your choice.";
        public static string TaskCompleteMessageFormat = "Congrats on Finishing: {0}!";
        public static string TaskListItemFormat = "{0}: {1} {2}. {3}";
        public static string CompleteTaskTimingFormat = "[Completed {0} minutes ago.]";
        public static string OpenTaskTimingFormat = "[Open for {0} minutes.]";
        public static string CompleteTaskIcon = "[X]";
        public static string OpenTaskIcon = "[ ]";
    }
}
