using System.IO;
using System.Web.UI;
using Twavatar;

namespace System.Web.Mvc
{
    public static class TwavatarHtmlHelperExtensions
    {
        static readonly AvatarUrlBuilder builder = new AvatarUrlBuilder();

        public static MvcHtmlString TwitterAvatar(this HtmlHelper helper, string username, Size size = Size.Normal)
        {
            var url = builder.BuildAvatarUrl(username, size);

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