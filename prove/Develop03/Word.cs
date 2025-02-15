public class Word{
    bool _hidden;
    string _line;
    //<list> _words;
    
    public static List<string> SplitText(string line){
        string[] parts = line.Split(' ');
        return new List<string>(parts);
    }
   // public static List<string> SplitWords(string word){
      //  string[] parts = word.Split('');
      //  return new List<string>(parts);
    //}

    public static string HideWord(string word){
        return new string('_', word.Length);

    }

}