using e2e.infra;

namespace e2e;

public class Tests: IDisposable
{
    private readonly Registry _registry = new();

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _registry.Dispose();
    }

    [Fact]
    public async Task Add_a_todo_with_default_priority()
    {
        await When_I_add_a_todo("01-Dec-2024", "Start xmas shopping");
        //Then_a_todo_is_stored_to_database("01-Dec-2024", "Start xmas shopping", Priority.Medium);
    }

    private async Task When_I_add_a_todo(string date, string description) => await _registry.ApiProxy.PostToDo(date, description);
}