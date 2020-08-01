using Xunit;
using DotNetCoreKoans.Engine;
using System;
using System.Globalization;

namespace DotNetCoreKoans.Koans
{
    public class AboutStrings : Koan
    {
        //Note: This is one of the longest katas and, perhaps, one
        //of the most important. String behavior in .NET is not
        //always what you expect it to be, especially when it comes
        //to concatenation and newlines, and is one of the biggest
        //causes of memory leaks in .NET applications

        [Step(1)]
        public void DoubleQuotedStringsAreStrings()
        {
            var str = "Hello, World";
            Assert.Equal(typeof(string), str.GetType());
        }

        [Step(2)]
        public void SingleQuotedStringsAreNotStrings()
        {
            var str = 'H';
            Assert.Equal(typeof(char), str.GetType());
        }

        [Step(3)]
        public void CreateAStringWhichContainsDoubleQuotes()
        {
            var str = "Hello, \"World\"";
            Assert.Equal(14, str.Length);  //MY NOTES: You don't count the backslashes because they are just there to show that you are making an exception for the doible quotes that follow! 
        }

        [Step(4)]
        public void AnotherWayToCreateAStringWhichContainsDoubleQuotes()
        {
            //The @ symbol creates a 'verbatim string literal'. 
            //Here's one thing you can do with it:
            var str = @"Hello, ""World""";
            Assert.Equal(14, str.Length); //MY NOTES: When you preceed with @, you can use DOUBLE set of quotation marks to indicate a single set of quotation marks within a string!
        }

        [Step(5)]
        public void VerbatimStringsCanHandleFlexibleQuoting()
        {
            var strA = @"Verbatim Strings can handle both ' and "" characters (when escaped)";
            var strB = "Verbatim Strings can handle both ' and \" characters (when escaped)";
            Assert.Equal(true, strA.Equals(strB));
        }

        [Step(6)]
        public void VerbatimStringsCanHandleMultipleLinesToo()
        {
            //Tip: What you create for the literal string will have to 
            //escape the newline characters. For Windows, that would be
            // \r\n. If you are on non-Windows, that would just be \n.
            //We'll show a different way next.
            var verbatimString = @"I
am a
broken line";

            // Make sure to use a literal string.
            // Escaped characters in verbatim strings are covered later.
            var literalString = "I\r\nam a\r\nbroken line";
            Assert.Equal(20, verbatimString.Length); //MY NOTES: So return counts as a character??
            Assert.Equal(literalString, verbatimString);
        }

        [Step(7)]
        public void ACrossPlatformWayToHandleLineEndings()
        {
            //Since line endings are different on different platforms
            //(\r\n for Windows, \n for Linux) you shouldn't just type in
            //the hardcoded escape sequence. A much better way
            //(We'll handle concatenation and better ways of that in a bit)
            var literalString = "I" + System.Environment.NewLine + "am a" + System.Environment.NewLine + "broken line";
            var verbatimString = @"I
am a
broken line";
            Assert.Equal(literalString, verbatimString);
        }

        [Step(8)]
        public void PlusWillConcatenateTwoStrings()
        {
            var str = "Hello, " + "World";
            Assert.Equal("Hello, World", str);
        }

        [Step(9)]
        public void PlusConcatenationWillNotModifyOriginalStrings()
        {
            var strA = "Hello, ";
            var strB = "World";
            var fullString = strA + strB;
            Assert.Equal("Hello, ", strA);
            Assert.Equal("World", strB);
        }

        [Step(10)]
        public void PlusEqualsWillModifyTheTargetString()
        {
            var strA = "Hello, ";
            var strB = "World";
            strA += strB;
            Assert.Equal("Hello, World", strA);
            Assert.Equal("World", strB);
        }

