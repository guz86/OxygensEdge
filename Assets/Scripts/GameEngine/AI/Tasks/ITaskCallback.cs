namespace GameEngine.AI.Tasks
{
    public interface ITaskCallback
    {
        void OnComplete(Task task, bool success);
    }
}