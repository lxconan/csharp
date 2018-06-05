using System;

namespace DateTimeConversionContinued
{
    class DateTimeConverter
    {
        public static DateTime ToUniversalDateTime(string dateTimeString)
        {
            /*
             * In a global application. It is important to make a date time contract. But unfortunately
             * there are no specification on this in JSON. A common solution is to use the ISO 8601
             * specification. But even the ISO specification has different forms. So we create a method
             * to convert different kinds of data time string to actual date time. We accept the following
             * formats (and only support these formats):
             *
             * 1990-02-01T22:30:49+08:00
             * 1990-02-01T22:30:49
             *
             * If there are no time zone specified, we will treat it as UTC.
             */

            throw new NotImplementedException();
        }
    }
}