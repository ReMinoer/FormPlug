using System;
using System.Collections.Generic;
using System.Linq;
using FormPlug.SocketAttributes;

namespace FormPlug.PlugsBase
{
    public abstract class EnumPlugBase<TValue, TControl> : Plug<TValue, TControl, EnumSocketAttribute>
        where TControl : new()
    {
        protected abstract string Output { get; set; }

        public sealed override TValue Value
        {
            get
            {
                string name = _altNames.ContainsValue(Output) ? _altNames.First(p => p.Value == Output).Key : Output;
                return (TValue)Enum.Parse(typeof(TValue), name);
            }
            set
            {
                string name = Enum.GetName(typeof(TValue), value);
                Output = name != null && _altNames.ContainsKey(name) ? _altNames[name] : name;
            }
        }
        private readonly Dictionary<string, string> _altNames = new Dictionary<string, string>();

        protected EnumPlugBase() {}

        protected EnumPlugBase(TControl control)
            : base(control) {}

        protected override bool IsTypeValid(Type type)
        {
            return type.IsEnum;
        }

        protected override void InitializeControl()
        {
            InitializeNames(Enum.GetNames(typeof(TValue)));
        }

        protected sealed override void UseCustomAttribute(EnumSocketAttribute attribute)
        {
            _altNames.Clear();

            string[] names = Enum.GetNames(typeof(TValue));

            if (attribute.AlternativeNames != null)
                for (int i = 0; i < attribute.AlternativeNames.Length; i++)
                {
                    _altNames.Add(names[i], attribute.AlternativeNames[i]);
                    names[i] = _altNames[names[i]];
                }

            InitializeNames(names);
        }

        protected abstract void InitializeNames(IEnumerable<string> names);
    }
}