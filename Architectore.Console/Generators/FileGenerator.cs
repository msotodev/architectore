using Architectore.Cli.Helpers;
using Architectore.Cli.Replacers;
using EssentialLayers.Helpers.Extension;

namespace Architectore.Cli.Generators
{
	internal static class FileGenerator
	{
		public static async Task CreateAsync(string destinationPath, string templatePath, string entity, string nameSpace, string layer, string layerFolder)
		{
			if (Directory.Exists(destinationPath).False()) Directory.CreateDirectory(destinationPath);

			string fileName = TemplateHelper.GetFileName(templatePath, entity, layerFolder);

			Console.WriteLine($"Filename: {fileName}");

			string path = Path.Combine(destinationPath, layer, layerFolder, fileName);

			Console.WriteLine($"Path: {path}");

			byte[] bytes = await TemplateReplacer.Replace(templatePath, entity, nameSpace);

			await File.WriteAllBytesAsync(path, bytes);
		}
	}
}