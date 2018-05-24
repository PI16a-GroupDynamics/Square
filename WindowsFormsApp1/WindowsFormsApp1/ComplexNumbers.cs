using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Complex : IComparable<Complex>
{
    public double Real { get; set; }
    public double Imaginary { get; set; }

    public Complex()
    {

    }

    public Complex(double real)
    {
        Real = real;
        Imaginary = 0;
    }

    public Complex(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public static Complex operator +(Complex a, Complex b)
    {
        return new Complex()
        {
            Imaginary = a.Imaginary + b.Imaginary,
            Real = a.Real + b.Real
        };
    }

    public static Complex operator -(Complex a, Complex b)
    {
        return new Complex()
        {
            Imaginary = a.Imaginary - b.Imaginary,
            Real = a.Real - b.Real
        };
    }

    public static Complex operator +(Complex a, double k)
    {
        return new Complex()
        {
            Imaginary = a.Imaginary,
            Real = a.Real + k
        };
    }

    public static Complex operator -(Complex a, double k)
    {
        return new Complex()
        {
            Imaginary = a.Imaginary,
            Real = a.Real - k
        };
    }

    // Перегрузка оператора равенства. ВАЖНО, т.к. сравниваются числа с плавающей запятой, то сравнивать нужно их разницу по модулю
    //
    public static bool operator ==(Complex a, Complex b)
    {
        if ((Math.Abs(a.Imaginary - b.Imaginary) < 0.0000001 && Math.Abs(a.Real - b.Real) < 0.0000001))
        {
            return true;
        }
        return false;
    }

    public static bool operator !=(Complex a, Complex b)
    {
        if (Math.Abs(a.Imaginary - b.Imaginary) > 0.0000001 && Math.Abs(a.Real - b.Real) > 0.0000001)
        {
            return true;
        }
        return false;
    }


    public override bool Equals(System.Object obj)
    {
        if (obj == null)
        {
            return false;
        }

        Complex n = obj as Complex;
        if ((System.Object)n == null)
        {
            return false;
        }

        return (Math.Abs(Imaginary - n.Imaginary) < 0.0000001) && (Math.Abs(Real - n.Real) < 0.0000001);
    }

    public bool Equals(Complex n)
    {
        if ((object)n == null)
        {
            return false;
        }

        return (Math.Abs(Imaginary - n.Imaginary) < 0.0000001) && (Math.Abs(Real - n.Real) < 0.0000001);
    }

    // Указаний по реализации нет. Реализован таким образом
    public override int GetHashCode()
    {
        return (int)Imaginary ^ (int)Real;
    }

    public override string ToString()
    {
        if (Imaginary == 0) return string.Format("{0}", Math.Round(Real, 6));

        ///////////РЕДАКТИРОВАЛ
        if(Math.Round(Imaginary, 6)>=0)
        return string.Format("{0} + {1}i", Math.Round(Real, 2), Math.Round(Imaginary, 2));
        else
            return string.Format("{0} - {1}i", Math.Round(Real, 2), Math.Abs(Math.Round(Imaginary, 2)));
    }


    // Возможно лучшее решение. Т.к. указаний не дано по сравнению комплексных чисел (только равенства и неравенство),
    // то реализовано таким образом
    public int CompareTo(Complex other)
    {
        if (this == other) return 0;

        if (Math.Abs(this.Real - other.Real) < 0.0000001)
        {
            if (this.Imaginary - other.Imaginary > 0) return 1;
            else return -1;
        }

        if (this.Real > other.Real) return 1;
        return -1;
    }

    // Задания по перегрузки операторов умножения и деления также нет, но вот они на всякий пожарный.

    public static Complex operator *(Complex a, Complex b)
    {
        return new Complex()
        {
            Real = a.Real * b.Real - a.Imaginary * b.Imaginary,
            Imaginary = a.Real * b.Imaginary + a.Imaginary * b.Real
        };
    }

    public static Complex operator *(Complex a, double d)
    {
        return new Complex()
        {
            Real = a.Real * d,
            Imaginary = a.Imaginary * d
        };
    }

    public static Complex operator /(Complex a, Complex b)
    {
        return new Complex()
        {
            Real = (a.Real * b.Real + a.Imaginary * b.Imaginary) / (b.Real * b.Real + b.Imaginary * b.Imaginary),
            Imaginary = (a.Imaginary * b.Real - a.Real * b.Imaginary) / (b.Real * b.Real + b.Imaginary * b.Imaginary)
        };
    }

    public static Complex operator /(Complex a, double d)
    {
        return new Complex()
        {
            Real = a.Real / d,
            Imaginary = a.Imaginary / d
        };
    }
}