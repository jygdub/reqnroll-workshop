using E.Final.Tests.Steps;
using Reqnroll.Assist;

namespace E.Final.Tests.Hooks;

[Binding]
public class Retrievers
{
    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        Service.Instance.ValueRetrievers.Register(new PriceRetriever());
    }
}