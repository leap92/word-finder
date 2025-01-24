public class Matrix
{
    public static char[,] RowListToCharMatrix(IList<string> strings)
    {

        int rows = strings.Count;
        int cols = strings[0].Length; //All rows are of same length so we can use the first one

        char[,] matrix = new char[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < strings[i].Length; j++)
            {
                matrix[i, j] = strings[i][j];
            }
        }

        return matrix;
    }
}