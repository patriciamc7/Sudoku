using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public delegate void UpdateSquareNumber(int number);
    public static event UpdateSquareNumber OnUpdateSquareNumber;
    public static void UpdateSquareNumberMethod(int nubmer)
    {
        if (OnUpdateSquareNumber != null)
            OnUpdateSquareNumber(nubmer);
    }

    public delegate void SquareSelected(int asquare_index);
    public static event SquareSelected OnSquareSelected;

    public static void SquareSelectedMethod(int aSquareIndex)
    {
        if (OnSquareSelected != null)
            OnSquareSelected(aSquareIndex);
    }

    public delegate void WrongNumber();
    public static event WrongNumber OnWrongNumber;

    public static void OnWrongNumberMethod()
    {
        if(OnWrongNumber != null)
            OnWrongNumber();
    }
}
