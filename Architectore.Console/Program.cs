using Architectore.Cli.Builders;
using System.CommandLine;

namespace Architectore.Cli
{
	public static class Program
	{
		public static async Task Main(string[] args)
		{
			var pathOption = new Option<string>("--path", "Ruta base del proyecto")
			{
				IsRequired = true
			};

			var nameSpaceOption = new Option<string>("--namespace", "Espacio de nombre del proyecto")
			{
				IsRequired = true
			};

			var entityOption = new Option<string>(
				name: "--entity",
				description: "Nombre de la entidad"
			);

			var repoOption = new Option<bool>("--repo", "Generar repositorios");
			var serviceOption = new Option<bool>("--service", "Generar servicios");
			var queryOption = new Option<bool>("--query", "Generar queries");

			var command = new Command("generate", "Genera código basado en entidades");

			command.AddOption(pathOption);
			command.AddOption(nameSpaceOption);
			command.AddOption(entityOption);
			command.AddOption(repoOption);
			command.AddOption(serviceOption);
			command.AddOption(queryOption);

			command.SetHandler(async (string path, string nameSpace, string entity, bool repo, bool service, bool query) =>
			{
				Console.WriteLine($"🚀 Generando para {entity}...");

				if (repo)
					await RepositoryBuilder.BuildAsync(
						path,
						entity
					);

				if (service)
					await ServiceBuilder.BuildAsync(
						path,
						entity
					);

				if (query)
					await QueryBuilder.BuildAsync(
						path,
						entity
					);

				Console.WriteLine("✅ Finalizado");

			}, pathOption, nameSpaceOption, entityOption, repoOption, serviceOption, queryOption);

			var root = new RootCommand("Architectore CLI");
			root.AddCommand(command);

			await root.InvokeAsync(args);
		}
	}
}