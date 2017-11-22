using System;
using System.Runtime.Serialization;

namespace JsonNetAbstractClass
{
    [Serializable]
    public class Termination : BaseClass
    {
        public int Value { get; set; }

        public Termination()
        {
        }

        public Termination(int value)
        {
            Value = value;
        }

        private Termination(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            foreach (var item in info)
            {
                switch (item.Name)
                {
                    case nameof(Value):
                        Value = info.GetInt32(item.Name);
                        break;
                }
            }
        }

        protected override void InternalGetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Value), Value);
        }
    }
}
