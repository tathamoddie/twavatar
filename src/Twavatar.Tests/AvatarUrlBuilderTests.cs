using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Twavatar.Tests
{
    [TestClass]
    public class AvatarUrlBuilderTests
    {
        [TestMethod]
        public void BuildAvatarUrl_ShouldReturnMiniAvatar()
        {
            const string expected = "http://img.tweetimag.es/i/bob_m";
            var result = new AvatarUrlBuilder().BuildAvatarUrl("bob", AvatarSize.Mini);
            Assert.AreEqual(expected, result.AbsoluteUri);
        }

        [TestMethod]
        public void BuildAvatarUrl_ShouldReturnNormalAvatar()
        {
            const string expected = "http://img.tweetimag.es/i/bob_n";
            var result = new AvatarUrlBuilder().BuildAvatarUrl("bob", AvatarSize.Normal);
            Assert.AreEqual(expected, result.AbsoluteUri);
        }

        [TestMethod]
        public void BuildAvatarUrl_ShouldReturnBiggerAvatar()
        {
            const string expected = "http://img.tweetimag.es/i/bob_b";
            var result = new AvatarUrlBuilder().BuildAvatarUrl("bob", AvatarSize.Bigger);
            Assert.AreEqual(expected, result.AbsoluteUri);
        }

        [TestMethod]
        public void BuildAvatarUrl_ShouldReturnOriginalAvatar()
        {
            const string expected = "http://img.tweetimag.es/i/bob_o";
            var result = new AvatarUrlBuilder().BuildAvatarUrl("bob", AvatarSize.Original);
            Assert.AreEqual(expected, result.AbsoluteUri);
        }

        [TestMethod]
        public void BuildAvatarUrl_ShouldDefaultToNormalAvatar()
        {
            const string expected = "http://img.tweetimag.es/i/bob_n";
            var result = new AvatarUrlBuilder().BuildAvatarUrl("bob");
            Assert.AreEqual(expected, result.AbsoluteUri);
        }

        [TestMethod]
        public void BuildAvatarUrl_ShouldThrowArgumentNullExceptionForNullUsername()
        {
            try
            {
                new AvatarUrlBuilder().BuildAvatarUrl(null);
                Assert.Fail("Expected exception was never thrown");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("username", ex.ParamName);
            }
        }

        [TestMethod]
        public void BuildAvatarUrl_ShouldThrowArgumentOutOfRangeExceptionForEmptyUsername()
        {
            try
            {
                new AvatarUrlBuilder().BuildAvatarUrl(string.Empty);
                Assert.Fail("Expected exception was never thrown");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual("username", ex.ParamName);
            }
        }

        [TestMethod]
        public void BuildAvatarUrl_ShouldThrowArgumentOutOfRangeExceptionForUnrecognisedAvatarSize()
        {
            try
            {
                new AvatarUrlBuilder().BuildAvatarUrl("bob", (AvatarSize)4);
                Assert.Fail("Expected exception was never thrown");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual("avatarSize", ex.ParamName);
            }
        }
    }
}