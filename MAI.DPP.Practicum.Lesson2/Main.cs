using MAI.DPP.Practicum.Lesson2.Extensions;
using Enumerable = System.Linq.Enumerable;

namespace MAI.DPP.Practicum.Lesson2;

public class Program
{
    public static void Main()
    {
        var range = Enumerable.Repeat(1, 3);
        var k = 2;

        var i = 0;
        

        using var enumerable = range.GenerateCombinations(k)
            .GetEnumerator();
        
        while (enumerable.MoveNext())
        {
            Console.WriteLine($"iteration: {i} \n combination [" + string.Join(", ", enumerable.Current) + "]");
            i++;            
        }
        

    }   
}