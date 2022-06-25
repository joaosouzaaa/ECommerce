using ECommerce.IdentityServiceAPI.Domain.Enum;
using System.ComponentModel;

namespace ECommerce.IdentityServiceAPI.Domain.Extensions;

public static class MessageExtension
{
    public static string Description(this EMessage message)
    {
        var type = message.GetType();
        var memberInfo = type.GetMember(message.ToString());
        var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

        return ((DescriptionAttribute)attributes[0]).Description;
    }
}