namespace SauceLabs.IntegrationTests
{
    using OpenQA.Selenium;
    using System.Collections.Generic;

    internal sealed class RemoteDriverOptions : DriverOptions
    {
        private readonly Dictionary<string, object> additionalOptions = new Dictionary<string, object>();

        public override void AddAdditionalCapability(string capabilityName, object capabilityValue)
        {
            additionalOptions[capabilityName] = capabilityValue;
        }

        public override ICapabilities ToCapabilities()
        {
            var capabilities = this.GenerateDesiredCapabilities(true);

            foreach (var capability in additionalOptions)
            {
                capabilities.SetCapability(capability.Key, capability.Value);
            }

            return capabilities;
        }
    }
}
