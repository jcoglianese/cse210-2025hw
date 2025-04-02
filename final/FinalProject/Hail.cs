public class Hail : Storm {
    public Hail(string location) : base(location){
        _name = "Hail";
             
        }
        
    public override double GetThreatLevel(string region){
        switch (region){
            //High Threat
            case "South Central":
            case "Central Plains":
            case "Mountain":
                _threatLevel = new Random().Next(60,90);
                return _threatLevel;
            //Moderate Threat
            case "New England":
            case "NY, PA, DE":
            case "Mid-Atlantic (NJ, MD, VA)":
            case "Great Lakes":
            case "Midwest":
                _threatLevel = new Random().Next(40,60);
                return _threatLevel;
            //Low Threat
            case "Southeast":
            case "West Coast":
                _threatLevel = new Random().Next(20,40);
                return _threatLevel;
            default: return 5000; //Absurd Number that will tell you the program isn't working properly
        }
    
    }
}