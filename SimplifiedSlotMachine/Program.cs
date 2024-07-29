// See https://aka.ms/new-console-template for more information


using Microsoft.Extensions.Configuration;

using SimplifiedSlotMachine.Configuration;
using SimplifiedSlotMachine.Input;
using SimplifiedSlotMachine.InputOutput;
using SimplifiedSlotMachine.Runners;
using SimplifiedSlotMachine.Services;

// See readme.md for info on configuration file
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

/* 
 * TODO - Reading configuration should be validated, etc. but for the purpose of this project I've left it out
 * to avoid it ballooning to an even larger size. But I wanted it to be configurable without inline params.
*/
var section = configuration.GetSection(nameof(SlotsConfiguration));
var slotsConfig = section.Get<SlotsConfiguration>();

// TODO - Handle null
var spinService = new SpinService(slotsConfig.SpinOptions);
var moneyService = new MoneyService();
var inputReader = new InputReader();
var outputWriter = new SlotOutputWriter();
var gameRunner = new SlotRunner(spinService, moneyService, inputReader,
                                outputWriter, slotsConfig.Rows, slotsConfig.Columns);
gameRunner.Run();
