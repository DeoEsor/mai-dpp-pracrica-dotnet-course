using MAI.DPP.Practicum.Lesson3.Extensions;

namespace MAI.DPP.Practicum.Lesson3.SortingAlgorithms;


public static class BubbleSort
{
    public static T[] Sort<T>( T[] source, Comparison<T> comparison)
    {
        for (var i = 0; i < source.Length - 1; i++) {
            var swapped = false;
            for (var j = i; j < source.Length - 1; j++)
            {
                if (comparison(source[j], source[j + 1]) <= 0) 
                    continue;
                (source[j], source[j + 1]) = (source[j + 1], source[j]);
                swapped = true;
            }
            if (swapped == false)
                break;
        }
        return source;
    }
}