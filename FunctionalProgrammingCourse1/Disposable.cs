using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FunctionalProgrammingCourse1
{
    public static class Disposable
    {
        public static TResult Using<TDisposable, TResult>(
            Func<TDisposable> factory, Func<TDisposable, TResult> body) where TDisposable: IDisposable
        {
            using var disposable = factory() ;
            return body(disposable);
        }
    }
}
