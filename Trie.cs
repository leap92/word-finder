public class TrieNode
{
    public bool IsWord { get; set; }
    public Dictionary<char, TrieNode> Children { get; } = new Dictionary<char, TrieNode>();
}

public class Trie
{
    private readonly TrieNode _root = new TrieNode();

    public void AddWord(string word)
    {
        var node = _root;
        foreach (char c in word)
        {
            if (!node.Children.ContainsKey(c))
                node.Children[c] = new TrieNode();
            node = node.Children[c];
        }
        node.IsWord = true;
    }

    public bool Search(string word)
    {
        var node = _root;
        foreach (char c in word)
        {
            if (!node.Children.TryGetValue(c, out TrieNode? value))
                return false;
            node = value;
        }
        return node.IsWord;
    }

    public void Traverse()
    {
        var stack = new Stack<(TrieNode node, string prefix)>();
        stack.Push((_root, ""));

        while (stack.Count > 0)
        {
            var (node, prefix) = stack.Pop();

            Console.WriteLine(prefix);
    
            foreach (var child in node.Children.Reverse()) // Reverse to maintain order
            {
                stack.Push((child.Value, prefix + child.Key));
            }
        }
    }
}