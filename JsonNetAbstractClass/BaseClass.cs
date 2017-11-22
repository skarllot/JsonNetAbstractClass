using System;
using System.Runtime.Serialization;

namespace JsonNetAbstractClass
{
    [Serializable]
    public abstract class BaseClass : ISerializable
    {
        protected BaseClass()
        {
        }
        
        protected BaseClass(SerializationInfo info, StreamingContext context)
        {
        }
        
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            InternalGetObjectData(info, context);
        }
        
        protected abstract void InternalGetObjectData(SerializationInfo info, StreamingContext context);
    }
}
