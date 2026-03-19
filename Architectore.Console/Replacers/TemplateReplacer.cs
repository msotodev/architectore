using System.Text;

namespace Architectore.Cli.Replacers
{
	internal static class TemplateReplacer
	{
		private const string ENTITY = "Entity";

		private const string NAMESPACE = "Namespace";

		public static async Task<byte[]> Replace(string filePath, string entity, string nameSpace)
		{
			string text = await File.ReadAllTextAsync(filePath);

			string replaced = text.Replace("{{" + ENTITY + "}}", entity).Replace("{{" + NAMESPACE + "}}", nameSpace);

			return Encoding.UTF8.GetBytes(replaced);
		}
	}
}