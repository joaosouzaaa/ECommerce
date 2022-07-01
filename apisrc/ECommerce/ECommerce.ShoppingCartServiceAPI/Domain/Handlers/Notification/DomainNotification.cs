namespace ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Notification;

public class DomainNotification
{
    public string Key { get; set; }
    public string Value { get; set; }

    public DomainNotification(string key, string value)
    {
        this.Key = key;
        this.Value = value;
    }

    public static IEnumerable<DomainNotification> Create(Dictionary<string, string> errors)
    {
        foreach (var error in errors)
            yield return new DomainNotification(error.Key, error.Value);
    }
}
