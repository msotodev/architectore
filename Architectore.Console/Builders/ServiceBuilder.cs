using Architectore.Cli.Generators;
using Architectore.Cli.Helpers;
using Architectore.Cli.Runners;
using EssentialLayers.Helpers.Result;
using static Architectore.Cli.Constants.LayersConstant;

namespace Architectore.Cli.Builders
{
	internal static class ServiceBuilder
	{
		private const string LAYER_FOLDER = "Services";

		internal static Task<Response> BuildAsync(string destinationPath, string entity)
		{
			string[] templatePaths = TemplateHelper.GetTemplates(LAYER_FOLDER);
			string projectName = destinationPath.Split("/").Last();
			string nameSpace = $"{projectName}.{APPLICATION}.{LAYER_FOLDER}";

			IEnumerable<Task> tasks = templatePaths.Select(
				template => FileGenerator.CreateAsync(destinationPath, template, entity, nameSpace, APPLICATION, LAYER_FOLDER)
			);

			return ParallelRunner.RunAsync(tasks);
		}
	}
}