using System.Formats.Asn1;
using System.Net.NetworkInformation;

class Circle : Shape{
    double _radius;
    public void SetRadius(double radius){
        _radius = radius;
    }
    public override double GetArea(){
        return _radius * _radius * Math.PI;
    }
}