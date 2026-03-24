// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Architectore.Mcp
{
	public static class Program
	{
		public static async Task Main(string[] args)
		{
			HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

			builder.Logging.AddConsole(l => l.LogToStandardErrorThreshold = LogLevel.Trace);

			builder.Services.AddMcpServer().
				WithStdioServerTransport().
				WithToolsFromAssembly();

			await builder.Build().RunAsync();
		}
	}
}