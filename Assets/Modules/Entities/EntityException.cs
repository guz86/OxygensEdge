using System;

namespace Modules.Entities
{
    public class EntityException : Exception
    {
        public EntityException(string message) : base(message)
        {
        }
    }
}