using System.Dynamic;

public class HurricaneIns : Insurance{
    public HurricaneIns(string location) : base(location){
        _coverageType = "Hurricane Insurance";   
    }
    public override double GetCostPerAcre(string region){
        switch (region){
            //Very High Cost
            case "Southeast":
                _costPerAcre = new Random().Next(40,60);
                return _costPerAcre;
            //High Cost
            case "Mid-Atlantic":
            case "South Central":
                _costPerAcre = new Random().Next(30,50);
                return _costPerAcre;
            //Moderate Cost
            case "New England":
            case "NY, PA, DE":
                _costPerAcre = new Random().Next(20,35);
                return _costPerAcre;
            //Low Cost
            case "Great Lakes":
                _costPerAcre = new Random().Next(15,25);
                return _costPerAcre;
            // Very Low Cost
            case "Midwest":
            case "Central Plains":
            case "Mountain":
            case "West Coast":
                _costPerAcre = new Random().Next(10,20);
                return _costPerAcre;
            default: return 20;
        }
    }
     
}