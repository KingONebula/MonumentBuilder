using System;

public class NumberConverter
{
    public static string ConvertFloat(float number, out int fontSize)
    {
        number = (float)Math.Round(number, 2);
        fontSize = 28;
        if (number < 1000) return number.ToString();
        else if (number < 1000000)
        {
            int thousands = (int)(number / 1000);
            int newNumber = (int)((number - thousands) / 10);
            if (number > 10000 && number < 100000)
            {
                newNumber /= 10;

                fontSize = 26;
            }
            else if (number > 100000)
            {
                newNumber /= 1000;
                fontSize = 24;
            }
            return thousands + "." + newNumber + "K";
        }
        else if(number < 1000000000)
        {
            int millions = (int)(number / 1000000);
            int newNumber = (int)((number - millions) / 10000);
            if (number > 10000000 && number < 100000000)
            {
                newNumber /= 100;
                fontSize = 26;
            }
            else if (number > 100000000)
            {
                newNumber /= 1000;
                fontSize = 24;
            }
            return millions + "." + newNumber + "M";
        }
        else if(number < 1000000000000)
        {
            int billions = (int)(number / 1000000000);
            int newNumber = (int)((number - billions) / 10000000);
            if (number > 10000000000 && number < 100000000000)
            {
                newNumber /= 100;
                fontSize = 26;
            }
            else if (number > 100000000000)
            {
                newNumber /= 1000;
                fontSize = 24;
            }
            return billions + "." + newNumber + "B";
        }
        else if(number < 1000000000000000)
        {
            int trillions = (int)(number / 1000000000000);
            int newNumber = (int)((number - trillions) / 100);
            if (number > 10000000000000 && number < 100000000000000)
            {
                newNumber /= 100;
                fontSize = 26;
            }
            else if (number > 100000000000000)
            {
                newNumber /= 1000;
                fontSize = 24;
            }
            return trillions + "." + newNumber + "T";
        }

        return "TOOHIGH";
    }
}
