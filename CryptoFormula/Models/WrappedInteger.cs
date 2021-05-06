using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace CryptoFormulaLibrary.Models
{
    public struct WrappedInteger
    {
        public BigInteger Value { get; set; }

        public WrappedInteger(BigInteger value)
        {
            Value = value;
        }

        public WrappedInteger(WrappedInteger wrappedInteger)
        {
            Value = wrappedInteger.Value;
        }

        public static implicit operator WrappedInteger(BigInteger value) => new WrappedInteger(value);
        public static implicit operator WrappedInteger(int value) => new WrappedInteger(new BigInteger(value));
        public static implicit operator WrappedInteger(long value) => new WrappedInteger(new BigInteger(value));

        public static BigInteger operator  -(WrappedInteger left, WrappedInteger right) => left.Value - right.Value;
        public static BigInteger operator  +(WrappedInteger left, WrappedInteger right) => left.Value + right.Value;
        public static BigInteger operator  *(WrappedInteger left, WrappedInteger right) => left.Value * right.Value;
        public static BigInteger operator  /(WrappedInteger left, WrappedInteger right) => left.Value / right.Value;
        public static BigInteger operator  %(WrappedInteger left, WrappedInteger right) => left.Value % right.Value;
        public static bool       operator ==(WrappedInteger left, WrappedInteger right) => left.Value == right.Value;
        public static bool       operator !=(WrappedInteger left, WrappedInteger right) => left.Value != right.Value;
        public static bool       operator <=(WrappedInteger left, WrappedInteger right) => left.Value <= right.Value;
        public static bool       operator >=(WrappedInteger left, WrappedInteger right) => left.Value >= right.Value;

        public override string ToString() => Value.ToString();
        public override bool Equals(object obj) => base.Equals(obj);
        public override int GetHashCode() => base.GetHashCode();
    }
}
