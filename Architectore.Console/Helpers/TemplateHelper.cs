namespace Architectore.Cli.Helpers
{
	internal static class TemplateHelper
	{
		private static readonly string BASE_DIRECTORY = AppContext.BaseDirectory;

		private const string TEMPLATES = "Templates";

		private const string I = "I";

		public static string[] GetTemplates(string folder)
		{
			string[] files = Directory.GetFiles(Path.Combine(BASE_DIRECTORY, TEMPLATES, folder));

			return files;
		}

		public static bool IsAnInterface(string name) => Path.GetFileNameWithoutExtension(name).StartsWith(I);

		public static string GetFileName(string template, string entity, string type) => $"{(IsAnInterface(template) ? I : string.Empty)}{entity}{type}.cs";
	}
}