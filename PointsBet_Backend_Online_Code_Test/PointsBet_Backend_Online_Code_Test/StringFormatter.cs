using System.Text;

namespace PointsBet_Backend_Online_Code_Test;

public class StringFormatter
{
    public static string ToDelimiterSeparatedQuotedString(string[] items, string quote, string delimiter = ",")
    {
        if (items.Length == 0)
            return string.Empty;

        var itemsWithQuotes = items.Where(item => !string.IsNullOrWhiteSpace(item)).ToArray();

        if (!string.IsNullOrEmpty(quote))
            itemsWithQuotes = itemsWithQuotes.Select(item => $"{quote.Trim()}{item}{quote.Trim()}").ToArray();
        
        return string.Join($"{delimiter.Trim()} ", itemsWithQuotes);
    }

    // Code to improve
    public static string ToCommaSepatatedList(string[] items, string quote)
    {
        StringBuilder qry = new StringBuilder(string.Format("{0}{1}{0}", quote, items[0]));
        
        if (items.Length > 1)
        {
            for (int i = 1; i < items.Length; i++)
            {
                qry.Append(string.Format(", {0}{1}{0}", quote, items[i]));
            }
        }
        
        return qry.ToString();
    }
}
