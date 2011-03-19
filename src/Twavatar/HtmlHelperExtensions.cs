using System.IO;
using System.Web.Mvc;
using System.Web.UI;

namespace Twavatar
{
    public static class HtmlHelperExtensions
    {
        static readonly AvatarUrlBuilder builder = new AvatarUrlBuilder();

        public static MvcHtmlString TwitterAvatar(this HtmlHelper helper, string username, AvatarSize avatarSize = AvatarSize.Normal)
        {
            var url = builder.BuildAvatarUrl(username, avatarSize);

            using (var stringWriter = new StringWriter())
            using (var htmlWriter = new HtmlTextWriter(stringWriter))
            {
                htmlWriter.AddAttribute(HtmlTextWriterAttribute.Alt, username);
                htmlWriter.AddAttribute(HtmlTextWriterAttribute.Src, url.AbsoluteUri);
                htmlWriter.RenderBeginTag(HtmlTextWriterTag.Img);
                htmlWriter.RenderEndTag();

                return new MvcHtmlString(stringWriter.ToString());
            }
        }
    }
}