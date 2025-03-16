class Eternal : Goals
{
    public override bool IsComplete() => false;
    public override void Record() => Console.WriteLine("Eternal goal recorded! You keep progressing.");
}
