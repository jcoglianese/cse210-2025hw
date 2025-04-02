using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Area yourArea = new Area();
        Console.Write("\nEnter the zip code for the area: ");
        string zipCode = Console.ReadLine();
        await yourArea.SetZipCode(zipCode);
        string location = yourArea.GetLocation();
        string region = yourArea.GetRegion();

        Console.WriteLine($"\nLocation: {location}");
        Console.WriteLine($"Region: {region}\n");
        
        Console.Write("How many acres do you have? ");
        yourArea.SetAcres(Console.ReadLine());
        int acres = yourArea.GetAcres();

        Console.Write("What crop do you have (corn, potatos, or wheat)? ");
        yourArea.SetCrop(Console.ReadLine());

        
        
        Console.WriteLine("");

        List<Storm> storms = new List<Storm>{
            new Hail(location),
            new Tornado(location),
            new Hurricane(location)
        };
        Console.WriteLine($"-- Storm Threat Percentace | {location} --");
        foreach (Storm storm in storms){
            storm.DisplayThreat(region);
        }

        Console.WriteLine("");

        List<Insurance> insurances = new List<Insurance>{
            new HailIns(location),
            new TornadoIns(location),
            new HurricaneIns(location),
            new MultiPeril(location)
        };
        Console.WriteLine($"-- Storm Insurance | {location} | {acres} acres --");
        foreach (Insurance insurance in insurances){
            insurance.DisplayInsurance(acres, region);
        }
        
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}