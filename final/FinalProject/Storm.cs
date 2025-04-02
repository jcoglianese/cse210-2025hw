using System.Dynamic;

public class Storm{
    protected string _name; 
    protected double _threatLevel; 
    protected string _location;

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