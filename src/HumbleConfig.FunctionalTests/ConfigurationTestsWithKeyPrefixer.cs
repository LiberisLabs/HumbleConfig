﻿using System.Collections.Generic;
using System.Threading.Tasks;
using HumbleConfig.InMemory;
using HumbleConfig.KeyFormatters;
using NUnit.Framework;

namespace HumbleConfig.FunctionalTests
{
    [TestFixture]
    public class ConfigurationTestsWithKeyPrefixer
    {
        private IConfiguration _configuration;
        
        private string _key1Actual;
        
        [OneTimeSetUp]
        public void GivenConfigurationWithKeyPrefixer()
        {
            _configuration = new Configuration()
                .WithKeyPrefixer("HumbleConfig:")
                .AddInMemory(new Dictionary<string, object>() { { "HumbleConfig:Key1", "InMemory"} })
                .GetConfiguration();
        }

        [SetUp]
        public async Task WhenGettingAppSettings()
        {
            _key1Actual = await _configuration.GetAppSettingAsync<string>("Key1");
        }

        [Test]
        public void ThenKey1PullsValueFromEnvironmentVariable()
        {
            Assert.That(_key1Actual, Is.EqualTo("InMemory"));
        }
    }
}
