using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CSharp8.Features
{
    public class NullCoalescingAssignment
    {
        [Test]
        public void UseNullCoalescingAssignment()
        {
            List<int>? numbers = null;
            int? i = null;
            
            numbers ??= new List<int>();
            numbers.Add(i ??= 17);
            numbers.Add(i ??= 20);


            Assert.AreEqual("17 17", string.Join(" ", numbers)); 
            Assert.AreEqual(17, i);  // output: 17
        }
    }
}