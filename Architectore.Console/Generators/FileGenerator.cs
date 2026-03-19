using Architectore.Cli.Builders;
using Architectore.Cli.Helpers;
using Architectore.Cli.Models;
using Architectore.Cli.Replacers;
using EssentialLayers.Helpers.Extension;
using EssentialLayers.Helpers.Result;

namespace Architectore.Cli.Generators
{
	internal static class FileGenerator
	{
		public static async Task<Response> CreateAsync(
			TemplateFile templateFile
		)
		{
			try
			{
				if (Directory.Exists(templateFile.DestinationFilePath).False()) Directory.CreateDirectory(templateFile.DestinationFilePath);

				string text = await File.ReadAllTextAsync(templateFile.TemplatePath);

				string[] contracts = templateFile.Contracts.Split(",");
				string buildedContracts = await ContractBuilder.BuildAsync(contracts);
				string implementations = await ImplementationBuilder.BuildAsync(contracts);

				byte[] bytes = await TemplateReplacer.ReplaceAsync(
					text, templateFile.Entity, templateFile.Namespace, buildedContracts, implementations
				);

				string fileName = $"{TemplateHelper.StartWith(templateFile.TemplatePath)}{templateFile.Entity}{templateFile.Type}.cs";

				string fullPath = Path.Combine(templateFile.DestinationFilePath, fileName);

				await File.WriteAllBytesAsync(fullPath, bytes);

				return Response.Success();
			}
			catch (Exception e)
			{
				Console.WriteLine($"Exception {nameof(FileGenerator)}: {e.Message}");

				return Response.Fail(e.Message);
			}
		}
	}
}