command.CreateCommand("reken")
    .parameter("args")
    .Do(async (e) =>
    {
        var args = e.args;
    if(args[0] == "")
    {
        await e.Channel.SendMessage("You need number");
    }
    if(args[1] == "")
    {
        await e.Channel.SendMessage("You need a seperator");
    }
    if(args[2] == "")
    {
        await e.Channel.SendMessage("You need a second number");
    }
    if(args[1] == "+")
    {
        var ant = args[0] ++ args[2];
        await e.Channel.SendMessage($"Your awnser is {ant}"
    }
    if(args[1] == "-")
    {
        var ant = args[0] -- args[2];
        await e.Channel.SendMessage($"You awnser is {ant}")
    }
    });
