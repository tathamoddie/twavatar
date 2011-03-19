using System.Web.Mvc;
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
            var result = TwavatarHtmlHelperExtensions.TwitterAvatar(null, "bob", Size.Mini);
            Assert.AreEqual(expected, result.ToHtmlString());
        }

        [TestMethod]
        public void TwitterAvatar_ShouldReturnNormalAvatar()
        {
            const string expected = "<img alt=\"bob\" src=\"http://img.tweetimag.es/i/bob_n\" />";
            
            // ReSharper disable RedundantArgumentDefaultValue
            var result = TwavatarHtmlHelperExtensions.TwitterAvatar(null, "bob", Size.Normal);
            // ReSharper restore RedundantArgumentDefaultValue

            Assert.AreEqual(expected, result.ToHtmlString());
        }

        [TestMethod]
        public void TwitterAvatar_ShouldReturnBiggerAvatar()
        {
            const string expected = "<img alt=\"bob\" src=\"http://img.tweetimag.es/i/bob_b\" />";
            var result = TwavatarHtmlHelperExtensions.TwitterAvatar(null, "bob", Size.Bigger);
            Assert.AreEqual(expected, result.ToHtmlString());
        }

        [TestMethod]
        public void TwitterAvatar_ShouldReturnOriginalAvatar()
        {
            const string expected = "<img alt=\"bob\" src=\"http://img.tweetimag.es/i/bob_o\" />";
            var result = TwavatarHtmlHelperExtensions.TwitterAvatar(null, "bob", Size.Original);
            Assert.AreEqual(expected, result.ToHtmlString());
        }

        [TestMethod]
        public void TwitterAvatar_ShouldDefaultToNormalAvatar()
        {
            const string expected = "<img alt=\"bob\" src=\"http://img.tweetimag.es/i/bob_n\" />";
            var result = TwavatarHtmlHelperExtensions.TwitterAvatar(null, "bob");
            Assert.AreEqual(expected, result.ToHtmlString());
        }
    }
}