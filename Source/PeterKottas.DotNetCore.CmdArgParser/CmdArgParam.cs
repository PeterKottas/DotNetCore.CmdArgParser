using System;
using System.Collections.Generic;

namespace PeterKottas.DotNetCore.CmdArgParser
{
    public class CmdArgParam
    {
        private Action<string> value;

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
                if (value != null)
                {
                    return value;
                }
                else
                {
                    return (val) => { };
                }
            }
            set
            {
                this.value = value;
            }
        }

        public string Description { get; set; }
    }
}