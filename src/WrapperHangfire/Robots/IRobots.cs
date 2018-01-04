namespace WrapperHangfire.Robots
{
    public interface IRobots
    {
        string NameRobot { get; }

        void Run();
    }
}