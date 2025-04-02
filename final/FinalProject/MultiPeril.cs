using System.Dynamic;

public class MultiPeril : Insurance{
    public MultiPeril(string location) : base(location){
        _coverageType = "Multi Peril Insurance";
        
    }
    
    public override double GetCostPerAcre(string region){
        switch (region){
            //High Cost
            case "South Central":
                _costPerAcre = new Random().Next(50,80);
                return _costPerAcre;
            //High Cost
            case "Central Plains":
                _costPerAcre = new Random().Next(45,75);
                return _costPerAcre;
            //High Cost
            case "Southeast":
                _costPerAcre = new Random().Next(45,70);
                return _costPerAcre;
            //Moderate Cost
            case "Midwest":
                _costPerAcre = new Random().Next(40,65);
                return _costPerAcre;
            //Moderate Cost
            case "Mid-Atlantic":
                _costPerAcre = new Random().Next(35,55);
                return _costPerAcre;
            //Moderate Cost
            case "New England":
            case "NY, PA, DE":
            case "Great Lakes":
                _costPerAcre = new Random().Next(30,50);
                return _costPerAcre;
            //Low Cost
            case "Mountain":
                _costPerAcre = new Random().Next(25,40);
                return _costPerAcre;
            //Very Low Cost
            case "West Coast":
                _costPerAcre = new Random().Next(15,20);
                return _costPerAcre;
            
            
            
            default: return 35;
        }
    }
    
}