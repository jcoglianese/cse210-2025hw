using System.Dynamic;

public class Area{
  private string _location;
  private int _acres;
  private string _crop;

  public void SetLocation(string location){
    _location = location;
  }

  public void SetAcres(string acres){
    if (int.TryParse(acres, out int result)){
        SetAcres(result);
    }
    else{
        Console.WriteLine("Invalid input. Please enter a whole number.");
    }
  }
  public void SetAcres(int acres){
    _acres = acres;
  }

  public void SetCrop(string crop){
    _crop = crop;
  }



}