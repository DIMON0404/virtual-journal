using System;

namespace Utility
{
    [Serializable]
    public class DateTimeHolder
    {
        public DateTime DateTime;

        public static implicit operator string(DateTimeHolder dateTimeHolder)
        {
            return dateTimeHolder.DateTime.ToShortDateString();
        }

        public static implicit operator DateTimeHolder(DateTime dateTime)
        {
            return new DateTimeHolder {DateTime = dateTime};
        }

        public static implicit operator DateTime(DateTimeHolder dateTimeHolder)
        {
            return dateTimeHolder.DateTime;
        }
    }
}