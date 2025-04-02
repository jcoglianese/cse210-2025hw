using System.Dynamic;

public class Storm{
    protected string _name {get; set;}
    protected double _threatLevel {get;set;}
    protected string _location {get; set;}

    public Storm(string location){
        _location = location;
    }

    public virtual double GetThreatLevel(string region){
        return 50;
    }
    
    public virtual void DisplayThreat(string region){
        Console.WriteLine($"{_name + ":",-15} {GetThreatLevel(region)}%");
    }
}