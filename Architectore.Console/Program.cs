using Architectore.Cli.Builders;
using EssentialLayers.Helpers.Extension;
using System.CommandLine;

namespace Architectore.Cli
{
	public static class Program
	{
		public static async Task Main(string[] args)
		{
			Option<string> pathOption = new("--path", "Project path")
			{
				IsRequired = true
			};

			Option<string> nameSpaceOption = new("--namespace", "Project namespace")
			{
				IsRequired = true
			};

			Option<string> entityOption = new("--entity", "Entity name")
			{
				IsRequired = true
			};

			Option<string> repoOption = new("--repo", $"Generate repository (Delete,New,Update)");
			Option<string> serviceOption = new("--service", $"Generate service (Delete,New,Update)");
			Option<string> queryOption = new("--query", $"Generate query (GetAll,GetById)");

			Command command = new("g", "Generate code based in entity");

			command.AddOption(pathOption);
			command.AddOption(nameSpaceOption);
			command.AddOption(entityOption);
			command.AddOption(repoOption);
			command.AddOption(serviceOption);
			command.AddOption(queryOption);

			command.SetHandler(async (string path, string nameSpace, string entity, string repo, string service, string query) =>
			{
				Console.WriteLine($"🚀 Generating to {entity}...");

				if (repo.NotEmpty()) await RepositoryBuilder.BuildAsync(path, entity, repo);

				if (service.NotEmpty()) await ServiceBuilder.BuildAsync(path, entity, service);

				if (query.NotEmpty()) await QueryBuilder.BuildAsync(path, entity, query);

				Console.WriteLine("✅ Finalized");

			}, pathOption, nameSpaceOption, entityOption, repoOption, serviceOption, queryOption);

			RootCommand root = new("Architectore CLI");

			root.AddCommand(command);

			await root.InvokeAsync(args);
		}
	}
}