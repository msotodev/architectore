using System.Text;

namespace Architectore.Cli.Replacers
{
	internal static class TemplateReplacer
	{
		private const string ENTITY = "Entity";

		private const string NAMESPACE = "Namespace";

		private const string CONTRACTS = "Contracts";

		private const string IMPLEMENTATIONS = "Implementations";

		public static async Task<byte[]> ReplaceAsync(
			string text, string entity, string nameSpace, string contracts, string implementations
		)
		{
			try
			{
				string replaced = text.Replace(
					"{{" + ENTITY + "}}", entity
				).Replace(
					"{{" + NAMESPACE + "}}", nameSpace
				).Replace(
					"{{" + CONTRACTS + "}}", contracts.Replace("{{" + ENTITY + "}}", entity)
				).Replace(
					"{{" + IMPLEMENTATIONS + "}}", implementations.Replace("{{" + ENTITY + "}}", entity)
				);

				return Encoding.UTF8.GetBytes(replaced);
			}
			catch (Exception e)
			{
				Console.WriteLine($"Exception {nameof(TemplateReplacer)}: {e.Message}");

				return [];
			}
		}
	}
}