using Architectore.Cli.Generators;
using Architectore.Cli.Helpers;
using Architectore.Cli.Models;
using Architectore.Cli.Runners;
using EssentialLayers.Helpers.Result;
using static Architectore.Cli.Constants.LayersConstant;
using static Architectore.Cli.Constants.TypeConstant;

namespace Architectore.Cli.Builders
{
	internal static class RepositoryBuilder
	{
		private const string LAYER_FOLDER = "Repositories";

		internal static Task<Response> BuildAsync(string projectPath, string entity, string contracts)
		{
			string[] templatePaths = TemplateHelper.GetTemplates(LAYER_FOLDER);

			string projectName = projectPath.Split("\\").Last();

			IEnumerable<Task> tasks = templatePaths.Select(
				templatePath =>
				{
					string layer = TemplateHelper.IsAnInterface(templatePath) ? DOMAIN : INFRASTRUCTURE;
					string nameSpace = $"{projectName}.{layer}.{LAYER_FOLDER}";
					string filePath = Path.Combine(projectPath, layer, LAYER_FOLDER);

					return FileGenerator.CreateAsync(
						new TemplateFile
						{
							Contracts = contracts,
							DestinationFilePath = filePath,
							Entity = entity,
							TemplatePath = templatePath,
							Type = REPOSITORY,
							Namespace = nameSpace
						}
					);
				}
			);

			return ParallelRunner.RunAsync(tasks);
		}
	}
}