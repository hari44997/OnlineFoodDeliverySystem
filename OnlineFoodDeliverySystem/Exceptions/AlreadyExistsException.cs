﻿namespace OnlineFoodDeliverySystem.Exceptions
{
    public class AlreadyExistsException :ApplicationException
    {
        public AlreadyExistsException(string message) : base(message) { }
    }
}
