namespace PlaywrightCSharp.Infrastructure.ResourceProviders
{
    internal class PlaywrightResourceProvider<TResource> : IAsyncDisposable
    {
        public PlaywrightResourceProvider(Task<TResource> resource) => Resource = resource;

        public Task<TResource> Resource { get; }

        public async ValueTask DisposeAsync()
        {
            var resource = await Resource;
            if (resource is IAsyncDisposable asyncDisposable)
            {
                await asyncDisposable.DisposeAsync();
            }

            if (resource is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}
