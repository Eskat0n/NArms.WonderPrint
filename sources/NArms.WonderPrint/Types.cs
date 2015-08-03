namespace NArms.WonderPrint
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using TypePrinters;

    public static class Types
    {
        public static readonly HashSet<Type> Atomic
            = new HashSet<Type>(new[]
            {
                typeof (bool),
                typeof (byte),
                typeof (short),
                typeof (ushort),
                typeof (int),
                typeof (uint),
                typeof (long),
                typeof (ulong),
                typeof (float),
                typeof (double),
                typeof (decimal),
                typeof (char),
                typeof (string),
                typeof (DateTime),
                typeof (TimeSpan),
                typeof (Guid),
                typeof (Uri),
                typeof (IPAddress)
            });

        public static readonly IDictionary<Type, ITypePrinter> TypePrinters
            = new Dictionary<Type, ITypePrinter>
            {
                [typeof (bool)] = new BooleanTypePrinter(),
                [typeof (byte)] = new DirectTypePrinter(),
                [typeof (short)] = new DirectTypePrinter(),
                [typeof (ushort)] = new DirectTypePrinter(),
                [typeof (int)] = new Int32TypePrinter(),
                [typeof (uint)] = new DirectTypePrinter(),
                [typeof (long)] = new DirectTypePrinter(),
                [typeof (ulong)] = new DirectTypePrinter(),
                [typeof (float)] = new DirectTypePrinter(),
                [typeof (double)] = new DirectTypePrinter(),
                [typeof (decimal)] = new DirectTypePrinter(),
                [typeof (char)] = new DirectTypePrinter(),
                [typeof (string)] = new StringTypePrinter(),
                [typeof (DateTime)] = new DirectTypePrinter(),
                [typeof (TimeSpan)] = new DirectTypePrinter(),
                [typeof (Guid)] = new DirectTypePrinter(),
                [typeof (Uri)] = new DirectTypePrinter(),
                [typeof (IPAddress)] = new DirectTypePrinter()
            };
    }
}