using System.Dynamic;

public class Storm{
    protected string _name {get; set;}
    protected double _threatLevel {get;set;}
    protected string _location {get; set;}
    
    public virtual void DisplayThreat(){
        Console.WriteLine($"{_name} threat level: {_threatLevel}% in {_location}");
    }
}