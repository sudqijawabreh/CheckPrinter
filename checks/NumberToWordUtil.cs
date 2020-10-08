using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace checks
{
    static class Extensions
    {
        public static string SpaceFormat(this string value)
        {
            return (string.IsNullOrEmpty(value) ? string.Empty : " ") + value;
        }
    }
    public class NumberToWordUtil
    {
        public string NumberToWord(string value)
        {
            double.TryParse(value, out var number);
            var periodIndex = value.IndexOf(".");
            if (periodIndex >= 0)
            {
                var first = value.Substring(0, periodIndex);
                var second = (periodIndex < value.Length - 1) ? value.Substring(periodIndex + 1) : string.Empty;
                first = PadLeft(first);
                second = PadRight(second);
                var words = GetWords(first);
                var decimals = string.Join(" ",GetHundreds(second.ToArray().ToList()).Where(c => !string.IsNullOrEmpty(c)));
                if (!string.IsNullOrEmpty(words) && !string.IsNullOrEmpty(decimals))
                {
                    return words + " And " + decimals;
                }
                else if(!string.IsNullOrEmpty(words))
                {
                    return words;
                }
                else if(!string.IsNullOrEmpty(decimals))
                {
                    return decimals;
                }
            }
            else
            {
                var first = value;
                first = PadLeft(first);
                var words = GetWords(first);
                return words;
            }

            return string.Empty;
        }
        public string AmountInJDToWords(string value)
        {
            return CurrencyToWords(value, "JD", "Fils", "Only");
        }
        public string CurrencyToWords(string value, string prefix , string decimalSuffix, string suffix)
        {            
            double.TryParse(value, out var number);
            var periodIndex = value.IndexOf(".");
            if (periodIndex >= 0)
            {
                var first = value.Substring(0, periodIndex);
                var second = (periodIndex < value.Length - 1) ? value.Substring(periodIndex + 1) : string.Empty;
                first = PadLeft(first);
                second = PadRight(second);
                var words = GetWords(first);
                var decimals = string.Join(" ",GetHundreds(second.ToArray().ToList()).Where(c => !string.IsNullOrEmpty(c)));
                if (!string.IsNullOrEmpty(words) && !string.IsNullOrEmpty(decimals))
                {
                    return prefix + " " + words + " And " + decimals + " " + decimalSuffix + " " + suffix;
                }
                else if(!string.IsNullOrEmpty(words))
                {
                    return prefix + " " + words + " And No " + decimalSuffix + " " + suffix;
                }
                else if(!string.IsNullOrEmpty(decimals))
                {
                    return prefix + " " + decimals + " " + decimalSuffix + " " + suffix;
                }
            }
            else
            {
                var first = value;
                first = PadLeft(first);
                var words = GetWords(first);
                return words;
            }

            return string.Empty;


        }
        private string GetWords(string first)
        {
            var groupOfThrees = first.ToArray()
                .Select((e, i) => new { e, i })
                .GroupBy(x => x.i / 3)
                .Select((x, i) => new { i, e = x.Select(y => y.e).ToList() });

            return string.Join(" ", groupOfThrees.Select(g =>
            {
                var hundred = GetHundreds(g.e);
                var order = GetOrder(g.i);
                if (hundred.Where(x => !string.IsNullOrEmpty(x)).Any())
                    hundred.Add(order);
                return hundred;
            }).SelectMany(g => g).Where(g => !string.IsNullOrEmpty(g)));
        }

        private string GetOrder(int i)
        {
            switch (i)
            {
                case 0:
                    return "Million";
                case 1:
                    return "Thousand";
                case 2:
                    return string.Empty;
                default:
                    return string.Empty;
            }
        }

        private List<string> GetHundreds(List<char> e)
        {
            var hundred = e[0];
            var ten = e[1];
            var digit = e[2];
            var value = GetDigtit(hundred);
            var value1 = Rest(e);

            var result = new List<string> { value };
            if (!string.IsNullOrEmpty(value))
            {
                result.Add("Hundred");
            }
            result.AddRange(value1);
            return result;
        }

        private List<string> Rest(List<char> e)
        {
            var ten = e[1];
            var digit = e[2];
            if(ten == '0' && digit == '0')
            {
                return new List<string>();
            }
            else if (ten != '1')
            {
                return new List<string> { GetTen(ten), GetDigtit(digit) };
            }
            else
            {
                return new List<string> { GetTeens($"{ten}{digit}") };
            }

        }

        private string GetTeens(string v)
        {
            switch (v)
            {
                case "10":
                    return "Ten";
                case "11":
                    return "Eleven";
                case "12":
                    return "Twelve";
                case "13":
                    return "Thirteen";
                case "14":
                    return "Fourteen";
                case "15":
                    return "Fifteen";
                case "16":
                    return "Sixteen";
                case "17":
                    return "Seventeen";
                case "18":
                    return "Eighteen";
                case "19":
                    return "Nineteen";
            }

            return string.Empty;
        }

        private string GetTen(char ten)
        {
            switch (ten)
            {
                case '2':
                    return "Twenty";
                case '3':
                    return "Thirty";
                case '4':
                    return "Forty";
                case '5':
                    return "Fifty";
                case '6':
                    return "Sixty";
                case '7':
                    return "Seventy";
                case '8':
                    return "Eighty";
                case '9':
                    return "Ninety";
            }

            return string.Empty;
        }

        private string GetDigtit(char hundred)
        {
            switch (hundred)
            {
                case '1':
                    return "One";
                case '2':
                    return "Two";
                case '3':
                    return "Three";
                case '4':
                    return "Four";
                case '5':
                    return "Five";
                case '6':
                    return "Six";
                case '7':
                    return "Seven";
                case '8':
                    return "Eight";
                case '9':
                    return "Nine";
            }

            return string.Empty;
        }

        private string PadLeft(string value)
        {
            var numberOfPadding = (9 - value.Length);
            return string.Join("", Enumerable.Range(0, numberOfPadding).Select(i => "0")) + value;
        }

        private string PadRight(string value)
        {
            var numberOfPadding = (3 - value.Length);
            return value + string.Join("", Enumerable.Range(0, numberOfPadding).Select(i => "0"));
        }
    }

}
