using MudBlazor;

namespace EmailGenerator.WebUI.Services;

public class BreadcrumbService
{
    public List<BreadcrumbItem> Current { get; set; } = new();

    public Action? Changed { get; set; }

    public void SetCurrent(params BreadcrumbItem[] items)
    {
        Current.Clear();
        Current.AddRange(items);

        Changed?.Invoke();
    }

    public void Clear()
    {
        Current.Clear();

        Changed?.Invoke();
    }
}