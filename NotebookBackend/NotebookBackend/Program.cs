using NotebookBackend;

IHost host = Host.CreateDefaultBuilder()
    .ConfigureWebHostDefaults(defaults =>
        defaults.UseStartup<Startup>())
    .Build();

host.Run();