using System.Globalization;

namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void IsPassword_returns_false_if_has_lees_than_8_characters()
        {
            var registerViewModel = new RegisterViewModel();

            bool result = registerViewModel.IsPasswordSecure("17743");

            Assert.False(result);
        }
        [Fact]
        public void IsPassword_returns_false_if_password_doses_not_not_contains_uppercase_character()
        {
            var registerViewModel = new RegisterViewModel();

            bool result = registerViewModel.IsPasswordSecure("17743a");

            Assert.False(result);
        }
        [Fact]
        public void IsPasswordSecure_returns_true_if_password_contains_an_uppercase_character_and_a_symbol()
        {
            var registerViewModel = new RegisterViewModel();

            bool result = registerViewModel.IsPasswordSecure("Q23D@45AAAAA");

            Assert.True(result);

        }
    }

    internal class RegisterViewModel
    {
        internal bool IsPasswordSecure(string password)
        {
            if (password.Length < 8)
            {
                return false;
            }
            if (!TieneMayusculas(password))
            {
                return false;
            }
            if (!TieneSimbolos(password))
            {
                return false;
            }
            return true;
        }
        private bool TieneMayusculas(string password)
        {
            return password.Any(c => char.IsLetter(c) && char.IsUpper(c));
        }
        private bool TieneSimbolos(string password)
        {
            return password.Any(c => char.IsSymbol(c) || !char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c));
        }

        
    }
}