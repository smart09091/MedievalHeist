using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConverterHelper : MonoBehaviour
{
    // Start is called before the first frame update



    public static string compressFloatToString(float amount)
    {

        float totalAmount = amount;
        float divider = 1000;
        float maxLimit = 1000;
        string c = "";


        if (amount > maxLimit)
        {
            if (amount >= 1000)
            {
                c = "K";
            }


            if (amount >= 1000000)
            {
                c = "M";
                divider = 1000000;
            }

            if (amount >= 1000000000)
            {
                c = "B";
                divider = 1000000000;
            }

            totalAmount = amount / divider;

            //Debug.Log("totalAmount % 1: " + totalAmount % 1);
            //  Debug.Log("totalAmount % 0.1: " + totalAmount % 0.1);
            //Debug.Log("totalAmount % 0.01: " + totalAmount % 0.01);


            if (totalAmount % 1 != 0)
            {
                //if (totalAmount % 0.1 > 0.01)
                //{
                //    return "" + totalAmount.ToString("F2") + c;
                //}

                return "" + totalAmount.ToString("F1") + c;

            }
            else
            {
                return "" + totalAmount + c;
            }



        }




        return "" + totalAmount + c;

    }
    public static string compressFloatToStringNoD(float amount)
    {

        float totalAmount = amount;
        float divider = 1000;
        float maxLimit = 1000;
        string c = "";


        if (amount > maxLimit)
        {
            if (amount >= 1000)
            {
                c = "K";
            }


            if (amount >= 1000000)
            {
                c = "M";
                divider = 1000000;
            }

            if (amount >= 1000000000)
            {
                c = "B";
                divider = 1000000000;
            }

            totalAmount = amount / divider;

            //Debug.Log("totalAmount % 1: " + totalAmount % 1);
            //  Debug.Log("totalAmount % 0.1: " + totalAmount % 0.1);
            //Debug.Log("totalAmount % 0.01: " + totalAmount % 0.01);


            if (totalAmount % 1 != 0)
            {
                //if (totalAmount % 0.1 > 0.01)
                //{
                //    return "" + totalAmount.ToString("F2") + c;
                //}

                return "" + totalAmount.ToString("N0") + c;

            }
            else
            {
                return "" + totalAmount + c;
            }



        }




        return "" + totalAmount + c;

    }
    public static string compressDoubleToString(double amount)
    {

        double totalAmount = amount;
        double divider = 1000;
        double maxLimit = 1000;
        string c = "";


        if (amount > maxLimit)
        {
            if (amount >= 1000)
            {
                c = "K";
            }


            if (amount >= 1000000)
            {
                c = "M";
                divider = 1000000;
            }

            if (amount >= 1000000000)
            {
                c = "B";
                divider = 1000000000;
            }

            totalAmount = amount / divider;

            //Debug.Log("totalAmount % 1: " + totalAmount % 1);
            //  Debug.Log("totalAmount % 0.1: " + totalAmount % 0.1);
            //Debug.Log("totalAmount % 0.01: " + totalAmount % 0.01);


            if (totalAmount % 1 != 0)
            {
                //if (totalAmount % 0.1 > 0.01)
                //{
                //    return "" + totalAmount.ToString("F2") + c;
                //}

                return "" + totalAmount.ToString("F1") + c;

            }
            else
            {
                return "" + totalAmount + c;
            }



        }




        return "" + totalAmount + c;


    }

    public static string compressIntToString(int amount)
    {

        int totalAmount = amount;
        int divider = 1000;
        int maxLimit = 100000;
        string c = "";


        if (amount > maxLimit)
        {
            if (amount >= 1000)
            {
                c = "K";
            }


            if (amount >= 1000000)
            {
                c = "M";
                divider = 1000000;
            }

            if (amount >= 1000000000)
            {
                c = "B";
                divider = 1000000000;
            }

            totalAmount = amount / divider;



            if (totalAmount % 1 != 0)
            {
               
                return "" + totalAmount.ToString("F1") + c;

            }
            else
            {
                return "" + totalAmount + c;
            }

        }




        return "" + totalAmount + c;

    }




    public static string comma(float amount )
    {
        return String.Format("{0:n0}", amount);
    }

}
