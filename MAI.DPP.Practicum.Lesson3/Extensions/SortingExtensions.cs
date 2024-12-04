using System.Security.Cryptography;
using MAI.DPP.Practicum.Lesson3.SortingAlgorithms;

namespace MAI.DPP.Practicum.Lesson3.Extensions;

public static class SortingExtensions
{
    public static T[] Sort<T>(
        this T[] source,
        OrderBy orderBy,
        SortinhAlgorithmType sortingAlgorithmType)
    where T : IComparable<T>
    {
        return Sort(source, orderBy, sortingAlgorithmType, Comparer<T>.Default);
    }
    
    public static T[] Sort<T>(
        this T[] source,
        OrderBy orderBy,
        SortinhAlgorithmType sortingAlgorithmType,
        IComparer<T> comparer)
    {
        if (comparer == null) throw new NullReferenceException();
        
        Comparison<T> comparison = comparer.Compare;
        
        return Sort(source, orderBy, sortingAlgorithmType, comparison);
    }
    
    public static T[] Sort<T>(
        this T[] source,
        OrderBy orderBy,
        SortinhAlgorithmType sortingAlgorithmType,
        Comparison<T> comparison)
    {
        if (comparison == null)
        {
            throw new NullReferenceException();
        }
        
        T[] sortedArray = { };

        switch (sortingAlgorithmType)
        {
            case SortinhAlgorithmType.Bubble:
                sortedArray = BubbleSort.Sort(source, comparison);
                break;
            case SortinhAlgorithmType.Selection:
                break;
            case SortinhAlgorithmType.Quick:
                break;
            case SortinhAlgorithmType.Heap:
                break;
            case SortinhAlgorithmType.Merge:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(sortingAlgorithmType), sortingAlgorithmType, null);
        }
        if (orderBy == OrderBy.Descending)
        {
            sortedArray = sortedArray.Reverse().ToArray();
        } 
        
        return sortedArray;
    }
}