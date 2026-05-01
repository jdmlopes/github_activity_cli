using System.CommandLine;

RootCommand root = new RootCommand("My CLI app description");

Argument<string> nameArgument = new("name")
{
    Description = "a name to greet",
    DefaultValueFactory = result => "World"
};

Command greetCommand = new Command("greet", "Greet the user by name")
{
    nameArgument
};

greetCommand.SetAction( result => Console.WriteLine($"Hello, {result.GetValue(nameArgument)}") );

root.Subcommands.Add(greetCommand);

ParseResult parseResult = root.Parse(args);

return parseResult.Invoke();