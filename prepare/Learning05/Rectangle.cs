using System.Formats.Asn1;

class Rectangle : Shape{
    double _length;
    double _width;

    public void SetLength(double length){
        _length = length;
    }
    public void SetWidth(double width){
        _width = width;
    }
    public override double GetArea(){
        return _length * _width;
    }
}