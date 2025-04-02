using System.Dynamic;

public class Area{
  private string _zipCode;
  private string _location;
  private int _acres;
  private string _crop;

  private ZipCodeService _zipService = new ZipCodeService();

  public async Task SetZipCode(string zipCode){
    _zipCode = zipCode;
    _location = await _zipService.GetLocationByZipAsync(zipCode);
  }

  public void SetLocation(string location){
    _location = location;
  }
  public string GetLocation(){
    return _location;
  }

  public string GetRegion(){
    if (string.IsNullOrWhiteSpace(_zipCode) || _zipCode.Length < 1){
      return "Unknown Region";
    }
      char firstDigit = _zipCode[0];
      switch (firstDigit){
        case '0': return "New England";
        case '1': return "NY, PA, DE";
        case '2': return "Mid-Atlantic (NJ, MD, VA)";
        case '3': return "Southeast";
        case '4': return "Great Lakes";
        case '5': return "Midwest";
        case '6': return "South Central";
        case '7': return "Central Plains";
        case '8': return "Mountain";
        case '9': return "West Coast";
        default: return "Unknown Region";
      }
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

  public int GetAcres(){
    return _acres;
  }

  public void SetCrop(string crop){
    _crop = crop;
  }



}