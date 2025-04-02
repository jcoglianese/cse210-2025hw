using System.Dynamic;

public class TornadoIns : Insurance{
    public TornadoIns(string location) : base(location){
        _coverageType = "Tornado Insurance";
    }

    public override double GetCostPerAcre(string region){
        switch (region){
            //Very High Cost
            case "South Central":
            case "Central Plains":
                _costPerAcre = new Random().Next(30,45);
                return _costPerAcre;
            //High Cost
            case "Midwest":
                _costPerAcre = new Random().Next(28,40);
                return _costPerAcre;
            //Moderate Cost
            case "Great Lakes":
                _costPerAcre = new Random().Next(22,30);
                return _costPerAcre;
            //Moderate Cost
            case "Mountain":
                _costPerAcre = new Random().Next(20,28);
                return _costPerAcre;
            //Low Cost
            case "New England":
            case "NY, PA, DE":
            case "Mid-Atlantic (NJ, MD, VA)":
                _costPerAcre = new Random().Next(15,22);
                return _costPerAcre;
            // Very Low Cost
            case "Southeast":
            case "West Coast":
                _costPerAcre = new Random().Next(10,18);
                return _costPerAcre;
            default: return 5000; //Absurd Number that will tell you the program isn't working properly
        }
    }
    
}