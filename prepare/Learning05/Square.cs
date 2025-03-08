using System.Formats.Asn1;

class Square : Shape{
    double _side;
    public void SetSide(double side){
        _side = side;
    }
    public override double GetArea(){
        return _side * 2;
    }
}