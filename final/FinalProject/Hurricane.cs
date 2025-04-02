public class Hurricane : Storm {
    public Hurricane(string location) : base(location){
        _name = "Hurricane";
        
    }
    public override double GetThreatLevel(string region){
        switch (region){
            //High Threat
            case "Southeast":
                _threatLevel = new Random().Next(60,90);
                return _threatLevel;
            //Low Threat
            case "New England":
            case "NY, PA, DE":
            case "Great Lakes":
            case "Mountain":
                _threatLevel = new Random().Next(20,40);
                return _threatLevel;
            //Rare Threat
            case "Mid-Atlantic (NJ, MD, VA)":
            case "South Central":
                _threatLevel = new Random().Next(10,20);
                return _threatLevel;
            //No Threat
            case "West Coast":
            case "Midwest":
            case "Central Plains":
                _threatLevel = new Random().Next(0,10);
                return _threatLevel;
            default: return 5000; //Absurd Number that will tell you the program isn't working properly
        }
    }
}