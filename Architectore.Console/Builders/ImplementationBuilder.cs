using Architectore.Cli.Helpers;
using System.Text;

namespace Architectore.Cli.Builders
{
	internal static class ImplementationBuilder
	{
		private const string TEMPLATE_FOLDER = "Implementations";

		public static async Task<string> BuildAsync(string[] contracts)
		{
			try
			{
				string[] implementations = TemplateHelper.GetTemplates(TEMPLATE_FOLDER);

				StringBuilder stringBuilder = new();

				string[] selectedImplementations = [.. implementations.Where(
					template => contracts.Any(
						contract => contract.Equals(
							Path.GetFileNameWithoutExtension(template), StringComparison.CurrentCultureIgnoreCase
						)
					)
				)];

				foreach (string selectedImplementation in selectedImplementations)
				{
					string text = await File.ReadAllTextAsync(selectedImplementation);

					stringBuilder.Append(text);

					if (selectedImplementations.IndexOf(selectedImplementation) < selectedImplementations.Length - 1)
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