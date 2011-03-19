using System;

namespace Twavatar
{
    public class AvatarUrlBuilder
    {
        public Uri BuildAvatarUrl(string username, Size size)
        {
            if (username == null) throw new ArgumentNullException("username");
            if (username.Length == 0) throw new ArgumentOutOfRangeException("username");

            var sizeKey = GetSizeKey(size);

            var uriBuilder = new UriBuilder("http://img.tweetimag.es")
            {
                Path = string.Format("i/{0}_{1}", username, sizeKey)
            };

            return uriBuilder.Uri;
        }

        static string GetSizeKey(Size size)
        {
            string sizeKey;
            switch (size)
            {
                case Size.Mini:
                    sizeKey = "m";
                    break;
                case Size.Normal:
                    sizeKey = "n";
                    break;
                case Size.Bigger:
                    sizeKey = "b";
                    break;
                case Size.Original:
                    sizeKey = "o";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("size", size, "Unsupported avatar size");
            }
            return sizeKey;
        }
    }
}