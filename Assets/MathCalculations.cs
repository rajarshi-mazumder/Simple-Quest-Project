using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathCalculations 
{
    public static bool isPrimeNumber(int n)
    {
        int i, m = 0, flag = 0;

        m = n / 2;
        for (i = 2; i <= m; i++)
        {
            if (n % i == 0)
            {   

                flag = 1;
                break;
            }
        }
        if (flag == 0)
        {
            return true;
        }
        return false;
    }
    

}
