public class Hail : Storm {
    public Hail(string location){
        _name = "Hail";
        _location = location;
        _threatLevel = new Random().Next(20,70);
    }
}