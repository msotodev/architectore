using EssentialLayers.Helpers.Result;

namespace Architectore.Cli.Runners
{
	internal static class NormalRunner
	{
		public static async Task<Response> RunAsync(IEnumerable<Task<Response>> responses)
		{
			try
			{
				await Task.WhenAll(responses);

				return Response.Success();
			}
			catch (Exception)
			{
				IEnumerable<Exception> exceptions = responses.Where(
					t => t.IsFaulted
				).SelectMany(t => t.Exception!.InnerExceptions);

				return Response.Fail(string.Join("\n", exceptions.Select(e => e.Message)));
			}
		}
	}
}