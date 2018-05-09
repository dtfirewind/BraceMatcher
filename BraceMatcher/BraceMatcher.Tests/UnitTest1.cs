using System;
using Xunit;
using BraceMatcher.Bus;

namespace BraceMatcher.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            SimpleBrace brace = new SimpleBrace();

            brace.braceString = "{)[()((thi)))]}";
            brace.startBracket = '(';
            brace.endBracket = ')';

            int result = brace.ValidateBraceString();

            Assert.Equal(1,result);
        }
    }
}
