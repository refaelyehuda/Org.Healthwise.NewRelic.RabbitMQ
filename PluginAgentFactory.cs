﻿using System;
using System.Collections.Generic;
using NewRelic.Platform.Sdk;

namespace org.healthwise.newrelic.rabbitmq
{
    class PluginAgentFactory : AgentFactory
    {
        /// <summary>
        /// Creates agents for each item in the plugin.json file
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        public override Agent CreateAgentWithConfiguration(IDictionary<string, object> properties)
        {
            string protocol = (string)properties["protocol"];
            string name = (string)properties["name"];
            string host = (string)properties["host"];
            int port = int.Parse((string)properties["port"]);
            string username = (string)properties["username"];
            string password = (string)properties["password"];

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(host) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("'name', 'host', 'port', 'username' and 'password' cannot be null or empty. Do you have a 'config/plugin.json' file?");
            }

            return new PluginAgent(protocol, name, host, port, username, password);
        }
    }
}
