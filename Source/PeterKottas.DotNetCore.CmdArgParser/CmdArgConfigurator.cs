using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeterKottas.DotNetCore.CmdArgParser.Utils.Help;

namespace PeterKottas.DotNetCore.CmdArgParser
{
    public class CmdArgConfigurator
    {
        CmdArgConfiguration config;
        public CmdArgConfigurator(CmdArgConfiguration config)
        {
            this.config = config;
        }

        public void AddParameter(CmdArgParam param)
        {
            config.parameters.Add(param);
        }

        public void AddParameters(List<CmdArgParam> parameters)
        {
            foreach (var param in parameters)
            {
                AddParameter(param);
            }
        }

        public void AddParameters(params CmdArgParam[] parameters)
        {
            foreach (var param in parameters)
            {
                AddParameter(param);
            }
        }

        public void UseDefaultHelp()
        {
            config.parameters.Add(new CmdArgParam()
            {
                Description = "Shows application help",
                Key = "help",
                Value = (val) => DisplayHelp()
            });
        }

        public void UseAppDescription(string description)
        {
            config.AppDescription = description;
        }

        public void ShowHelpOnExtraArguments()
        {
            config.ShowHelpOnExtraArguments = true;
        }

        public void CustomHelp(Action<HelpData> helpAction)
        {
            config.CustomHelp = helpAction;
        }

        public void DisplayHelp()
        {
            
            var helpData = new HelpData()
            {
                AppDescription = config.AppDescription,
                parameters = config.parameters.Select(item => new CmdArgParam()
                {
                    Description = item.Description,
                    Key = item.Key,
                    Value = item.Value
                }).ToList()
            };
            if(config.CustomHelp!=null)
            {
                try
                {
                    config.CustomHelp(helpData);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Custom help provided in this implementation thrown an exception.");
                    Console.WriteLine("Exception details:");
                    Console.WriteLine(e.ToString());
                    Console.WriteLine("Showing default help instead:");
                    Help.Show(helpData);
                }
            }
            else
            {
                Help.Show(helpData);
            }
        }
    }
}
