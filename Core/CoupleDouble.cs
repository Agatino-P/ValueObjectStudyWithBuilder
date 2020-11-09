using Shared;
using System.Collections.Generic;

namespace Core
{
    public class CoupleDouble : ValueObject
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public static bool operator ==(CoupleDouble coupleDoubleOne, CoupleDouble coupleDoubleTwo)
        {
            return CoupleDouble.EqualOperator(coupleDoubleOne, coupleDoubleTwo);
        }

        public static bool operator !=(CoupleDouble coupleDoubleOne, CoupleDouble coupleDoubleTwo)
        {
            return CoupleDouble.NotEqualOperator(coupleDoubleOne, coupleDoubleTwo);
        }

        private CoupleDouble(double x, double y)
        {
            X = x;
            Y = y;
        }

        public class Builder
        {
            private CoupleDouble _coupleDouble;
            private double? _x;
            private double? _y;
            private bool _atLeastOneWrongproperty;

            public Builder()
            {
                reset();
            }
            public Builder WithX(double X)
            {
                _x = X;
                return this;
            }
            public Builder WithY(double Y)
            {
                _y = Y;
                //some fake logic, for test
                _atLeastOneWrongproperty = _y % 4 == 0;
                return this;
            }
            
            public Builder WithCopy(CoupleDouble coupleDouble)
            {
                _x = coupleDouble.X;
                _y= coupleDouble.Y;
                return this;
            }
            public CoupleDouble Build()
            {
                if (!validData())
                {
                    return null;
                }

                return new CoupleDouble((double)_x, (double)_y);
            }
            private bool validData()
            {
                if (_atLeastOneWrongproperty)
                {
                    return false;
                }

                if (ReferenceEquals(_x, null) || ReferenceEquals(_y, null)) //Real Logic can go here, if any
                {
                    return false;
                }

                return true;
            }
            private void reset()
            {
                _coupleDouble = null;
            }

        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return X;
            yield return Y;
        }
    }
}
