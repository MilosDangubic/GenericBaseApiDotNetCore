using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.Configuration
{
    public class ProjectConfiguration : IProjectConfiguration
    {
        public DatabaseConfiguration DatabaseConfiguration { get; set; } = new DatabaseConfiguration();
        public Jwt Jwt { get; set; } = new Jwt();

        public EmailConfiguration EmailConfiguration { get; set; } = new EmailConfiguration();
    }

    public class EmailConfiguration
    {
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }

    public class DatabaseConfiguration 
    {
        public string ConnectionString { get; set; }
    }

    public class Jwt 
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

    }
}
