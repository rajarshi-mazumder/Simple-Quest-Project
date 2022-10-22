using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathCalculations: MonoBehaviour
{

    public void Start()
    {
        GameManager.CheckForPrime += isPrimeNumber;
        GameManager.CheckForComposite += isCompositeNumber;
    }
    public static void isPrimeNumber(int n, Quest q)
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
            q.enteredNumberSequence.Add(n);
            return;
        }
        Debug.Log(n+" is not a prime no");
    }
    public static void isCompositeNumber(int n, Quest q)
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
            Debug.Log(n + " is not a composite no");
            return;
        }
        q.enteredNumberSequence.Add(n);
    }

}
