using EssentialLayers.Helpers.Result;

namespace Architectore.Cli.Runners
{
	internal static class ParallelRunner
	{
		public static async Task<Response> RunAsync(IEnumerable<Task> tasks)
		{
			try
			{
				await Task.WhenAll(tasks);

				return Response.Success();
			}
			catch (Exception e)
			{
				IEnumerable<Exception> exceptions = tasks.Where(
					t => t.IsFaulted
				).SelectMany(t => t.Exception!.InnerExceptions);

				string messages = string.Join("\n", exceptions.Select(e => e.Message));

				Console.WriteLine($"Exception {nameof(ParallelRunner)}: {e.Message}");

				return Response.Fail(messages);
			}
		}
	}
}