public class Hurricane : Storm {
    public Hurricane(string location){
        _name = "Hurricane";
        _location = location;
        _threatLevel = new Random().Next(40,100);
    }
    
}