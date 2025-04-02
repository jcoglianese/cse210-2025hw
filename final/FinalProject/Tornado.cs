public class Tornado : Storm {
    public Tornado(string location) : base(location){
        _name = "Tornado";

    }

    public override double GetThreatLevel(string region){
        switch (region){
            //Very High Threat
            case "South Central":
            case "Central Plains":
                _threatLevel = new Random().Next(80,100);
                return _threatLevel;
            //High Threat
            case "Midwest":
                _threatLevel = new Random().Next(70,90);
                return _threatLevel;
            //Low Threat
            case "New England":
            case "NY, PA, DE":
            case "Mid-Atlantic":
            case "Southeast":
            case "Great Lakes":
            case "Mountain":
                _threatLevel = new Random().Next(20,45);
                return _threatLevel;
            //No Threat
            case "West Coast":
                _threatLevel = new Random().Next(0,10);
                return _threatLevel;
            default: return 50;
        }
    }
}