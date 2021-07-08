using System;
using System.Collections.Generic;

namespace PeterKottas.DotNetCore.CmdArgParser
{
    public class CmdArgParam
    {
        private Action<string> _value;

        public string Key { get; set; }

        public List<string> Keys
        {
            get
            {
                if (string.IsNullOrEmpty(Key))
                {
                    return new List<string>();
                }

                var split = Key.Split('|');

                return new List<string>(split);
            }
        }

        public Action<string> Value
        {
            get
            {
                if (_value != null)
                {
                    return _value;
                }

                return (val) => { };
            }
            set
            {
                _value = value;
            }
        }

        public string Description { get; set; }
    }
}
