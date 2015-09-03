﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumbleConfig.Tests.Stubs
{
    public class ConfigurationSourceStub : IConfigurationSource
    {
        public IDictionary<string, string[]> AppSettings { get; } = new Dictionary<string, string[]>();

        public IDictionary<string, string> ConnectionStrings { get; } = new Dictionary<string, string>();
        
        public bool TryGetAppSettings(string key, out string[] values)
        {
            return AppSettings.TryGetValue(key, out values);
        }

        public bool TryGetConnectionString(string key, out string value)
        {
            return ConnectionStrings.TryGetValue(key, out value);
        }
    }
}