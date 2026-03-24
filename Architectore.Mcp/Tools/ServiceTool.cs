using Architectore.Cli.Builders;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace Architectore.Mcp.Tools
{
	[McpServerToolType]
	public static class ServiceTool
	{
		[McpServerTool, Description("Build a service using clean architecture")]
		public static Task BuildServiceAsync(
			string projectPath, string entity, string contracts
		) => ServiceBuilder.BuildAsync(projectPath, entity, contracts);

		[McpServerTool, Description("Build a repository using clean architecture")]
		public static Task BuildRepositoryAsync(
			string projectPath, string entity, string contracts
		) => RepositoryBuilder.BuildAsync(projectPath, entity, contracts);

		[McpServerTool, Description("Build a CQRS query using clean architecture")]
		public static Task BuildQueryAsync(
		string projectPath, string entity, string contracts
	) => QueryBuilder.BuildAsync(projectPath, entity, contracts);
	}
}