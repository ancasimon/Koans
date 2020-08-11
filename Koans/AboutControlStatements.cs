using Xunit;
using DotNetCoreKoans.Engine;
using System.Collections.Generic;
using System;

namespace DotNetCoreKoans.Koans
{
    public class AboutControlStatements : Koan
    {
        [Step(1)]
        public void IfThenElseStatementsWithBrackets()
        {
            bool b;
            if (true)
            {
                b = true;
            }
            else
            {
                b = false;
            }

            Assert.Equal(true, b);                        //ANCA: Why is this true?? Unless if (true) means if there's a statement??? Hmm Possible answer: debuggin statement that is always true!
        }

        [Step(2)]
        public void IfThenElseStatementsWithoutBrackets()  //ANCA: They really mean curly braces here not brackets! :)
        {
            bool b;
            if(true)
                b = true;
            else
                b = false;

            Assert.Equal(true, b);

        }

        [Step(3)]
        public void IfThenStatementsWithBrackets()
        {
            bool b = false;
            if (true)
            {
                b = true;
            }

            Assert.Equal(true, b);
        }

        [Step(4)]
        public void IfThenStatementsWithoutBrackets()
        {
            bool b = false;
            if (true)
                b = true;

            Assert.Equal(true, b);
        }

        [Step(5)]
        public void WhyItsWiseToAlwaysUseBrackets()
        {
            bool b1 = false;
            bool b2 = false;

            int counter = 1;

            if (counter == 0)
                b1 = true;
                b2 = true;

			Assert.Equal(false, b1);
			Assert.Equal(true, b2); //ANA: WHY Is this true?????
        }

        [Step(6)]
        public void TernaryOperators()
        {
            Assert.Equal(1, (true ? 1 : 0));
            Assert.Equal(0, (false ? 1 : 0));
        }

        //This is out of place for control statements, but necessary for Koan 8
        [Step(7)]
        public void NullableTypes()
        {
            int i = 0;
            //i = null; //You can't do this

            int? nullableInt = null; //but you can do this
			Assert.NotNull(0);
			Assert.Null(null);
        }

        [Step(8)]
        public void AssignIfNullOperator()
        {
            int? nullableInt = null;

            int x = nullableInt ?? 42; //The null-coalescing operator ?? returns the value of its left-hand operand if it isn't null; otherwise, it evaluates the right-hand operand and returns its result. 
            //The ?? operator doesn't evaluate its right-hand operand if the left-hand operand evaluates to non-null. 

            Assert.Equal(42, x);
        }

        [Step(9)]
        public void IsOperators()
        {
            bool isKoan = false;
            bool isAboutControlStatements = false;
            bool isAboutMethods = false;

            var myType = this;

            if (myType is Koan)
                isKoan = true;

            if (myType is AboutControlStatements)
                isAboutControlStatements = true;

            if (myType is AboutMethods)
                isAboutMethods = true;

            Assert.Equal(true, isKoan);
            Assert.Equal(true, isAboutControlStatements);
            Assert.Equal(false, isAboutMethods);

        }

        [Step(10)]
        public void WhileStatement()
        {
            int i = 1;
            int result = 1;
            while (i <= 3)
            {
                result = result + i;
                i += 1;
            }
            Assert.Equal(7, result);
        }

        [Step(11)]
        public void BreakStatement()
        {
            int i = 1;
            int result = 1;
            while (true)
            {
                if (i > 3) { break; }
                result = result + i;
                i += 1;    
            }
            Assert.Equal(7, result); //ANCA: Keep going until i = 3!!
        }

        [Step(12)]
        public void ContinueStatement()
        {
            int i = 0;
            var result = new List<int>();
            while(i < 10)
            {
                i += 1;
                if ((i % 2) == 0) { continue; }
                result.Add(i);
            }
            Assert.Equal(new List<int> { 1, 3, 5, 7, 9 }, result); // so you want the values below 10 that are not divisible by 2!! Because if the number is divisible by 2 (has 0 remainder) > then, you continue and do NOT add it to the result list!!!
        }

        [Step(13)]
        public void ForStatement()
        {
            var list = new List<string> { "fish", "and", "chips" };
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = (list[i].ToUpper()); //this converts the entire word to uppercase!!
            }
            Assert.Equal(new List<string> { "FISH", "AND", "CHIPS" }, list);
        }

        [Step(14)]
        public void ForEachStatement()
        {
            var list = new List<string> { "fish", "and", "chips" };
            var finalList = new List<string>();
            foreach (string item in list)
            {
                finalList.Add(item.ToUpper());
            }
            Assert.Equal(new List<string> { "fish", "and", "chips"}, list);
            Assert.Equal(new List<string> { "FISH", "AND", "CHIPS" }, finalList);
        }

        [Step(15)]
        public void ModifyingACollectionDuringForEach()
        {
            var list = new List<string> { "fish", "and", "chips" };
            try
            {
                foreach (string item in list)
                {
                    list.Add(item.ToUpper());
                }
            }
            catch (Exception ex)
            {
                Assert.Equal(typeof(System.InvalidOperationException), ex.GetType()); //run the program and get the type of the error that gets displayed!! (like earlier!)
            }
        }

        [Step(16)]
        public void CatchingModificationExceptions()
        {
            string whoCaughtTheException = "No one";

            var list = new List<string> { "fish", "and", "chips" };
            try
            {
                foreach (string item in list)
                {
                    try
                    {
                        list.Add(item.ToUpper());
                    }
                    catch
                    {
                        whoCaughtTheException = "When we tried to Add it";
                    }
                }
            }
            catch
            {
                whoCaughtTheException = "When we tried to move to the next item in the list";
            }

            Assert.Equal("When we tried to move to the next item in the list", whoCaughtTheException); //NEED TO UNDERSTAND THIS BETTER!!!
        }
    }
}