# Fraction-class
Fraction class construction with basic math


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
        
        
I build mathematical operations by overriding operators or creating properties (the purpose here is to demonstrate different handling in OOP)
