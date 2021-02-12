using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Abstract
{   
    //Temel voidler için
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
