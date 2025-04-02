using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

public class ZipCodeService{
    private static readonly HttpClient client = new HttpClient();

    public async Task<string> GetLocationByZipAsync(string zipCode){
        string url = $"http://api.zippopotam.us/us/{zipCode}";

        try{
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode){

                string json = await response.Content.ReadAsStringAsync();
                JsonDocument doc = JsonDocument.Parse(json);

                string city = doc.RootElement.GetProperty("places")[0].GetProperty("place name").GetString();
                string state = doc.RootElement.GetProperty("places")[0].GetProperty("state abbreviation").GetString();

                return $"{city}, {state}";
            }
            else{
                return "Unknown Location (Invalid Zip Code)";
            }
        }
        catch (Exception ex){
            Console.WriteLine($"Error: {ex.Message}");
            return "Unknown Location";
        }
    }
}