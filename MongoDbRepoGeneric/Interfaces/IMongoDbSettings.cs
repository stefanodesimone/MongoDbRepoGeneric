﻿namespace MongoDbRepoGeneric.Interfaces
{
    public interface IMongoDbSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }
}
