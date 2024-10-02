using System.Net.Http.Json;

namespace e2e.infra;

public class ApiProxy: IDisposable
{
    private readonly HttpClient _http;

    public ApiProxy()
    {
        _http = new HttpClient
        {
            BaseAddress = Config.ApiBaseAddress,
            Timeout = Config.ApiTimeout
        };
    }

    void IDisposable.Dispose()
    {
        GC.SuppressFinalize(this);
        _http.Dispose();
    }

    public async Task PostToDo(string date, string description)
    {
        var response = await _http.PostAsJsonAsync("/todo",
            new
            {
                date = date,
                description = description
            });

        response.EnsureSuccessStatusCode();
    }
}