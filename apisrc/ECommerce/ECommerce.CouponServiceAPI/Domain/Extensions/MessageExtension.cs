using System.ComponentModel;
using System.Reflection;

namespace ECommerce.CouponServiceAPI.Domain.Extensions;

public static class MessageExtension
{
    public static string Description<T>(this T message)
    {
        var type = message.GetType();
        var memberInfo = type.GetMember(message.ToString());
        var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

        return ((DescriptionAttribute)attributes[0]).Description;
    }

    public static T GetEnumValue<T>(this string description)
    {
        var type = typeof(T);
        if (!type.GetTypeInfo().IsEnum)
            throw new ArgumentException();

        var field = type.GetFields().SelectMany(f => f
                    .GetCustomAttributes(typeof(DescriptionAttribute), false), (f, a) => new { Field = f, Att = a })
                    .Where(a => ((DescriptionAttribute)a.Att).Description == description)
                    .SingleOrDefault();

        return field == null ? default(T) : (T)field.Field.GetRawConstantValue();
    }
}