using System.Diagnostics;
using System.Dynamic;
using System.Runtime.InteropServices;

public class Insurance{
    protected string _coverageType; 
    protected double _costPerAcre; 
    protected double _totalCost; 
    protected string _location; 

    public Insurance(string location){
        _location = location;
    }

    public virtual double GetCostPerAcre(string region){
        return 5000; //Absurd Number that will tell you the program isn't working properly
    }

    public double CalculateCost(double acres, double costPerAcre){
        return costPerAcre * acres;
    }

    public virtual void DisplayInsurance(double acres, string region){
        _costPerAcre = GetCostPerAcre(region);  
        _totalCost = CalculateCost(acres, _costPerAcre);
        Console.WriteLine($"{_coverageType + ":",-25} ${_totalCost,5} costing ${_costPerAcre} per acre");
    }

    
}