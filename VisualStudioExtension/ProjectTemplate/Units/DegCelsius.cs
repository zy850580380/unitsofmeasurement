/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace $safeprojectname$
{
    public partial struct DegCelsius : IQuantity<double>, IEquatable<DegCelsius>, IComparable<DegCelsius>
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties

        // instance properties
        public double Value { get { return m_value; } }

        // unit properties
        public Dimension UnitSense { get { return DegCelsius.Sense; } }
        public int UnitFamily { get { return DegCelsius.Family; } }
        public double UnitFactor { get { return DegCelsius.Factor; } }
        public string UnitFormat { get { return DegCelsius.Format; } }
        public SymbolCollection UnitSymbol { get { return DegCelsius.Symbol; } }

        #endregion

        #region Constructor(s)
        public DegCelsius(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator DegCelsius(double q) { return new DegCelsius(q); }
        public static explicit operator DegCelsius(DegKelvin q) { return new DegCelsius((DegCelsius.Factor / DegKelvin.Factor) * q.Value); }
        public static explicit operator DegCelsius(DegFahrenheit q) { return new DegCelsius((DegCelsius.Factor / DegFahrenheit.Factor) * q.Value); }
        public static explicit operator DegCelsius(DegRankine q) { return new DegCelsius((DegCelsius.Factor / DegRankine.Factor) * q.Value); }
        public static DegCelsius From(IQuantity<double> q)
        {
            if (q.UnitSense != DegCelsius.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"DegCelsius\"", q.GetType().Name));
            return new DegCelsius((DegCelsius.Factor / q.UnitFactor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable / IComparable
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is DegCelsius) && Equals((DegCelsius)obj); }
        public bool /* IEquatable<DegCelsius> */ Equals(DegCelsius other) { return this.Value == other.Value; }
        public int /* IComparable<DegCelsius> */ CompareTo(DegCelsius other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Comparison
        public static bool operator ==(DegCelsius lhs, DegCelsius rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(DegCelsius lhs, DegCelsius rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(DegCelsius lhs, DegCelsius rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(DegCelsius lhs, DegCelsius rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(DegCelsius lhs, DegCelsius rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(DegCelsius lhs, DegCelsius rhs) { return lhs.Value >= rhs.Value; }
        #endregion

        #region Arithmetic
        // Inner:
        public static DegCelsius operator +(DegCelsius lhs, DegCelsius rhs) { return new DegCelsius(lhs.Value + rhs.Value); }
        public static DegCelsius operator -(DegCelsius lhs, DegCelsius rhs) { return new DegCelsius(lhs.Value - rhs.Value); }
        public static DegCelsius operator ++(DegCelsius q) { return new DegCelsius(q.Value + 1d); }
        public static DegCelsius operator --(DegCelsius q) { return new DegCelsius(q.Value - 1d); }
        public static DegCelsius operator -(DegCelsius q) { return new DegCelsius(-q.Value); }
        public static DegCelsius operator *(double lhs, DegCelsius rhs) { return new DegCelsius(lhs * rhs.Value); }
        public static DegCelsius operator *(DegCelsius lhs, double rhs) { return new DegCelsius(lhs.Value * rhs); }
        public static DegCelsius operator /(DegCelsius lhs, double rhs) { return new DegCelsius(lhs.Value / rhs); }
        // Outer:
        public static double operator /(DegCelsius lhs, DegCelsius rhs) { return lhs.Value / rhs.Value; }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(null, DegCelsius.Format); }
        public string ToString(string format) { return ToString(null, format); }
        public string ToString(IFormatProvider fp) { return ToString(fp, DegCelsius.Format); }
        public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, DegCelsius.Symbol[0]); }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = DegKelvin.Sense;
        private static readonly int s_family = 3;
        private static double s_factor = DegKelvin.Factor;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("\u00B0C", "deg.C");

        private static readonly DegCelsius s_one = new DegCelsius(1d);
        private static readonly DegCelsius s_zero = new DegCelsius(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static DegCelsius One { get { return s_one; } }
        public static DegCelsius Zero { get { return s_zero; } }
        #endregion
    }
}