﻿namespace Shopii.CrossCutting.Exceptions
{
    public class NotFoundRequestException : Exception
    {
        public NotFoundRequestException(string message) : base(message) { }
    }

}
