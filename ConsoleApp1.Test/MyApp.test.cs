using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using Xunit;

namespace ConsoleApp1.Test
{
    public class UnitTest1
    {
        readonly MyApp test = new MyApp();
        [Fact]
        public void CheckPassword_NoPasswordRestrictions_EvaluatesTrue()
        {
            Assert.True(test.CheckPassword("abcdeA2+", 0, 0, 0, 0, true, true));
        }

        [Fact]
        public void CheckPassword_MinSmallLettersRestricted_EvaluatesTrue()
        {
            Assert.True(test.CheckPassword("asda", 4, 0, 0, 0, true, true));
        }

        [Fact]
        public void CheckPassword_MinSmallLettersRestricted_EvaluatesFalse()
        {
            Assert.False(test.CheckPassword("asda", 5, 0, 0, 0, true, true));
        }

        [Fact]
        public void CheckPassword_MinBigLettersRestricted_EvaluatesTrue()
        {
            Assert.True(test.CheckPassword("asSASAD", 0, 4, 0, 0, true, true));
        }
        [Fact]
        public void CheckPassword_MinBigLettersRestricted_EvaluatesFalse()
        {
            Assert.False(test.CheckPassword("asSASAD+123';./", 0, 6, 0, 0, true, true));
        }

        [Fact]
        public void CheckPassword_MinDigits_EvaluatesTrue()
        {
            Assert.True(test.CheckPassword("assDSAD+1+2+3;./", 0, 0, 3, 0, true, true));
        }

        [Fact]
        public void CheckPassword_MinDigits_EvaluatesFalse()
        {
            Assert.False(test.CheckPassword("assDSAD++2+3;./", 0, 0, 3, 0, true, true));
        }

        [Fact]
        public void CheckPassword_MinSimbols_EvaluatesTrue()
        {
            Assert.True(test.CheckPassword("assDSAD+1+2+3;./", 0, 0, 0, 3, true, true));
        }

        [Fact]
        public void CheckPassword_MinSimbols_EvaluatesFalse()
        {
            Assert.False(test.CheckPassword("assDSAD++23;./", 0, 0, 0, 6, true, true));
        }

        [Fact]
        public void CheckPassword_CanHaveSimilar_EvaluatesFalse()
        {
            Assert.False(test.CheckPassword("assDOSAD++23;./", 0, 0, 0, 0, false, true));
        }

        [Fact]
        public void CheckPassword_CanHaveAmbiguous_EvaluatesFalse()
        {
            Assert.False(test.CheckPassword("assDAD++23;./", 0, 0, 0, 0, true, false));
        }

        //Margin Cases
        [Fact]
        public void CheckPassword_CombinationsOfRequirements_EvaluatesTrue()
        {
            Assert.True(test.CheckPassword("Abracadabra2345++", 4, 1, 4, 1, false, false));
        }

        [Fact]
        public void CheckPassword_CombinationsOfRequirements_EvaluatesFalse()
        {
            Assert.False(test.CheckPassword("AABBASDSAanbacasa++++{}io12345nas]/][]", 4, 4, 4, 4, true, false));
        }
    }
}
