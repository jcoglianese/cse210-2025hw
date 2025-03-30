using System.Dynamic;

public class Insurance{
    protected string _coverageType {get;set;}
    public double _costPerAcre {get; set;}

    public virtual double CalculateCost(double acres){
        return _costPerAcre * acres;
    }
    
}