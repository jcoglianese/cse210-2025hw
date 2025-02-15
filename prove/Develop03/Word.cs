public class Word{
    bool _hidden;
    string _line;
    
    public static List<string> SplitText(string line){
        string[] parts = line.Split(' ');
        return new List<string>(parts);
    }

    public static string HideWord(string word){
        return new string('_', word.Length);

    }

}