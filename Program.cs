using System;

namespace Fraction_GK
{
    class Fraction
    {
        private int Numerator;
        public int Denominator;
        public int denominator
        {
            get { return Denominator == 0 ? 1 : Denominator; }
            set
            {
                if (value == 0)
                {
                    throw new Exception("Denominator must be nonzero");
                }
                Denominator = value;
            }
        }

        public Fraction()
        {
            Numerator = 0;
            Denominator = 1;
        }
        public Fraction(int numerator, int denominator)
        { 
            this.Numerator = numerator;
            this.Denominator = denominator;
        }
        public Fraction(int num)
        {
            Numerator = num;
            Denominator = 1;
            Simplification();
        }
        public override string ToString()
        {
            return this.Numerator + "/" + this.Denominator;
        }
        public Fraction Add(Fraction fraction2)
        {
            int nummerator = Numerator * fraction2.Denominator + Denominator * fraction2.Numerator;
            int denominator = Denominator * fraction2.Denominator;
            Fraction sum = new Fraction(nummerator, denominator);
            sum.Simplification();
            return sum;
        }
        private int GreatestComonDivisor(int a, int b)
        {
            int r = a % b;
            while (r != 0)
            {
                a = b;
                b = r;
                r = a % b;
            }
            return b;
        }
        private void Simplification()
        {
            try
            {
                if (Numerator == 0)
                {
                    Denominator = 1;
                    return;
                }

                int GCD = GreatestComonDivisor(Numerator, Denominator);
                Numerator /= GCD;
                Denominator /= GCD;

                if (Denominator < 0)
                {
                    Numerator *= -1;
                    Denominator *= -1;
                }
            }
            catch (Exception exp)
            {
                throw new Exception("Cannot reduce fraction because Denominator equals zero: " + exp.Message);
            }
        }
        public static Fraction operator -(Fraction fraction1, Fraction fraction2)
        {
            int nummerator = fraction1.Numerator * fraction2.Denominator - fraction1.Denominator * fraction2.Numerator;
            int denominator = fraction1.Denominator * fraction2.Denominator;
            Fraction sub = new Fraction(nummerator, denominator);
            sub.Simplification();
            return sub;
        }
        public Fraction Multiply(Fraction fraction2)
        {
            int nummerator = Numerator * fraction2.Numerator;
            int denominator = Denominator * fraction2.Denominator;
            Fraction mul = new Fraction(nummerator, denominator);
            mul.Simplification();
            return mul;
        }
        public Fraction Divide(Fraction fraction2)
        {
            int nummerator = Numerator * fraction2.Denominator;
            int denominator = Denominator * fraction2.Numerator;
            Fraction div = new Fraction(nummerator, denominator);
            div.Simplification();
            return div;
        }
        public static bool operator > (Fraction fraction1, Fraction fraction2)
        {
            bool status = false;
            int a1 = fraction1.Numerator * fraction2.Denominator;
            int b1 = fraction2.Numerator * fraction1.Denominator;

            if (a1 > b1)
            {
                status = true;
            }
            return status;
        }
        public static bool operator <(Fraction fraction1, Fraction fraction2)
        {
            bool status = false;
            int a1 = fraction1.Numerator * fraction2.Denominator;
            int b1 = fraction2.Numerator * fraction1.Denominator;

            if (a1 < b1)
            {
                status = true;
            }
            return status;
        }
        //public void PrintFraction(Fraction fraction)
        //{
        //    fraction.Simplification();
        //    Console.WriteLine(fraction.Numerator + "/" + fraction.Denominator);
        //}
    }
    class Program
    {
        static void Main(string[] args)
        {
            Fraction fraction1 = new Fraction(2,7);
            Fraction fraction2 = new Fraction(3, 4);
            Fraction Tong = fraction1.Add(fraction2);
            Fraction Hieu = fraction1 - fraction2;
            Fraction Tich = fraction1.Multiply(fraction2);
            Fraction Thuong = fraction1.Divide(fraction2);
            Console.WriteLine(fraction1 + " plus " + fraction2 + " equals " + Tong);
            Console.WriteLine(fraction1 + " minus " + fraction2 + " equals " + Hieu); 
            Console.WriteLine(fraction1 + " multiplied by " + fraction2 + " equals " + Tich);
            Console.WriteLine(fraction1 + " divided by " + fraction2 + " equals " + Thuong);
            Fraction[] fracs = {new Fraction(10,3),new Fraction(8,19),
                                new Fraction(7,17),new Fraction(5,6),
                                new Fraction(8,4),new Fraction(3,5),
                                new Fraction(10,29),new Fraction(17,9)};
            
            for (int i = 0; i < fracs.Length - 1; i++)
            {
                for (int j = i; j < fracs.Length; j++)
                {
                    if (fracs[i] > fracs[j])
                    {
                        Fraction temp = fracs[i];
                        fracs[i] = fracs[j];
                        fracs[j] = temp;
                    }
                }
            }
            Console.WriteLine("Sorted fractional arrays in ascending order: ");
            Fraction sum_of_fracs = new Fraction(0, 1);
            for (int i = 0; i < fracs.Length; i++)
            {
                Console.WriteLine(fracs[i]);
                sum_of_fracs = sum_of_fracs.Add(fracs[i]);
            }

            Console.WriteLine("Max: " + fracs[fracs.Length - 1]);
            Console.WriteLine("Min: " + fracs[0]);
            Console.WriteLine("Sum: " + sum_of_fracs);

            Console.ReadKey();
        }
    }
    
}
