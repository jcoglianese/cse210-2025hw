using System.Dynamic;

public class Storm{
    protected string _name; 
    protected double _threatLevel; 
    protected string _location;

    public Storm(string location){
        _location = location;
    }

    public virtual double GetThreatLevel(string region){
        return 5000; //Absurd Number that will tell you the program isn't working properly
    }
    
    public virtual void DisplayThreat(string region){
        Console.WriteLine($"{_name + ":",-15} {GetThreatLevel(region)}%");
    }
}