        [Step(11)]
        public void StringsAreReallyImmutable()
        {
            //So here's the thing. Concatenating strings is cool
            //and all. But if you think you are modifying the original
            //string, you'd be wrong. 

            var strA = "Hello, ";
            var originalString = strA;
            var strB = "World";
            strA += strB;
            Assert.Equal("Hello, ", originalString);

            //What just happened? Well, the string concatenation actually
            //takes strA and strB and creates a *new* string in memory       MY NOTES: IMPORTANT!!!!
            //that has the new value. It does *not* modify the original
            //string. This is a very important point - if you do this kind
            //of string concatenation in a tight loop, you'll use a lot of memory
            //because the original string will hang around in memory until the
            //garbage collector picks it up. Let's look at a better way
            //when dealing with lots of concatenation
        }

        [Step(12)]
        public void YouDoNotNeedConcatenationToInsertVariablesInAString()
        {
            var world = "World";
            var str = String.Format("Hello, {0}", world);
            Assert.Equal("Hello, World", str);
        }

        [Step(13)]
        public void AnyExpressionCanBeUsedInFormatString()
        {
            var str = String.Format("The square root of 9 is {0}", Math.Sqrt(9));
            Assert.Equal("The square root of 9 is 3", str);
        }

        [Step(14)]
        public void StringsCanBePaddedToTheLeft()
        {
            //You can modify the value inserted into the result
            var str = string.Format("{0,3:}", "x"); //MY NOTES: SO this takes the first parameter that follows (that's what the 0 in the curly braces {} indicates and puts it in index position 3 - because it has a specified width of 3 chars 0 that's what the 3 in the curly braces indicates!!!
            Assert.Equal("  x", str);
        }

        [Step(15)]
        public void StringsCanBePaddedToTheRight()
        {
            var str = string.Format("{0,-3:}", "x"); //MY NOTES: By default,strings are right-aligned within their field; to left-align strings in a field, you preface the field width with a negative sign!
            Assert.Equal("x  ", str); //We indicate that here with the extra spaces on the right. 
        }

        [Step(16)]
        public void SeparatorsCanBeAdded()
        {
            var str = string.Format("{0:n}", 123456);  //n is a standard numeric format string for number > results in integral and decimal digits, group separators, and a decimal separator with optional negative sign: 1234.567("N", en-US) -> 1,234.57
            Assert.Equal("123,456.00", str); //because this example doesn't include a period > then its decimals ar .00!
        }

        [Step(17)]
        public void CurrencyDesignatorsCanBeAdded()
        {
            var str = string.Format("{0:c}", 123456); // c is a a standard numeric format string for currency! 123.456("C", en-US) -> $123.46
            Assert.Equal("$123,456.00", str);
        }

        [Step(18)]
        public void NumberOfDisplayedDecimalsCanBeControlled()
        {
            var str = string.Format("{0:.##}", 12.3456); //MY NOTES: ## tells you to stop at 2 decimal points  BUT you need to round up!
            Assert.Equal("12.35", str);
        }

        [Step(19)]
        public void MinimumNumberOfDisplayedDecimalsCanBeControlled()
        {
            var str = string.Format("{0:.00}", 12.3);
            Assert.Equal("12.30", str);
        }

        [Step(20)]
        public void BuiltInDateFormatters()
        {
            var str = string.Format("{0:t}", DateTime.Parse("12/16/2011 2:35:02 PM", CultureInfo.InvariantCulture)); //t = short time pattern: 2009-06-15T13:45:30 > 1:45 PM (en-US)
            Assert.Equal("2:35 PM", str); //The "t" standard format specifier represents a custom date and time format string that is defined by the current DateTimeFormatInfo.ShortTimePattern property.
        }

        [Step(21)]
        public void CustomDateFormatters()
        {
            var str = string.Format("{0:t m}", DateTime.Parse("12/16/2011 2:35:02 PM", CultureInfo.InvariantCulture)); //"m" is the minute from 0 through 59; t is the custom time format specifier and indicates P for pm and m indicates the minute
            Assert.Equal("P 35", str);
        }
        //These are just a few of the formatters available. Dig some and you may find what you need.

