using System.Dynamic;

public class HailIns : Insurance{
    public HailIns(string location) : base(location){
        _coverageType = "Hail Insurance";
    }

    public override double GetCostPerAcre(string region){
        switch (region){
            //Highest Cost
            case "South Central":
            case "Central Plains":
                _costPerAcre = new Random().Next(20,30);
                return _costPerAcre;
            //High Cost
            case "Mountain":
                _costPerAcre = new Random().Next(18,28);
                return _costPerAcre;
            //Moderate Cost
            case "New England":
            case "NY, PA, DE":
            case "Mid-Atlantic (NJ, MD, VA)":
            case "Great Lakes":
            case "Midwest":
                _costPerAcre = new Random().Next(15,22);
                return _costPerAcre;
            //Low Cost
            case "Southeast":
            case "West Coast":
                _costPerAcre = new Random().Next(10,18);
                return _costPerAcre;
            default: return 5000; //Absurd Number that will tell you the program isn't working properly
        }
    }
     
}