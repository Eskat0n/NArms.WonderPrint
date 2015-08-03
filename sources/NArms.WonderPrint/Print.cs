namespace NArms.WonderPrint
{
    using System;
    using System.Linq;
    using System.Text;
    using Utilities;

    public static class Print
    {
        public static IPrinter This(object input)
        {
            return new DefaultPrinter(input);
        }

        private class DefaultPrinter : IPrinter
        {
            private readonly object _input;
            private readonly string _indent;

            public DefaultPrinter(object input)
            {
                _input = input;
                _indent = "  ";
            }

            public void ToConsole()
            {
                Console.Write(AsString());
            }

            public string AsString()
            {
                return Dump(WrapperHelper.ToDictionary(_input), 0, 1);
            }

            private string Dump(object input, int indentLength, int indentDepth)
            {
                if (input == null)
                    return "null\n";

                var builder = new StringBuilder();

                var indentBase = IndentHelper.GetIndent(" ", indentLength);
                var indent = $"{indentBase}{IndentHelper.GetIndent(_indent, indentDepth)}";

                if (input is IObjectWrapper)
                {
                    var wrapper = (IObjectWrapper) input;

                    var maxKeyLength = wrapper.Keys.Max(x => x.Length);
                    var childrenIndentBase = indentDepth * _indent.Length + maxKeyLength + 2;

                    builder.AppendFormat("{0} #{1}\n", wrapper.Name, wrapper.HashCode);
                    builder.AppendFormat("{0}{{\n", indentBase);

                    foreach (var pair in wrapper)
                    {
                        var itemKey = pair.Key.PadLeft(maxKeyLength);
                        var itemValueDump = Dump(pair.Value, childrenIndentBase, indentDepth + 1);

                        builder.AppendFormat("{0}{1} = {2}", indent, itemKey, itemValueDump);
                    }

                    builder.AppendFormat("{0}}}\n", indentBase);
                }
                else if (input is IEnumerableWrapper)
                {
                    var wrapper = (IEnumerableWrapper) input;

                    var maxIndexLength = (wrapper.Count - 1).ToString().Length;
                    var childrenIndentBase = indentDepth * _indent.Length + maxIndexLength + 3;

                    if (wrapper.Count == 0)
                    {
                        builder.AppendFormat("{0} = [ ]\n", wrapper.Name);
                    }
                    else
                    {
                        builder.AppendFormat("{0} #{1}\n", wrapper.Name, wrapper.HashCode);
                        builder.AppendFormat("{0}[\n", indentBase);

                        for (var i = 0; i < wrapper.Count; i++)
                        {
                            var itemIndex = i.ToString().PadLeft(maxIndexLength);
                            var itemValueDump = Dump(wrapper[i], childrenIndentBase, indentDepth + 1);

                            builder.AppendFormat("{0}[{1}] {2}", indent, itemIndex, itemValueDump);
                        }

                        builder.AppendFormat("{0}]\n", indentBase);
                    }
                }
                else
                {
                    return $"{Types.TypePrinters[input.GetType()].Format(input)}\n";
                }

                return builder.ToString();
            }
        }
    }
}