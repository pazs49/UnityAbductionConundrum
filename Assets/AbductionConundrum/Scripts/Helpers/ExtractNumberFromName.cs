using System.Text.RegularExpressions;

public class ExtractNumberFromName
{
  int number;
  public ExtractNumberFromName(string name)
  {
    string pattern = @"\d+$";

    Match match = Regex.Match(name, pattern);

    int number = match.Success ? int.Parse(match.Value) : -1;
    this.number = number;
  }

  public int Value
  {
    get
    {
      return number;
    }
  }
}
