namespace ECommerce.OrderServiceAPI.Domain.Extensions;

public static class FormatExtension
{

    public static string FormatTo(this string message, params object[] args)
    {
        return string.Format(message, args);
    }

    public static byte[] ImageToByte(this IFormFile? image)
    {
        var extensionList = new List<string>()
            {
                ".jpeg",
                ".jpg",
                ".png",
                ".jfif"
            };

        if (image.Length > 0)
        {
            var imageExtension = Path.GetExtension(image.FileName);

            if (!extensionList.Contains(imageExtension))
            {
                return null;
            }

            using (var stream = new MemoryStream())
            {
                image.CopyTo(stream);

                return stream.ToArray();
            }
        }

        return null;
    }
}
