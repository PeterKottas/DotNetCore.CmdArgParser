using System.Collections.Generic;

namespace PeterKottas.DotNetCore.CmdArgParser.Utils.Help
{
    public class HelpData
    {
        public List<CmdArgParam> Parameters;

        public string AppDescription { get; set; }
    }
}
