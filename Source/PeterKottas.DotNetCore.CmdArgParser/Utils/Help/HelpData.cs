using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeterKottas.DotNetCore.CmdArgParser.Utils.Help
{
    public class HelpData
    {
        public List<CmdArgParam> parameters;

        public string AppDescription { get; set; }
    }
}
