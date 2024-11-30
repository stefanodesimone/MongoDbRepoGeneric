# MongoDB generic repository pattern
This repo provides implementation generic repository pattern on MongoDB
To implement in a web api or MVC web app project:
In program.cs insert these lines:
```c#
            var mongoDbSettings = builder.Configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
            var client = new MongoClient(mongoDbSettings.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.DatabaseName);
            builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
            // Register the MongoDB context or direct collections
            builder.Services.AddSingleton<IMongoDatabase>(database);
            builder.Services.AddSingleton<IMongoDbSettings>(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
            // Register the generic repository for dependency injection
            builder.Services.AddScoped(typeof(IMongoDbGenericRepository<>), typeof(MongoDbGenericRepository<>));
            // Add services to the container.
            builder.Services.AddControllers();
```