        [Step(22)]
        public void ABetterWayToConcatenateLotsOfStrings()
        {
            //Concatenating lots of strings is a Bad Idea(tm). If you need to do that, then consider StringBuilder.
            var strBuilder = new System.Text.StringBuilder(); //StringBuilder is a class that represents a string-like object whose value is a mutable string of characters. 
            strBuilder.Append("The ");
            strBuilder.Append("quick ");
            strBuilder.Append("brown ");
            strBuilder.Append("fox ");
            strBuilder.Append("jumped ");
            strBuilder.Append("over ");
            strBuilder.Append("the ");
            strBuilder.Append("lazy ");
            strBuilder.Append("dog.");
            var str = strBuilder.ToString();
            Assert.Equal("The quick brown fox jumped over the lazy dog.", str);

            //String.Format and StringBuilder will be more efficient than concatenation. Prefer them.
        }

        [Step(23)]
        public void StringBuilderCanUseFormatAsWell()
        {
            var strBuilder = new System.Text.StringBuilder();
            strBuilder.AppendFormat("{0} {1} {2}", "The", "quick", "brown");
            strBuilder.AppendFormat("{0} {1} {2}", "jumped", "over", "the");
            strBuilder.AppendFormat("{0} {1}.", "lazy", "dog");
            var str = strBuilder.ToString();
            Assert.Equal("The quick brownjumped over thelazy dog.", str); //MY NOTES: PLEASE NOTE: NO spaces between appended phrases!!
        }

        [Step(24)]
        public void LiteralStringsInterpretsEscapeCharacters()
        {
            var str = "\n";
            Assert.Equal(1, str.Length);
        }

        [Step(25)]
        public void VerbatimStringsDoNotInterpretEscapeCharacters()
        {
            var str = @"\n";
            Assert.Equal(2, str.Length);
        }

        [Step(26)]
        public void VerbatimStringsStillDoNotInterpretEscapeCharacters()
        {
            var str = @"\\\";
            Assert.Equal(3, str.Length);
        }

        [Step(27)]
        public void YouCanGetASubstringFromAString()
        {
            var str = "Bacon, lettuce and tomato";
            Assert.Equal("tomato", str.Substring(19));
            Assert.Equal("let", str.Substring(7, 3));
        }

        [Step(28)]
        public void YouCanGetASingleCharacterFromAString()
        {
            var str = "Bacon, lettuce and tomato";
            Assert.Equal('B', str[0]);
        }

        [Step(29)]
        public void SingleCharactersAreRepresentedByIntegers()
        {
            Assert.Equal(97, 'a');
            Assert.Equal(98, 'b');
            Assert.Equal(true, 'b' == ('a' + 1));
        }

        [Step(30)]
        public void StringsCanBeSplit()
        {
            var str = "Sausage Egg Cheese";
            string[] words = str.Split(); //MY NOTES: Does this mean that the default for Split is a space??
            Assert.Equal(new[] { "Sausage", "Egg", "Cheese" }, words);
        }

        [Step(31)]
        public void StringsCanBeSplitUsingCharacters()
        {
            var str = "the:rain:in:spain";
            string[] words = str.Split(':');
            Assert.Equal(new[] { "the", "rain", "in", "spain" }, words);
        }

        [Step(32)]
        public void StringsCanBeSplitUsingRegularExpressions()
        {
            var str = "the:rain:in:spain";
            var regex = new System.Text.RegularExpressions.Regex(":");
            string[] words = regex.Split(str);
            Assert.Equal(new[] { "the", "rain", "in", "spain" }, words); //MY NOTES: Need to learn more about Regex!!!!

            //A full treatment of regular expressions is beyond the scope
            //of this tutorial. The book "Mastering Regular Expressions"
            //is highly recommended to be on your bookshelf
        }

        [Step(33)]
        public void YouCanInterpolateVariablesIntoAString()
        {
            var name = "John Doe";
            var age = 33;
            var str = $"Mr. {name} is {age} years old";
            Assert.Equal("Mr. John Doe is 33 years old", str);
        }
    }
}
