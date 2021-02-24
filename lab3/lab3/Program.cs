using System;
enum MonthName
{
    January,
    February,
    March,
    April,
    May,
    June,
    July,
    August,
    September,
    October,
    November,
    December
}

class WhatDay
{
    static void Main()
    {
        Console.WriteLine("Please, enter a year");
        bool leap = int.Parse(Console.ReadLine()) % 4 == 0; // true if year is with 366 days
        int monthNum = 0;
        int dayNum;
        
        if (leap)
        {
            Console.WriteLine("Please enter a day number between 1 and 366: ");
            dayNum = int.Parse(Console.ReadLine());
            foreach (int daysInMonth in DaysInMonths366)
            {
                if (dayNum <= daysInMonth)
                {
                    break;
                }
                else
                {
                    dayNum -= daysInMonth;
                    monthNum++;
                }
            }
        }
        else
        {
            Console.WriteLine("Please enter a day number between 1 and 365: ");
            dayNum = int.Parse(Console.ReadLine());
            foreach (int daysInMonth in DaysInMonths365)
            {
                if (dayNum <= daysInMonth)
                {
                    break;
                }
                else
                {
                    dayNum -= daysInMonth;
                    monthNum++;
                }
            }
        }
        if(monthNum>=12)
        {
            Console.WriteLine("Wrong day");
        }
        else
        {
            MonthName temp = (MonthName)monthNum;
            string monthName = temp.ToString();
            Console.WriteLine("{0},{1}", dayNum, monthName);
        }

        /*if (dayNum <= 31)
        { // January
            goto End;
        }
        else
        {
            dayNum -= 31;
            monthNum++;
        }

        if (dayNum <= 28)
        { // February
            goto End;
        }
        else
        {
            dayNum -= 28;
            monthNum++;
        }

        if (dayNum <= 31)
        { // March
            goto End;
        }
        else
        {
            dayNum -= 31;
            monthNum++;
        }

        if (dayNum <= 30)
        { // April
            goto End;
        }
        else
        {
            dayNum -= 30;
            monthNum++;
        }

        if (dayNum <= 31)
        { // May
            goto End;
        }
        else
        {
            dayNum -= 31;
            monthNum++;
        }


        if (dayNum <= 30)
        { // June
            goto End;
        }
        else
        {
            dayNum -= 30;
            monthNum++;
        }

        if (dayNum <= 31)
        { // July
            goto End;
        }
        else
        {
            dayNum -= 31;
            monthNum++;
        }

        if (dayNum <= 31)
        { // August
            goto End;
        }
        else
        {
            dayNum -= 31;
            monthNum++;
        }

        if (dayNum <= 30)
        { // September
            goto End;
        }
        else
        {
            dayNum -= 30;
            monthNum++;
        }

        if (dayNum <= 31)
        { // October
            goto End;
        }
        else
        {
            dayNum -= 31;
            monthNum++;
        }
        if (dayNum <= 31)
        { // ноябрь
            goto End;
        }
        else
        {
            dayNum -= 30;
            monthNum++;
        }
        if (dayNum <= 31)
        { // декабрь
            goto End;
        }
        else
        {
            dayNum -= 31;
            monthNum++;
        }*/


        //////////////////////////////////////////////////////////////
        // TODO: Implement if statements for November and December ///
        //////////////////////////////////////////////////////////////


        //End:
        //string MonthName;
        // MonthName temp = (MonthName)monthNum;
        //string monthName = temp.ToString();
        /*MonthName temp = (MonthName)monthNum;
        string monthName = temp.ToString();*/
        /*switch (monthNum)
        {
            case 0:
                monthName = "January"; break;
            case 1:
                monthName = "February"; break;
            case 2:
                monthName = "March"; break;
            case 3:
                monthName = "April"; break;
            case 4:
                monthName = "May"; break;
            case 5:
                monthName = "June"; break;
            case 6:
                monthName = "July"; break;
            case 7:
                monthName = "August"; break;
            case 8:
                monthName = "September"; break;
            case 9:
                monthName = "October"; break;
            case 10:
                monthName = "nOVEMBER"; break;
            case 11:
                monthName = "December"; break;
            default:
                    monthName = "not done yet"; break;
        }*/
    }

    static System.Collections.ICollection DaysInMonths365
        = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    static System.Collections.ICollection DaysInMonths366
        = new int[12] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
}
