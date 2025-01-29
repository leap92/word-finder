
using System.Collections.Immutable;
using System.Linq;

public class WordFinder
{
    private readonly char[,] matrix;

    public WordFinder(IEnumerable<string> rows)
    {
        if (rows == null || rows.Count() == 0)
        {
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

        var results = new Dictionary<string, int>(); //save words using word as key, and value is amount of times that word is found
        
            results.Add(SearchLeftToRight(trie));
            // SearchRightToLeft();
            // SearchTopToBottom();
            // SearchBottomToTop();
        

    }

    private void SearchLeftToRight(Trie trie)
    {
        var foundWords = new List<string>();
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            string candidate = "";
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                char c = matrix[row,col];

                candidate += c;
                if (trie.Search(candidate)) {
                    foundWords.Add(candidate);
                }

                for (int subsequentCol = 0; subsequentCol < matrix.GetLength(1); subsequentCol++)
                {
                    
                }
                                
                
            }
        }
    }
}