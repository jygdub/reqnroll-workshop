using Core.Utility;
using Reqnroll.Assist;

namespace E.Final.Tests.Steps;

[Binding]
public class Transform
{
    [StepArgumentTransformation(@"€\s*(\d+[\.,]?\d*)")]
    public static decimal TransformEuroToDecimal(string euroString) => euroString.ParseEuroAmount();
}

public class PriceRetriever : IValueRetriever
{
    public bool CanRetrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
    {
        return keyValuePair.Key.Equals("Price");
    }

    public object Retrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
    {
        return keyValuePair.Value.ParseEuroAmount();
    }
}