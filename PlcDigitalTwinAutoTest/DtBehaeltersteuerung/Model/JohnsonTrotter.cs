using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DtBehaeltersteuerung.Model;

public class JohnsonTrotter
{
    // https://www.geeksforgeeks.org/johnson-trotter-algorithm/

    public ObservableCollection<Permutation> GetPermutations() => _permutationen;

    private readonly ObservableCollection<Permutation> _permutationen;

    private const bool LeftToRight = true;
    private const bool RightToLeft = false;

    public JohnsonTrotter(short anzahlStellen)
    {
        _permutationen = new ObservableCollection<Permutation>();
        GeneratePermutation(anzahlStellen);
    }
    private static int SearchArray(IReadOnlyList<int> a, int n, int mobile)
    {
        for (var i = 0; i < n; i++) if (a[i] == mobile) return i + 1;
        return 0;
    }
    private static int GetMobile(IReadOnlyList<int> a, IReadOnlyList<bool> dir, int n)
    {
        var mobilePrev = 0;
        var mobile = 0;

        for (var i = 0; i < n; i++)
        {
            // direction 0 represents RIGHT TO LEFT. 
            if (dir[a[i] - 1] == RightToLeft && i != 0 && a[i] > a[i - 1] && a[i] > mobilePrev)
            {
                mobile = a[i];
                mobilePrev = mobile;
            }

            // direction 1 represents LEFT TO RIGHT. 
            if (dir[a[i] - 1] != LeftToRight || i == n - 1) continue;
            if (a[i] <= a[i + 1] || a[i] <= mobilePrev) continue;
            mobile = a[i];
            mobilePrev = mobile;
        }

        if (mobile == 0 && mobilePrev == 0) return 0;

        return mobile;
    }
    public int GetOnePermutation(int[] a, bool[] dir, int n)
    {
        var mobile = GetMobile(a, dir, n);
        var pos = SearchArray(a, n, mobile);

        switch (dir[a[pos - 1] - 1])
        {
            // swapping the elements  according to the direction i.e. dir[]. 
            case RightToLeft: (a[pos - 1], a[pos - 2]) = (a[pos - 2], a[pos - 1]); break;
            case LeftToRight: (a[pos], a[pos - 1]) = (a[pos - 1], a[pos]); break;
        }

        // changing the directions for elements greater  than largest mobile integer. 
        for (var i = 0; i < n; i++)
        {
            if (a[i] <= mobile) continue;

            dir[a[i] - 1] = dir[a[i] - 1] switch
            {
                LeftToRight => RightToLeft,
                RightToLeft => LeftToRight
            };
        }

        switch (n)
        {
            case 4:
                _permutationen.Add(new Permutation(a[0], a[1], a[2], a[3]));
                break;
            default:
                for (var i = 0; i < n; i++) Console.Write(a[i]);
                Console.Write(' ');
                break;
        }

        return 0;
    }
    public int CalculateFactorial(int n)
    {
        var res = 1;
        for (var i = 1; i <= n; i++) res *= i;

        return res;
    }
    public void GeneratePermutation(int n)
    {
        // To store current  permutation 
        var a = new int[n];

        // To store current  directions 
        var dir = new bool[n];

        // storing the elements  from 1 to n and  printing first permutation. 
        for (var i = 0; i < n; i++)
        {
            a[i] = i + 1;
            Console.Write(a[i]);
        }

        if (n == 4) _permutationen.Add(new Permutation(a[0], a[1], a[2], a[3]));
        else Console.Write('\n');

        // initially all directions  are set to RIGHT TO   LEFT i.e. 0. 
        for (var i = 0; i < n; i++) dir[i] = RightToLeft;

        // for generating permutations  in the order. 
        for (var i = 1; i < CalculateFactorial(n); i++) GetOnePermutation(a, dir, n);
    }
}