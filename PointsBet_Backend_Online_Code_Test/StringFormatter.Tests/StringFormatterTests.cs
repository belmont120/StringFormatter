namespace StringFormatter.Tests;

public class StringFormatterTests
{
    [Fact]
    public void ToDelimiterSeparatedListString_WithDefaultDelimiter_ReturnCommaSeparatedStringWithItemsQuoted()
    {
        // Arrange
        string[] items = ["Toyota", "Hyundai", "Ford"];
        const string QUOTE = "'";
        const string EXPECTED = "'Toyota', 'Hyundai', 'Ford'";
        // Act
        var formattedString = PointsBet_Backend_Online_Code_Test.StringFormatter.ToDelimiterSeparatedQuotedString(items, QUOTE);

        // Assert
        Assert.Equal(EXPECTED, formattedString);
    }
    
    [Fact]
    public void ToDelimiterSeparatedListString_WithEmptyStringArray_ReturnEmptyString()
    {
        // Arrange
        string[] items = [];
        const string QUOTE = "'";
        var expected = string.Empty;
        // Act
        var formattedString = PointsBet_Backend_Online_Code_Test.StringFormatter.ToDelimiterSeparatedQuotedString(items, QUOTE);

        // Assert
        Assert.Equal(expected, formattedString);
    }
    
    [Fact]
    public void ToDelimiterSeparatedListString_WithEmptyQuote_ReturnCommaSeparatedStringWithoutQuoteAdded()
    {
        // Arrange
        string[] items = ["Toyota", "Hyundai", "Ford"];
        const string QUOTE = "";
        const string EXPECTED = "Toyota, Hyundai, Ford";
        // Act
        var formattedString = PointsBet_Backend_Online_Code_Test.StringFormatter.ToDelimiterSeparatedQuotedString(items, QUOTE);

        // Assert
        Assert.Equal(EXPECTED, formattedString);
    }
    
        
    [Fact]
    public void ToDelimiterSeparatedListString_WithQuoteContainingBlankPrefixAndSuffix_ReturnCommaSeparatedStringWithQuoteTrimmed()
    {
        // Arrange
        string[] items = ["Toyota", "Hyundai", "Ford"];
        const string QUOTE = "  '     ";
        const string EXPECTED = "'Toyota', 'Hyundai', 'Ford'";
        // Act
        var formattedString = PointsBet_Backend_Online_Code_Test.StringFormatter.ToDelimiterSeparatedQuotedString(items, QUOTE);

        // Assert
        Assert.Equal(EXPECTED, formattedString);
    }
    
    [Fact]
    public void ToDelimiterSeparatedListString_WithPipeDelimiterDefined_ReturnQuotedPipeSeparatedString()
    {
        // Arrange
        string[] items = ["Toyota", "Hyundai", "Ford"];
        const string QUOTE = "'";
        const string DELIMITER = "|";
        const string EXPECTED = "'Toyota'| 'Hyundai'| 'Ford'";

        // Act
        var formattedString = PointsBet_Backend_Online_Code_Test.StringFormatter.ToDelimiterSeparatedQuotedString(items, QUOTE, DELIMITER);

        // Assert
        Assert.Equal(EXPECTED, formattedString);
    }
    
    [Fact]
    public void ToDelimiterSeparatedListString_WithPipeDelimiterDefinedWithBlankPrefixAndSuffix_ReturnQuotedPipeSeparatedStringWithoutBlankSpace()
    {
        // Arrange
        string[] items = ["Toyota", "Hyundai", "Ford"];
        const string QUOTE = "'";
        const string DELIMITER = "   |  ";
        const string EXPECTED = "'Toyota'| 'Hyundai'| 'Ford'";

        // Act
        var formattedString = PointsBet_Backend_Online_Code_Test.StringFormatter.ToDelimiterSeparatedQuotedString(items, QUOTE, DELIMITER);

        // Assert
        Assert.Equal(EXPECTED, formattedString);
    }
    
    [Fact]
    public void ToDelimiterSeparatedListString_WithEmptyStringInItems_ReturnCommaSeparatedStringWithEmptyStringItemFiltered()
    {
        // Arrange
        string[] items = ["Toyota", "", "Ford"];
        const string QUOTE = "'";
        const string EXPECTED = "'Toyota', 'Ford'";
        // Act
        var formattedString = PointsBet_Backend_Online_Code_Test.StringFormatter.ToDelimiterSeparatedQuotedString(items, QUOTE);

        // Assert
        Assert.Equal(EXPECTED, formattedString);
    }
}