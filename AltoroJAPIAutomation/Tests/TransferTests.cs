using AltoroJAPIAutomation.Services;
using Xunit;
using Xunit.Abstractions;

namespace AltoroJAPIAutomation.Tests
{
    public class TransferTests
    {
        private readonly ITestOutputHelper output;

        public TransferTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact(DisplayName = "Post Transfer between accounts")]
        [Trait("category", "transfer")]
        public void Post_Transfer()
        {
            new TransferServiceWorkFlow(output).Validate_PostTransfer(CustomConfigurationProvider.GetSection("infoTransfer"), CustomConfigurationProvider.GetSection("tokken"));
        }
    }
}
