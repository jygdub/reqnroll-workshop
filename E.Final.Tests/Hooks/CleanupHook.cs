using Core.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace E.Final.Tests.Hooks;

[Binding]
public class CleanupHook
{
    private const string CleanupDisabledTag = "CleanupDisabled";
    
    /// <summary>
    /// Runs after each scenario to clean up any managed data that was created by the drivers.
    /// </summary>
    [AfterScenario]
    public static async Task CleanUpManagedData(FeatureContext featureContext, ScenarioContext scenarioContext, IServiceProvider provider)
    {
        var featureCleanupDisabled = featureContext.FeatureInfo.Tags.Contains(CleanupDisabledTag);
        var scenarioCleanupDisabled = scenarioContext.ScenarioInfo.Tags.Contains(CleanupDisabledTag);
            

        if(featureCleanupDisabled || scenarioCleanupDisabled)
        {
            Console.WriteLine("Clean up is disabled for this scenario. Continuing without cleanup.");
            return;
        }
            
        var repositories = provider.GetServices<IRepository>().ToList();
            
        var cleanUpTasks = repositories.Select(r => r.CleanUpAsync());
        await Task.WhenAll(cleanUpTasks);
    }
}