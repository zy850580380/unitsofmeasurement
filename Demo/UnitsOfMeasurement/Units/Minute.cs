/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Minute : IQuantity<double>, IEquatable<Minute>, IComparable<Minute>
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties

        // instance properties
        public double Value { get { return m_value; } }

        // unit properties
        public Dimension UnitSense { get { return Minute.Sense; } }
        public int UnitFamily { get { return Minute.Family; } }
        public double UnitFactor { get { return Minute.Factor; } }
        public string UnitFormat { get { return Minute.Format; } }
        public SymbolCollection UnitSymbol { get { return Minute.Symbol; } }

        #endregion

        #region Constructor(s)
        public Minute(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Minute(double q) { return new Minute(q); }
        public static explicit operator Minute(Hour q) { return new Minute((Minute.Factor / Hour.Factor) * q.Value); }
        public static explicit operator Minute(Second q) { return new Minute((Minute.Factor / Second.Factor) * q.Value); }
        public static Minute From(IQuantity<double> q)
        {
            if (q.UnitSense != Minute.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"Minute\"", q.GetType().Name));
            return new Minute((Minute.Factor / q.UnitFactor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable / IComparable
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Minute) && Equals((Minute)obj); }
        public bool /* IEquatable<Minute> */ Equals(Minute other) { return this.Value == other.Value; }
        public int /* IComparable<Minute> */ CompareTo(Minute other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Comparison
        public static bool operator ==(Minute lhs, Minute rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Minute lhs, Minute rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Minute lhs, Minute rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Minute lhs, Minute rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Minute lhs, Minute rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Minute lhs, Minute rhs) { return lhs.Value >= rhs.Value; }
        #endregion

        #region Arithmetic
        // Inner:
        public static Minute operator +(Minute lhs, Minute rhs) { return new Minute(lhs.Value + rhs.Value); }
        public static Minute operator -(Minute lhs, Minute rhs) { return new Minute(lhs.Value - rhs.Value); }
        public static Minute operator ++(Minute q) { return new Minute(q.Value + 1d); }
        public static Minute operator --(Minute q) { return new Minute(q.Value - 1d); }
        public static Minute operator -(Minute q) { return new Minute(-q.Value); }
        public static Minute operator *(double lhs, Minute rhs) { return new Minute(lhs * rhs.Value); }
        public static Minute operator *(Minute lhs, double rhs) { return new Minute(lhs.Value * rhs); }
        public static Minute operator /(Minute lhs, double rhs) { return new Minute(lhs.Value / rhs); }
        // Outer:
        public static double operator /(Minute lhs, Minute rhs) { return lhs.Value / rhs.Value; }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(null, Minute.Format); }
        public string ToString(string format) { return ToString(null, format); }
        public string ToString(IFormatProvider fp) { return ToString(fp, Minute.Format); }
        public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, Minute.Symbol[0]); }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Second.Sense;
        private static readonly int s_family = 8;
        private static double s_factor = Second.Factor / 60d;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("min");

        private static readonly Minute s_one = new Minute(1d);
        private static readonly Minute s_zero = new Minute(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Minute One { get { return s_one; } }
        public static Minute Zero { get { return s_zero; } }
        #endregion
    }
}