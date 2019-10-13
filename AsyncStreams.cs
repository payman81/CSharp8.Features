using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CSharp8.Features
{
    public class AsyncStreams
    {
        public static async IAsyncEnumerable<int> GenerateSequence()
        {
            for (int i = 0; i < 20; i++)
            {
                await Task.Delay(100);
                yield return i;
            }
        }

    }

    class TestAsyncStreams
    {
        [Test]
        public async Task EnumerateAsyncStream()
        {
            await foreach (var item in AsyncStreams.GenerateSequence())
            {
                Console.WriteLine(item);
            }
        }
    }
}