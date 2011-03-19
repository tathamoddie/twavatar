using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Twavatar.Tests
{
    [TestClass]
    public class HtmlHelperExtensionsTests
    {
        [TestMethod]
        public void TwitterAvatar_ShouldReturnMiniAvatar()
        {
            const string expected = "<img alt=\"bob\" src=\"http://img.tweetimag.es/i/bob_m\" />";
            var result = HtmlHelperExtensions.TwitterAvatar(null, "bob", AvatarSize.Mini);
            Assert.AreEqual(expected, result.ToHtmlString());
        }

        [TestMethod]
        public void TwitterAvatar_ShouldReturnNormalAvatar()
        {
            const string expected = "<img alt=\"bob\" src=\"http://img.tweetimag.es/i/bob_n\" />";
            
            // ReSharper disable RedundantArgumentDefaultValue
            var result = HtmlHelperExtensions.TwitterAvatar(null, "bob", AvatarSize.Normal);
            // ReSharper restore RedundantArgumentDefaultValue

            Assert.AreEqual(expected, result.ToHtmlString());
        }

        [TestMethod]
        public void TwitterAvatar_ShouldReturnBiggerAvatar()
        {
            const string expected = "<img alt=\"bob\" src=\"http://img.tweetimag.es/i/bob_b\" />";
            var result = HtmlHelperExtensions.TwitterAvatar(null, "bob", AvatarSize.Bigger);
            Assert.AreEqual(expected, result.ToHtmlString());
        }

        [TestMethod]
        public void TwitterAvatar_ShouldReturnOriginalAvatar()
        {
            const string expected = "<img alt=\"bob\" src=\"http://img.tweetimag.es/i/bob_o\" />";
            var result = HtmlHelperExtensions.TwitterAvatar(null, "bob", AvatarSize.Original);
            Assert.AreEqual(expected, result.ToHtmlString());
        }

        [TestMethod]
        public void TwitterAvatar_ShouldDefaultToNormalAvatar()
        {
            const string expected = "<img alt=\"bob\" src=\"http://img.tweetimag.es/i/bob_n\" />";
            var result = HtmlHelperExtensions.TwitterAvatar(null, "bob");
            Assert.AreEqual(expected, result.ToHtmlString());
        }
    }
}