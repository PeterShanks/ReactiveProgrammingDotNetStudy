using System;
using System.Net;
using System.Xml.Linq;

namespace FunctionalProgrammingCourse1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Using Functional Disposable

            //var time = Disposable
            //    .Using(() => new WebClient(),
            //        client => XDocument.Parse(client.DownloadString("hamada")))
            //    ?.Root
            //    ?.Attribute("Time")
            //    ?.Value;

            #endregion

            #region Using Delegates
            new SimpleFunctionalCalculator().Begin();
            #endregion
        }
    }
}
