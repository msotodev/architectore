namespace Architectore.Cli.Models
{
	public class TemplateFile
	{
		public string DestinationFilePath { get; set; } = string.Empty;

		public string Entity { get; set; } = string.Empty;

		public string Namespace { get; set; } = string.Empty;

		public string Type { get; set; } = string.Empty;

		public string TemplatePath { get; set; } = string.Empty;

		public string Contracts { get; set; } = string.Empty;
	}
}