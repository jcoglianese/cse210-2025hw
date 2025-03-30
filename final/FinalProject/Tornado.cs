public class Tornado : Storm {
    public Tornado(string location){
        _name = "Tornado";
        _location = location;
        _threatLevel = new Random().Next(30,90);
    }
}