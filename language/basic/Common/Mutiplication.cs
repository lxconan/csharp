using System;
using System.Collections.Generic;
using System.Text;

namespace basic.Common
{
    public class Mutiplication
    {
        public static string MutiplicationTable(int start, int end)
        {
            StringBuilder stringMutilcationTableBuilerBuilder = new StringBuilder();
            for (long rowIndex = start; rowIndex <= end; ++rowIndex)
            {
                for (long columnIndex = start; columnIndex <= rowIndex; ++columnIndex)
                {
                    stringMutilcationTableBuilerBuilder.Append(($"{columnIndex} * {rowIndex} = {rowIndex * columnIndex} ").PadRight(MaxLength(start, end)));
                }

                stringMutilcationTableBuilerBuilder.AppendLine();
            }

            return stringMutilcationTableBuilerBuilder.ToString();
        }

        static int MaxLength(int start, int end)
        {
            int maxLength = 0;

            for (long rowIndex = start; rowIndex <= end; ++rowIndex)
            {
                for (long columnIndex = start; columnIndex <= rowIndex; ++columnIndex)
                {
                    maxLength = ($"{columnIndex} * {rowIndex} = {rowIndex * columnIndex} ").Length > maxLength
                        ? ($"{columnIndex} * {rowIndex} = {rowIndex * columnIndex} ").Length
                        : maxLength;
                }
            }

            return maxLength;
        }
    }
}
