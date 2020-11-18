using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Refactorings.TemperatureConversions;

namespace Refactorings
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> fTemps = new List<double>();
            List<double> cTemps = new List<double>();

            //TASK 0: Using quick find/replace (Ctrl-H), get ready to replace all the instances of s.below with str.
            //don't make the actual changes, but pause when you're ready to do so.

            foreach (string s in args)
            {
                if (s != null)
                {
                    if (s.Length > 0 && s.Substring(s.Length - 1).Equals("F"))
                    {
                        string tempFString = s.Substring(0, s.Length - 1);
                        double tempF = System.Convert.ToDouble(tempFString);
                        fTemps.Add(tempF);

                        Console.WriteLine((tempF - 32) * (5.0 / 9.0));

                    }
                    if (s.Length > 0 && s.Substring(s.Length - 1).Equals("C"))
                    {
                        string tempCString = s.Substring(0, s.Length - 1);
                        double tempC = System.Convert.ToDouble(tempCString);
                        cTemps.Add(tempC);

                        Console.WriteLine(tempC * (9.0 / 5.0) + 32);
                    }
                }
                if (fTemps.Count != 0)
                {
                    Console.WriteLine(MinTempInC(fTemps));
                    Console.WriteLine(MaxTempInC(fTemps));
                }
                if (cTemps.Count != 0)
                {
                    Console.WriteLine(MinTempInF(cTemps));
                    Console.WriteLine(MaxTempInF(cTemps));
                    Console.WriteLine(AveCTempInF(cTemps));
                }

                Console.WriteLine(AllTheCelsiusFormulae(20, 30, 40, 50, 60, 70));
            }
            Console.ReadKey();
        }

        //TASK 1 start:
        // change all the functions in this file that are written in terms of doubles to use decimals instead
        // e.g. static double MinTempInC(List<double> fTemps) => static decimal MinTempInC(List<decimal> fTemps)
        // there are multiple functions that take this form in the file - is there a quick way to change the method signatures?

        static double MinTempInC(List<double> fTemps)
        {
            double fMin = fTemps.ElementAt<double>(0);

            foreach (double f in fTemps)
            {
                if (f < fMin)
                {
                    fMin = f;
                }
            }
            // TASK 2 Start:
            // Change the hardcoded Fahrenheit to Celsius conversion below  
            // to use FtoC(double fahrenheitTemp) function instead, throughout this file.
            // 
            // For instance, the line below 
            // 
            //   return (fMin - 32) * (5.0/9.0);
            // 
            // will become
            //  return FtoC(fMin);
            //
            // NOTE: 1) The variable name differs in the severl other locations - it will not be fMin
            // NOTE: 2) The FtoC function is already available directly in this class,
            // so there is no need to worry about adding a using or reference, you can just call it 
            // directly
            //

            return (fMin - 32) * (5.0 / 9.0);
        }
        private static double MinTempInF(List<double> cTemps)
        {
            double cMin = cTemps.ElementAt<double>(0);

            foreach (double c in cTemps)
            {
                if (c < cMin)
                {
                    cMin = c;
                }
            }

            return (cMin * 9.0 / 5.0) + 32;
        }

        static double MaxTempInC(List<double> fTemps)
        {
            double fMax = fTemps.ElementAt<double>(0);

            foreach (double f in fTemps)
            {
                if (f < fMax)
                {
                    fMax = f;
                }
            }

            return (fMax - 32) * (5.0 / 9.0);
        }
        private static double MaxTempInF(List<double> cTemps)
        {
            double cMax = cTemps.ElementAt<double>(0);

            foreach (double c in cTemps)
            {
                if (c < cMax)
                {
                    cMax = c;
                }
            }

            return (cMax * 9.0 / 5.0) + 32;
        }

        static double AveFTempInC(List<double> fTemps)
        {
            double fTot = 0;
            double fAve;

            foreach (double f in fTemps)
            {
                fTot += f;
            }
            fAve = fTot / fTemps.Count;

            return (fAve - 32) * (5.0 / 9.0);
        }

        static double AveCTempInF(List<double> cTemps)
        {
            double cTot = 0;
            double cAve;

            foreach (double c in cTemps)
            {
                cTot += c;
            }
            cAve = cTot / cTemps.Count;

            return cAve * (9.0 / 5.0) + 32;
        }

        static double SumTempsInC(List<double> fTemps)
        {
            double fTotal = 0;
            foreach (double f in fTemps)
            {
                fTotal += f;
            }
            return (fTotal - 32) * (5.0 / 9.0);
        }

        static string ListTempsInC(List<double> fTemps)
        {
            StringBuilder cList = new StringBuilder();
            double fItem;

            foreach (double f in fTemps)
            {
                fItem = (f - 32) * (5.0 / 9.0);
                cList.Append(fItem.ToString());
                cList.Append(',');
            }

            return cList.ToString();
        }

        static double AllTheCelsiusFormulae(double CName1, double Celsius, double Centigrade, double DegC, double DegreesC, double DC)
        {
            //test method
            Console.WriteLine(CName1 * (9.0 / 5.0) + 32);
            Console.WriteLine(DegreesC * (9.0 / 5.0) + 32);
            Console.WriteLine(DC * (9.0 / 5.0) + 32);

            Console.WriteLine((Celsius * 9.0 / 5.0) + 32);
            Console.WriteLine((Centigrade * 9.0 / 5.0) + 32);
            Console.WriteLine((DegC * 9.0 / 5.0) + 32);

            return CName1;
        }
    }
}
