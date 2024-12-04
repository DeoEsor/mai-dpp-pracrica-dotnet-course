namespace MAI.DPP.Practicum.Lesson2.Extensions;

public static class EnumerableExtensions
{
    public static IEnumerable<IEnumerable<T>> GenerateCombinations<T>(
        this IEnumerable<T> source,
        int k,
        IEqualityComparer<T>? equalityComparer = null)
    {
        var inputList = source.ToList(); // для оптимизации // материлизация
        
        equalityComparer ??= EqualityComparer<T>.Default;
        
        
        for (var i = 0; i < inputList.Count -1; i++)
        {
            for (var j = i + 1; j < inputList.Count; j++)
            {
                if (equalityComparer.Equals(inputList[i], inputList[k]))
                {
                    throw new ArgumentException($"нашлись дубли в колекции, {i}, {j}");
                }
            }   
        }
        
        return generateCombinations(inputList, k, equalityComparer);
    }

    private static IEnumerable<IEnumerable<T>> generateCombinations<T>(
        this IEnumerable<T> source,
        int k,
        IEqualityComparer<T>? equalityComparer = null)
    {
        var inputList = source.ToList(); // для оптимизации // материлизация
        // corner
        if (k < 1)
        {
            yield return Enumerable.Empty<T>();
            yield break;
        }

        for (var i = 0; i < inputList.Count; i++)
        {
            if (k == 1)
            {
                Console.WriteLine("step");
                yield return new T[] { inputList[i] };
            }

            foreach (var subsequence in inputList.Skip(i).generateCombinations(k - 1, equalityComparer))
            {
                Console.WriteLine("step");
                yield return new T[] { inputList[i] }.Concat(subsequence);
            }
        }
    }
}