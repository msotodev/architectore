using Architectore.Cli.Generators;
using Architectore.Cli.Helpers;
using Architectore.Cli.Runners;
using EssentialLayers.Helpers.Result;
using static Architectore.Cli.Constants.LayersConstant;

namespace Architectore.Cli.Builders
{
	internal static class RepositoryBuilder
	{
		private const string LAYER_FOLDER = "Repositories";

		internal static Task<Response> BuildAsync(string destinationPath, string entity)
		{
			string[] templatePaths = TemplateHelper.GetTemplates(LAYER_FOLDER);
			Console.WriteLine($"Destination: {destinationPath}");

			string projectName = destinationPath.Split("\\").Last();
			Console.WriteLine($"Project Name: {projectName}");
			
			string nameSpace = $"{projectName}.{DOMAIN}.{LAYER_FOLDER}";
			Console.WriteLine($"Namespace: {nameSpace}");

			IEnumerable<Task> tasks = templatePaths.Select(
				template => FileGenerator.CreateAsync(destinationPath, template, entity, nameSpace, DOMAIN, LAYER_FOLDER)
			);

			return ParallelRunner.RunAsync(tasks);
		}
	}
}