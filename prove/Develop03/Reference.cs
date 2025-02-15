public class Reference{
    public string _Book {get; set;}
    public int _Chapter {get; set;}
    public int _VerseStart {get; set;}
    public int? _VerseEnd {get; set;} // not needed in case it's a single verse

    public Reference(string book, int chapter, int verseStart, int? verseEnd = null)
    {
        _Book = book;
        _Chapter = chapter;
        _VerseStart = verseStart;
        _VerseEnd = verseEnd;
    }

    public override string ToString()
    {
        return _VerseEnd.HasValue ? $"{_Book} {_Chapter}:{_VerseStart}-{_VerseEnd}" : $"{_Book} {_Chapter}:{_VerseStart}";
    }

    public static Reference FromString(string input){
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentException("Input cannot be empty.");
        int lastSpaceIndex = input.LastIndexOf(' ');
        if (lastSpaceIndex == -1)
            throw new FormatException("Invalid reference format. Expected format: 'Book Chapter:Verse'");
        string book = input.Substring(0, lastSpaceIndex);
        string chapterVersePart = input.Substring(lastSpaceIndex + 1);
        string[] chapterVerse = chapterVersePart.Split(':');
        if (chapterVerse.Length < 2)
            throw new FormatException("Invalid chapter and verse format. Expected format: 'Chapter:Verse'");
        if (!int.TryParse(chapterVerse[0], out int chapter))
            throw new FormatException("Invalid chapter number.");
        string[] verses = chapterVerse[1].Split('-');
        if (!int.TryParse(verses[0], out int verseStart))
            throw new FormatException("Invalid start verse number.");
        int? verseEnd = null;
        if (verses.Length > 1)
        {
            if (!int.TryParse(verses[1], out int end))
                throw new FormatException("Invalid end verse number.");
            verseEnd = end;
        }


        return new Reference(book,chapter,verseStart,verseEnd);
    }
}