using System;

namespace Twavatar
{
    public class AvatarUrlBuilder
    {
        public Uri BuildAvatarUrl(string username, AvatarSize avatarSize)
        {
            if (username == null) throw new ArgumentNullException("username");
            if (username.Length == 0) throw new ArgumentOutOfRangeException("username");

            var sizeKey = GetSizeKey(avatarSize);

            var uriBuilder = new UriBuilder("http://img.tweetimag.es")
            {
                Path = string.Format("i/{0}_{1}", username, sizeKey)
            };

            return uriBuilder.Uri;
        }

        static string GetSizeKey(AvatarSize avatarSize)
        {
            string sizeKey;
            switch (avatarSize)
            {
                case AvatarSize.Mini:
                    sizeKey = "m";
                    break;
                case AvatarSize.Normal:
                    sizeKey = "n";
                    break;
                case AvatarSize.Bigger:
                    sizeKey = "b";
                    break;
                case AvatarSize.Original:
                    sizeKey = "o";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("avatarSize", avatarSize, "Unsupported avatar size");
            }
            return sizeKey;
        }
    }
}