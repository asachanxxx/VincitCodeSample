using System.ComponentModel.DataAnnotations.Schema;
using Cushwake.TreasuryTool.Domain.Common.Interfaces;

namespace Cushwake.TreasuryTool.Domain.Common.BaseEntities;

public abstract class BaseEntity : IConfirmToCwDbTableStandard
{
    public int Id
    {
        get; set;
    }

    private readonly List<BaseEvent> _domainEvents = new();

    [NotMapped]
    public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(BaseEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(BaseEvent domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected static string GetValidText(string text, string param, int? maxLength = null)
    {
        text = text.Trim();
        if (string.IsNullOrEmpty(text))
        {
            throw new ArgumentException("Text is invalid.", param);
        }
        if (maxLength is not null && text.Length > maxLength)
        {
            throw new ArgumentException($"Text '{text}' is too long (>{maxLength}).", param);
        }
        return text;
    }

    protected static string? GetValidNullableText(string? text, string param, int? maxLength = null)
    {
        if (text is null)
        {
            return null;
        }

        return GetValidText(text, param, maxLength);
    }

    protected static int GetValidId(int? id, string param, int? upperLimit = null)
    {
        if (id is null)
        {
            throw new ArgumentNullException(param);
        }
        if (id <= 0)
        {
            throw new ArgumentException("Value is invalid.", param);
        }
        if (upperLimit is not null && id > upperLimit)
        {
            throw new ArgumentException($"Value '{id}' is too high (>{upperLimit}).", param);
        }
        return id.Value;
    }

    protected static T GetValidEnum<T>(string type, string param) where T : struct
    {
        if (!typeof(T).IsEnum)
        {
            throw new ArgumentException("T must be an Enum type");
        }

        if (!Enum.TryParse(type, out T validEnum))
        {
            throw new ArgumentException("Enum type text is invalid.", param);
        }

        return validEnum;
    }

    protected static string GetValidEnumText<T>(string type, string param) where T : struct
    {
        GetValidEnum<T>(type, param);

        return type;
    }
}
