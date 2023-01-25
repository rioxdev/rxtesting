using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rxtesting.tests;

public static class TestDataShare
{
    public static IEnumerable<object[]> IsOddOrEven
    {
        get
        {
            yield return new object[] { 11, true };
            yield return new object[] { 16, false };
        }
    }

    public static IEnumerable<object[]> IsEvenOrOddExterna
    {
        get
        {
            var lines = System.IO.File.ReadAllLines("IsOddOrEvenSharedData.txt");
            return lines.Select(line =>
            {
                var array = line.Split(',');
                return new object[] { int.Parse(array[0]), bool.Parse(array[1]) };
            });

        }
    }

}