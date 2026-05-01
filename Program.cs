using System.CommandLine;

RootCommand root = new RootCommand("My CLI app description");

Argument<string> username = new("username")
{
    Description = "username of the user to search for activity"
};

root.Arguments.Add(username);

root.SetAction(result =>
{
    Console.WriteLine($"Todo: fetch user data for user '{result.GetValue(username)}'");
});
ParseResult parseResult = root.Parse(args);

return parseResult.Invoke();