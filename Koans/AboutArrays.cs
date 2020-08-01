using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using DotNetCoreKoans.Engine;
using Xunit.Sdk;

namespace DotNetCoreKoans.Koans
{
    public class AboutArrays : Koan
    {
        [Step(1)]
        public void CreatingArrays()
        {
            var empty_array = new object[] { };
            Assert.Equal(typeof(object[]), empty_array.GetType()); //MY NOTES: If you run the buid and check the error - you see type in the list of data in the error!

            //Note that you have to explicitly check for subclasses
            Assert.True(typeof(Array).IsAssignableFrom(empty_array.GetType()));

            Assert.Equal(0, empty_array.Length);
        }

        [Step(2)]
        public void ArrayLiterals()
        {
            //You don't have to specify a type if the arguments can be inferred
            var array = new [] { 42 };
            Assert.Equal(typeof(int[]), array.GetType());
            Assert.Equal(new int[] { 42 }, array);

            //Are arrays 0-based or 1-based?
            Assert.Equal(42, array[0]);

            //This is important because...
            Assert.True(array.IsFixedSize);

            //...it means we can't do this: array[1] = 13;
            Assert.Throws(typeof(IndexOutOfRangeException), delegate() { array[1] = 13; }); //MY NOTES: You get this error if you try to add an item to an array --which has a fixed size!!!

            //This is because the array is fixed at length 1. You could write a function
            //which created a new array bigger than the last, copied the elements over, and
            //returned the new array. Or you could do this:
            List<int> dynamicArray = new List<int>();   ///MY NOTES: Using a list!!!!
            dynamicArray.Add(42);
            Assert.Equal(array, dynamicArray.ToArray());

            dynamicArray.Add(13);
            Assert.Equal((new int[] { 42, 13}), dynamicArray.ToArray());
        }

        [Step(3)]
        public void AccessingArrayElements()
        {
            var array = new[] { "peanut", "butter", "and", "jelly" };

            Assert.Equal("peanut", array[0]);
            Assert.Equal("jelly", array[3]);
            
            //This doesn't work: Assert.Equal(FILL_ME_IN, array[-1]);
        }

        [Step(4)]
        public void SlicingArrays()
        {
            var array = new[] { "peanut", "butter", "and", "jelly" };

			Assert.Equal(new string[] { "peanut", "butter" }, array.Take(2).ToArray());
			Assert.Equal(new string[] { "butter", "and" }, array.Skip(1).Take(2).ToArray());
        }

        [Step(5)]
        public void PushingAndPopping()
        {
            var array = new[] { 1, 2 };
            var stack = new Stack(array); ///MY NOTES: Stack = collection that stores elements in LIFO style (Last In First Out) - !!literally like a tall stack of papers!! -  generic and non-generic stacks; allows null values and duplicate values. 
            stack.Push("last"); //MY NOTES: Stack allows these methods: Push() to add; Pop() & Peek() to retrieve -- also Contains() and Clear()
            Assert.Equal(new Object[] { "last", 2, 1 }, stack.ToArray()); //MY NOTES: XXXXXXIs it because it includes both strings and numbers that it has to be an OBJECT array??
            var poppedValue = stack.Pop();
            Assert.Equal("last", poppedValue); //MY NOTES: Here, it wants you to capture the value from the arracy that was removed/popped!
            Assert.Equal(new Object[] { 2, 1 }, stack.ToArray());
        }

        [Step(6)]
        public void Shifting()
        {
            //Shift == Remove First Element
            //Unshift == Insert Element at Beginning
            //C# doesn't provide this natively. You have a couple
            //of options, but we'll use the LinkedList<T> to implement //MY NOTES: LinkedList<T> = doubly linked list!--T specifies the element type of the linked list - ex: string, 
            var array = new[] { "Hello", "World" };
            var list = new LinkedList<string>(array); //MY NOTES: XXXXWhen to use LinkedList???

            list.AddFirst("Say");
            Assert.Equal(new[] { "Say", "Hello", "World" }, list.ToArray());

            list.RemoveLast();
            Assert.Equal(new[] { "Say", "Hello" }, list.ToArray());

            list.RemoveFirst();
            Assert.Equal(new[] { "Hello" }, list.ToArray());

            list.AddAfter(list.Find("Hello"), "World");
            Assert.Equal(new[] { "Hello", "World" }, list.ToArray());
        }

    }
}