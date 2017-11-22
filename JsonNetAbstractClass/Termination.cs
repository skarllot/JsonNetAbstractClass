using System;
using System.Runtime.Serialization;

namespace JsonNetAbstractClass
{
    [Serializable]
    public class Termination : BaseClass, IEquatable<Termination>
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

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            return Equals(obj as Termination);
        }

        public bool Equals(Termination other)
        {
            if (other == null)
                return false;

            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value;
        }

        protected override void InternalGetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Value), Value);
        }
    }
}
