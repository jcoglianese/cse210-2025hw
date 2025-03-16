class Checklist : Goals
{
    public int BonusPoints { get; set; }
    public int DesiredAmount { get; set; }
    public int AchievedAmount { get; set; }

    public override void Record()
    {
        if (AchievedAmount < DesiredAmount)
        {
            AchievedAmount++;
            Console.WriteLine($"Progress recorded! {AchievedAmount}/{DesiredAmount} completed.");
        }
        else
        {
            Console.WriteLine("This goal is already completed!");
        }
    }
}