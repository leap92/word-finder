
using System.Collections.Immutable;
using System.Linq;

public class WordFinder
{
    private readonly char [,] matrix;

    public WordFinder(IEnumerable<string> rows)
    {
        if (rows == null || rows.Count() == 0 ) {
            throw new ArgumentException("Word finder matrix is empty");
        }
        //we are going to assume the matrix input sets our matrix left to right, top to bottom
        //first, check if input is valid (all strings need to have equal length, max width/height)
        var firstRow = rows.FirstOrDefault();

        var allSameLength = rows.All(m => firstRow.Length == m.Length);
        if (!allSameLength) throw new ArgumentException("All rows in matrix need to be of equal length");

        if (rows.Count() > 64 || firstRow.Length > 64) throw new ArgumentException("Max width/height of matrix is 64");

        this.matrix = Matrix.RowListToCharMatrix([.. rows]);

    }
    public IEnumerable<string> Find(IEnumerable<string> wordstream)
    {
        var wordSet = new HashSet<string>(wordstream); //hashset takes care of any duplicates that may exist

        var trie = new Trie();

        foreach (var word in wordSet)
        {
            trie.AddWord(word);            
        }

        //print words for debugging purposes
        trie.Traverse();

        var found1 = SearchLeftToRight(wordSet);
       // SearchRightToLeft();
        //SearchTopToBottom();
       // SearchBottomToTop();
        
    }

    private void SearchLeftToRight(HashSet<string> wordSet)
    {
        for (int i = 0; i < length; i++)
        {
            
        }
    }
}