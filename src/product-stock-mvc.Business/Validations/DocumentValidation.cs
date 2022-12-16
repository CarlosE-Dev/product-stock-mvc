namespace product_stock_mvc.Business.Validations
{
    public class IndividualDocumentValidation
    {
        public const int LengthIndividualDoc = 11;

        public static bool Validate(string individualDoc)
        {
            var docNumber = Utils.OnlyNumbers(individualDoc);

            if (!HasValidLength(docNumber)) return false;
            return !HasDuplicateDigits(docNumber) && HasValidCharacters(docNumber);
        }

        private static bool HasValidLength(string value)
        {
            return value.Length == LengthIndividualDoc;
        }

        private static bool HasDuplicateDigits(string value)
        {
            string[] invalidNumbers =
            {
                "00000000000",
                "11111111111",
                "22222222222",
                "33333333333",
                "44444444444",
                "55555555555",
                "66666666666",
                "77777777777",
                "88888888888",
                "99999999999"
            };
            return invalidNumbers.Contains(value);
        }

        private static bool HasValidCharacters(string value)
        {
            var number = value.Substring(0, LengthIndividualDoc - 2);
            var digitChecker = new DigitChecker(number)
                .WithMultipliersMax(2, 11)
                .Replacing("0", 10, 11);
            var firstDigit = digitChecker.CalculateDigit();
            digitChecker.AddDigit(firstDigit);
            var secondDigit = digitChecker.CalculateDigit();

            return string.Concat(firstDigit, secondDigit) == value.Substring(LengthIndividualDoc - 2, 2);
        }
    }

    public class LegalDocumentValidation
    {
        public const int LengthLegalDoc = 14;

        public static bool Validate(string doc)
        {
            var legalDocNumbers = Utils.OnlyNumbers(doc);

            if (!HasValidLength(legalDocNumbers)) return false;
            return !HasDuplicatedDigits(legalDocNumbers) && HasValidDigits(legalDocNumbers);
        }

        private static bool HasValidLength(string value)
        {
            return value.Length == LengthLegalDoc;
        }

        private static bool HasDuplicatedDigits(string value)
        {
            string[] invalidNumbers =
            {
                "00000000000000",
                "11111111111111",
                "22222222222222",
                "33333333333333",
                "44444444444444",
                "55555555555555",
                "66666666666666",
                "77777777777777",
                "88888888888888",
                "99999999999999"
            };
            return invalidNumbers.Contains(value);
        }

        private static bool HasValidDigits(string value)
        {
            var number = value.Substring(0, LengthLegalDoc - 2);

            var digitChecker = new DigitChecker(number)
                .WithMultipliersMax(2, 9)
                .Replacing("0", 10, 11);
            var firstDigit = digitChecker.CalculateDigit();
            digitChecker.AddDigit(firstDigit);
            var secondDigit = digitChecker.CalculateDigit();

            return string.Concat(firstDigit, secondDigit) == value.Substring(LengthLegalDoc - 2, 2);
        }
    }

    public class DigitChecker
    {
        private string _number;
        private const int Module = 11;
        private readonly List<int> _multipliers = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9 };
        private readonly IDictionary<int, string> _replacements = new Dictionary<int, string>();
        private bool _moduleComplement = true;

        public DigitChecker(string number)
        {
            _number = number;
        }

        public DigitChecker WithMultipliersMax(int firstMultiplier, int lastMultiplier)
        {
            _multipliers.Clear();
            for (var i = firstMultiplier; i <= lastMultiplier; i++)
                _multipliers.Add(i);

            return this;
        }

        public DigitChecker Replacing(string replacer, params int[] digits)
        {
            foreach (var i in digits)
            {
                _replacements[i] = replacer;
            }
            return this;
        }

        public void AddDigit(string digit)
        {
            _number = string.Concat(_number, digit);
        }

        public string CalculateDigit()
        {
            return !(_number.Length > 0) ? "" : GetDigitSum();
        }

        private string GetDigitSum()
        {
            var sum = 0;
            for (int i = _number.Length - 1, m = 0; i >= 0; i--)
            {
                var product = (int)char.GetNumericValue(_number[i]) * _multipliers[m];
                sum += product;

                if (++m >= _multipliers.Count) m = 0;
            }

            var mod = (sum % Module);
            var result = _moduleComplement ? Module - mod : mod;

            return _replacements.ContainsKey(result) ? _replacements[result] : result.ToString();
        }
    }

    public class Utils
    {
        public static string OnlyNumbers(string value)
        {
            var onlyNumber = "";
            foreach (var s in value)
            {
                if (char.IsDigit(s))
                {
                    onlyNumber += s;
                }
            }
            return onlyNumber.Trim();
        }
    }
}
