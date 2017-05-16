//roll
command.CreateCommand("rollDice")
        .Description("Rolls a random Number between Min and Max")
        .Parameter("Min")
        .Parameter("Max")
        .Do(async e =>
        {
            await e.Channel.SendMessage($"[{random.Next(int.Parse(e.Args[0]), int.Parse(e.Args[1]) + 1)}]");
        });
//hangman
private ModuleManager _manager;
private Data.Session.Hangman hangman;

manager.CreateCommands("hangman", group =>
                       {
                               group.CreateCommand("start")
                                       .Description("Create a game of hangman")
                                       .Parameter("Word")
                                       .Parameter("Attempts")
                                       .Parameter("Server-ID")
                                       .Parameter("Channel-ID")
                                       .PrivateOnly()
                                       .Do(async e =>
                                           {
                                                   if (hangman == null || !hangman.active)
                                                   {
                                                           hangman = new Data.Session.Hangman(e.Args[0], int.Parse(e.Args[1]));
                                                           await e.User.SendMessage("Done!");
                                                           Channel message = _client.GetServer(ulong.Parse(e.Args[2])).GetChannel(ulong.Parse(e.Args[3]));
                                                           await message.SendMessage($"{e.User.Name} started a session of hangman!\n\nParticipate by using the **!hangman guess** command!\n\n{hangman.hidden} ({e.Args[1]} false tries allowed)");
                                                   }
                                                   else await e.User.SendMessage("Currently in use, sorry!");
                                           });
                                group.CreateCommand("guess")
                                        .Description("Guess a character")
                                        .Parameter("Guess")
                                        .Do(async e =>
                                            {
                                                    if (hangman.active)
                                                    {
                                                            string output = "";
                                                        if(e.Args[0].Length == hangman.word.Length)
                                                                 {
                                                                     output = hangman.solve(e.Args[0], e.User);
                                                                 }
                                                        else output = hangman.input(e.Args[0].ToCharArray()[0], e.User);
                                                        await e.Channel.SendMessage(output);
                                                    }
                                                else await e.Channel.SendMessage("No session of hangman running, sorry!");
                                            });
                       });
//random cat pics
using (var client = new WebClient())
{
        await e.Channel.SendMessage("Finding random cat image...");
        try
        {
                client.DownloadFile("http://thecatapi.com/api/images/get?format=src&type=png", @".\cat.png");
                await e.Channel.SendFile(@".\cat.png");
                if (File.Exists(@".\cat.png"))
                {
                        File.Delete(@".\cat.png");
                }
        }
        catch (Exception ex)
        {
                await e.Channel.SendMessage("An error occured :(");
        }
}
//
//
