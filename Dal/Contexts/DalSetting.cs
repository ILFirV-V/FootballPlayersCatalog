﻿namespace FootballPlayersCatalog.Dal.Contexts
{
    public class DalSetting
    {
        public string ConnectionString { get; }

        public DalSetting(IConfiguration configuration)
        {
            ConnectionString = configuration.GetSection("Dal").GetValue<string>("ConnectionString");
        }

    }
}
