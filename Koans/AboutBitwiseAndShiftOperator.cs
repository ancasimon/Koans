using Xunit;
using DotNetCoreKoans.Engine;
using System.Collections.Generic;
using System;

namespace DotNetCoreKoans.Koans
{
    public class AboutBitwiseAndShiftOperator : Koan
    {
        [Step(1)]
        public void BinaryAndOperator()
        {
            //Example
            //1 in binary is 0001
            //3 in binary is 0011
            //With & only taking the same one else take 0,so 1 & 3 it becomes 0001. /ANCA: WHY????
            //When 0001 convert to int it becomes 1
            int x = 4 & 4;
            
            Assert.Equal(4, x);
        }

        [Step(2)]
        public void BinaryOrOperator()
        {
            //Example
            //1 in binary is 0001
            //3 in binary is 0011
            //With | it will take any 1 if either one contains 1,so 1 & 3 it becomes 0011. //ANCA: In this example, do you mean "...so 1 | 3"??
            //When 0011 convert to int it becomes 3
            int x = 4 | 4;
            
            Assert.Equal(4, x);
        }

        [Step(3)]
        public void BinaryXOrOperator()
        {
            //Example
            //1 in binary is 0001
            //3 in binary is 0011
            //With ^ it will take 1 when it is 0-1, if it is 1-1 it will take 0,so 1 & 3 it becomes 0010.
            //When 0010 convert to int it becomes 2
            int x = 4 ^ 4; 

            Assert.Equal(0, x); //ANCA: Don't quite understand this .. so 4 in binary is 0100 ...SO then why is this 0??
            //maybe: binary 4 is 0100 - so it becomes 0000!!! I think ... 
        }

        [Step(4)]
        public void BinaryOnesComplementOperator()
        {
            //Example
            //With ~ it will convert positive number to negative number and add -1 to the number. //ANCA: IT ALSO ADDS!!!
            // ~1 become -2
            int x = ~4;

            Assert.Equal(-5, x);
        }

        [Step(5)]
        public void Combination1()
        {
            int x = ~3 & 8; //ANCA: So this would be -4 & 8...

			Assert.Equal(8, x);
        }

        [Step(6)]
        public void Combination2()
        {
            int x = 4 | 4 & 8;

            Assert.Equal(4, x); //Anca: so the lower of the 2 numbers???...
        }

        [Step(7)]
        public void Combination3()
        {
            int x = 3 & 4 ^ 4 & ~8;

            Assert.Equal(4, x);  //ANCA: WHY??? do you start from right to left??? NOPE _ Left to right in sequence!!!
        } 

        [Step(8)]
        public void BitwiseLeftShift()
        {
            //Example
            //4 in binary is 0100
            //when we try to 4 << 1
            //it becomes 1000
            //then it will become 8
            int x = 10 << 2;

            Assert.Equal(40, x);
        }

        [Step(9)]
        public void BitwiseRightShift()
        {
            //Example
            //4 in binary is 0100
            //when we try to 4 >> 1
            //it becomes 0010
            //then it will become 2
            int x = 12 >> 2;
            Assert.Equal(3, x);
        }

        [Step(10)]
        public void Combination4()
        {
            int x = (5 << 2) & 8 ^ 3;
            //5 = 0101
            //5 << 2 = 10100 => 20
            //8 = 1000
            //3 = 0011
            //10100 & 1000 = 1100 (which is the first parethentical calculation & 8!!!
            //1100 ^ 0011 = 0011 => 3 (which is the result of the row above ^ 3!!!!


            Assert.Equal(3, x);
        }

        [Step(11)]
        public void Combination5()
        {
            int x = (5 >> 2) & (~8) ^ 8;
            //5 >> 2 = 0101 => 00101
            //~8 = -9 //ANCA: What value should I be using after this step????
            //8 = 1000
            //9 = 1001
            //00101 & 1000 => 00101
            // 8 = 1000
            //00101 ^ 1000 => 0101

            Assert.Equal(0, x);

        }

        [Step(12)]
        public void Combination6()
        {
            int x = (8 << 2) & (~5) & 8 | 10 | (5 >> 1);

            Assert.Equal(FILL_ME_IN, x);
        }

        [Step(13)]
        public void AdditionWithoutPlusOrMinusOperator()
        {
            //Solve this problem without using + or -
            //This is a complicated problem. If you don't 
            //know how to solve it, try to Google it.
            int a = 15;
            int b = 4;

            //Here goes your implementation to set value to FILL_ME_IN
            Assert.Equal(FILL_ME_IN, 19);
        }
    }
}