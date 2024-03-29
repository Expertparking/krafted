using System;
using System.Collections.Generic;
using Xunit;
using Assert = Krafted.Test.UnitTest.Xunit.AssertExtension;

namespace Krafted.UnitTest.Krafted
{
    [Trait(nameof(UnitTest), nameof(Krafted))]
    public class GuardAgainstTest
    {
        [Fact]
        public void ThrowIfNull_Null_ThrowsException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                object myParam = null;
                GuardAgainst.Null(myParam, nameof(myParam));
            });
            Assert.Equal("Parameter cannot be null. (Parameter 'myParam')", ex.Message);
        }

        [Fact]
        public void ThrowIfAnyNull_Null_ThrowsException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                object param1 = new object();
                object param2 = new object();
                object param3 = null;
                object param4 = null;
                GuardAgainst.AnyNull(() => param1, () => param2, () => param3, () => param4);
            });
            Assert.Equal("Parameter cannot be null. (Parameter 'param3')", ex.Message);
        }

        [Fact]
        public void ThrowIfNull_NotNull_DoesNotThrowsException()
        {
            Assert.DoesNotThrows(() =>
            {
                object param = new object();
                GuardAgainst.Null(param, nameof(param));
            });
        }

        [Fact]
        public void ThrowIfAnyNull_NotNull_DoesNotThrowsException()
        {
            Assert.DoesNotThrows(() =>
            {
                object param1 = new object();
                object param2 = new object();
                object param3 = new object();
                object param4 = new object();
                GuardAgainst.AnyNull(() => param1, () => param2, () => param3, () => param4);
            });
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ThrowIfNullOrEmpty_NullOrEmpty_ThrowsException(string myParam)
        {
            var ex = Assert.Throws<ArgumentNullException>(() => GuardAgainst.NullOrEmpty(myParam, nameof(myParam)));
            Assert.Equal("Parameter cannot be null or empty. (Parameter 'myParam')", ex.Message);

            var emptyList = new List<int>();
            var ex2 = Assert.Throws<ArgumentNullException>(() => GuardAgainst.NullOrEmpty(emptyList, nameof(emptyList)));
            Assert.Equal("Parameter cannot be null or empty. (Parameter 'emptyList')", ex2.Message);
        }

        [Fact]
        public void ThrowIfNullOrEmpty_NotEmpty_DoesNotThrowsException()
        {
            string param1 = "value";
            Assert.DoesNotThrows(() => GuardAgainst.NullOrEmpty(param1, nameof(param1)));

            var notEmptyList = new List<int> { 1, 2, 3, 4 };
            Assert.DoesNotThrows(() => GuardAgainst.NullOrEmpty(notEmptyList, nameof(notEmptyList)));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowIfNullOrWhiteSpace_NullOrWhiteSpace_ThrowsException(string myParam)
        {
            var ex = Assert.Throws<ArgumentNullException>(() => GuardAgainst.NullOrWhiteSpace(myParam, nameof(myParam)));
            Assert.Equal("Parameter cannot be null, empty or consists exclusively of white-space characters. (Parameter 'myParam')", ex.Message);
        }

        [Fact]
        public void ThrowIfNullOrWhiteSpace_NotEmpty_DoesNotThrowsException()
        {
            string param = "value";
            Assert.DoesNotThrows(() => GuardAgainst.NullOrWhiteSpace(param, nameof(param)));
        }
    }
}
