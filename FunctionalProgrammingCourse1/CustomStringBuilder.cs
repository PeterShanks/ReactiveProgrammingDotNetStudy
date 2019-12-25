using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FunctionalProgrammingCourse1
{
    public static class CustomStringBuilder
    {
        public static StringBuilder AppendFormattedLine(
            this StringBuilder stringBuilder,
            string format,
            params object[] args) => stringBuilder.AppendFormat(format, args).AppendLine();

        public static StringBuilder AppendWhen(this StringBuilder stringBuilder,
            Func<bool> predicate,
            Func<StringBuilder, StringBuilder> operation) => predicate() ? operation(stringBuilder) : stringBuilder;

        public static StringBuilder AppendSequence<T>(
            this StringBuilder stringBuilder,
            IEnumerable<T> sequence,
            Func<StringBuilder, T, StringBuilder> operation
        ) => sequence.Aggregate(stringBuilder, operation);

    }

    public static class FunctionalExtensions
    {
        public static TResult Map<TInput, TResult>(
            this TInput input,
            Func<TInput, TResult> operation) => operation(input);

        public static TInput Tee<TInput>(
            this TInput input,
            Action<TInput> action)
        {
            action(input);
            return input;
        }
    }

    public class UsingFunctionalProgramming
    {
        public void Begin()
        {
            var selectBox =
                Disposable
                    .Using(
                        () => new MemoryStream(),
                        stream => new byte[stream.Length].Tee(b => stream.Read(b, 0, (int)stream.Length)))
                    .Map(Encoding.UTF8.GetString)
                    .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                    .Select((s, ix) => Tuple.Create(ix, s))
                    .ToDictionary(k => k.Item1, v => v.Item2)
                    .Map(BuildSelectBox("theDoctors", true))
                    .Tee(Console.WriteLine);


            Console.WriteLine(selectBox);
            Console.ReadLine();
        }



        public static Func<IDictionary<int, string>, string> BuildSelectBox(string id, bool includeUnknown) => 
            options => new StringBuilder()
                .AppendFormattedLine("<select id=\"{0}\" name=\"{1}\">", id)
                .AppendWhen(
                    () => includeUnknown,
                    stringBuilder => stringBuilder.AppendLine("\t<option>Unknown</option>"))
                .AppendSequence(
                    options,
                    (stringBuilder, op) =>
                        stringBuilder.AppendFormattedLine("\t<option value=\"{0}\">{1}</option>", op.Key, op.Value))
                .AppendLine("</select>")
                .ToString();
    }
}
