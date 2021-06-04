using System.Collections.Generic;

public class Country
{
    public string Name { get; set; }
    public string Capital { get; set; }
    public string Region { get; set; }
    public int Population { get; set; }
    // creates class currency and put this here as IEnumerable<Currency>
    public IEnumerable<Currency> Currencies { get; set; }
}