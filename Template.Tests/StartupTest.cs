using NUnit.Framework;
using Robust.Client;
using Robust.Shared.IoC;
using Robust.UnitTesting;
using Template.Game;

namespace Template.Tests;

[TestFixture]
public sealed class StartupTest : RobustIntegrationTest
{
    [Test]
    public async Task GameStartsSingleplayer()
    {
        var client = StartClient(new ClientIntegrationOptions
        {
            ContentStart = true,
            ContentAssemblies = [typeof(EntryPoint).Assembly],
            Options = new GameControllerOptions
            {
                ContentModulePrefix = "Template.",
                ContentBuildDirectory = "Template.Game",
                LoadConfigAndUserData = false,
                LoadContentResources = false,
            },
        });

        await client.WaitIdleAsync();

        Assert.That(client.IsAlive, Is.True);
        Assert.That(client.UnhandledException, Is.Null);

        await client.WaitAssertion(() =>
        {
            var baseClient = IoCManager.Resolve<IBaseClient>();

            Assert.That(baseClient.RunLevel, Is.EqualTo(ClientRunLevel.SinglePlayerGame));
        });
    }
}
