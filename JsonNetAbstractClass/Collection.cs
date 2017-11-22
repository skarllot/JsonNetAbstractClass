using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace JsonNetAbstractClass
{
    [Serializable]
    public sealed class Collection : BaseClass
    {
        private readonly List<BaseClass> children;

        public Collection()
        {
            children = new List<BaseClass>();
        }

        private Collection(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            // Default values
            children = new List<BaseClass>();

            foreach (var item in info)
            {
                switch (item.Name)
                {
                    case nameof(Children):
                        var childrenArray = (BaseClass[])info.GetValue(item.Name, typeof(BaseClass[]));
                        children.AddRange(childrenArray);
                        break;
                }
            }
        }

        public IEnumerable<BaseClass> Children => children;

        public int Count => children.Count;

        public void Add(BaseClass instance)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));

            children.Add(instance);
        }

        public void AddRange(IEnumerable<BaseClass> colExpression)
        {
            if (colExpression == null)
                throw new ArgumentNullException(nameof(colExpression));

            children.AddRange(colExpression);

            // Remove null expressions
            while (children.Remove(null))
            {
            }
        }

        public void Clear()
        {
            children.Clear();
        }

        public bool Contains(BaseClass instance)
        {
            if (instance == null)
                return false;

            return children.Contains(instance);
        }

        public bool Remove(BaseClass instance)
        {
            if (instance == null)
                return false;

            return children.Remove(instance);
        }

        public void RemoveAt(int index)
        {
            children.RemoveAt(index);
        }

        protected override void InternalGetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Children), children.ToArray(), typeof(BaseClass[]));
        }
    }
}
