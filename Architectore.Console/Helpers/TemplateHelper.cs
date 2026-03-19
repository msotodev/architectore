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

		public static bool IsAnInterface(string templatePath) => Path.GetFileNameWithoutExtension(templatePath).StartsWith(I);

		public static string StartWith(string templatePath) => IsAnInterface(templatePath) ? I : string.Empty;
	}
}