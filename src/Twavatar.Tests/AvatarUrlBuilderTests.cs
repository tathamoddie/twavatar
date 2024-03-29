﻿using System;
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
            var result = new AvatarUrlBuilder().BuildAvatarUrl("bob", Size.Mini);
            Assert.AreEqual(expected, result.AbsoluteUri);
        }

        [TestMethod]
        public void BuildAvatarUrl_ShouldReturnNormalAvatar()
        {
            const string expected = "http://img.tweetimag.es/i/bob_n";
            var result = new AvatarUrlBuilder().BuildAvatarUrl("bob", Size.Normal);
            Assert.AreEqual(expected, result.AbsoluteUri);
        }

        [TestMethod]
        public void BuildAvatarUrl_ShouldReturnBiggerAvatar()
        {
            const string expected = "http://img.tweetimag.es/i/bob_b";
            var result = new AvatarUrlBuilder().BuildAvatarUrl("bob", Size.Bigger);
            Assert.AreEqual(expected, result.AbsoluteUri);
        }

        [TestMethod]
        public void BuildAvatarUrl_ShouldReturnOriginalAvatar()
        {
            const string expected = "http://img.tweetimag.es/i/bob_o";
            var result = new AvatarUrlBuilder().BuildAvatarUrl("bob", Size.Original);
            Assert.AreEqual(expected, result.AbsoluteUri);
        }

        [TestMethod]
        public void BuildAvatarUrl_ShouldThrowArgumentNullExceptionForNullUsername()
        {
            try
            {
                new AvatarUrlBuilder().BuildAvatarUrl(null, Size.Normal);
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
                new AvatarUrlBuilder().BuildAvatarUrl(string.Empty, Size.Normal);
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
                new AvatarUrlBuilder().BuildAvatarUrl("bob", (Size)4);
                Assert.Fail("Expected exception was never thrown");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual("size", ex.ParamName);
            }
        }
    }
}