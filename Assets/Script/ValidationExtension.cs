using System;
using UnityEngine;


public static class ValidationExtension
{
    private static bool IsCorrect(in char a, in char b)
    {
        return a == b;
    }
    public static bool CheckPart(in string target, in string input) //��������� ��ǲ�� �˼�
    {
        int i = 0;
        foreach (var c in input)
        {
            if (!IsCorrect(c, target[i]))
            {
                return false;
            }
            i++;
        }
        return true;
    }

    public static bool IsCorrect(in string target, in string input) //��������� ��ǲ�� �˼�
    {
        return String.Equals(target, input, StringComparison.Ordinal);
    }
}

