using Architectore.Cli.Helpers;
using System.Text;

namespace Architectore.Cli.Builders
{
	internal static class ContractBuilder
	{
		private const string TEMPLATE_FOLDER = "Contracts";

		public static async Task<string> BuildAsync(string[] contracts)
		{
			try
			{
				string[] contractTemplates = TemplateHelper.GetTemplates(TEMPLATE_FOLDER);

				StringBuilder stringBuilder = new();

                string[] selectedTemplates = [.. contractTemplates.Where(
					template => contracts.Any(
						contract => contract.Equals(
							Path.GetFileNameWithoutExtension(template), StringComparison.CurrentCultureIgnoreCase
						)
					)
				)];

				foreach (string selectedTemplate in selectedTemplates)
				{
					string text = await File.ReadAllTextAsync(selectedTemplate);

					stringBuilder.Append(text);

					if (selectedTemplates.IndexOf(selectedTemplate) < selectedTemplates.Length - 1)
					{
						stringBuilder.Append("\n\n\t\t");
					}
				}

				return stringBuilder.ToString();
			}
			catch (Exception e)
			{
				Console.WriteLine($"Exception {nameof(ContractBuilder)}: {e.Message}");

				return string.Empty;
			}
		}
	}
}