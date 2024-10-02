namespace e2e.infra;

public class Registry: IDisposable
{
    private readonly ISet<IDisposable> _created;
    private readonly Lazy<ApiProxy> _apiProxy;

    public Registry()
    {
        _created = new HashSet<IDisposable>();
        _apiProxy = new Lazy<ApiProxy>(() =>
        {
            var proxy = new ApiProxy();
            _created.Add(proxy);
            return proxy;
        });
    }

    public ApiProxy ApiProxy => _apiProxy.Value;

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        foreach (var disposable in _created)
        {
            disposable.Dispose();
        }
    }
}