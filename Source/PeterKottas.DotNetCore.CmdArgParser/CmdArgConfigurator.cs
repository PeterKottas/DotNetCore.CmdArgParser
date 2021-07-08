using System;
using System.Collections.Generic;
using System.Linq;
using PeterKottas.DotNetCore.CmdArgParser.Utils.Help;

namespace PeterKottas.DotNetCore.CmdArgParser
{
    public class CmdArgConfigurator
    {
        private readonly CmdArgConfiguration _config;

        public CmdArgConfigurator(CmdArgConfiguration config)
        {
            _config = config;
        }

        public void AddParameter(CmdArgParam param)
        {
            _config.Parameters.Add(param);
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
            _config.Parameters.Add(new CmdArgParam
            {
                Description = "Shows application help",
                Key = "help",
                Value = (val) => DisplayHelp()
            });
        }

        public void UseAppDescription(string description)
        {
            _config.AppDescription = description;
        }

        public void ShowHelpOnExtraArguments()
        {
            _config.ShowHelpOnExtraArguments = true;
        }

        public void CustomHelp(Action<HelpData> helpAction)
        {
            _config.CustomHelp = helpAction;
        }

        public void DisplayHelp()
        {
            var helpData = new HelpData
            {
                AppDescription = _config.AppDescription,
                Parameters = _config.Parameters.Select(item => new CmdArgParam
                {
                    Description = item.Description,
                    Key = item.Key,
                    Value = item.Value
                }).ToList()
            };

            if (_config.CustomHelp != null)
            {
                try
                {
                    _config.CustomHelp(helpData);
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
