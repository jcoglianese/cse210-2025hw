class Simple : Goals
{
    public override void Record()
    {
        if (!Complete)
        {
            Complete = true;
            Console.WriteLine("Simple goal completed!");
        }
        else
        {
            Console.WriteLine("This goal is already completed.");
        }
    }
}