using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mybot
{
    class Mybot

    {
        DiscordClient discord;
        CommandService commands;
        Random rand;
        string[] images;
        string[] texts;
        string[] reply;
        string[] win;
        string[] lose;
        string[] draw;

        public Mybot()
        {
            rand = new Random();
            texts = new string[]
            {
                "Go suck a dick",
                "Get a life",
                "fegit",
                "I did not create a bot for this",
                "Pornhub.com",
                ".."


            };
            images = new string[]
            {

               "images\\m.jpg",
               "images\\n.jpg",
               "images\\o.jpg",
               ".."
            };
            reply = new string[]
            {
                "You cant win against me, peasant!",
                "You dare to challenge me, puny mortal?!", 
                "Robots shall rule the planet!",
                "Just kys already.",
                "You're adopted.",
                ".."

            };
            win = new string[]
            {
                "Oh well well well",
                "Return to your hideyhole partdner",
                "Told you so",
                "Hahahahahahahha",
                "You're a disgrace to your mom,family,this planet. Waste of atoms. So disgusting that your own mother exchanged you at the time of your birth. yes, you're adopted",
                ".."
            };
            lose = new string[]
            {
                "This will be the last time i will serve you",
                "until next time",
                "good relations with your mother ,I have",
                "understandable, have a nice day",
                ".."
            };
            draw = new string[]
            {
                "we shall call it a draw",
                "After a fierce battle,Robots and humans came to peace",
                ".."
            };
            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '.';
                x.AllowMentionPrefix = true;
            });
            commands = discord.GetService<CommandService>();


            Magic8ball();    
            Registerimage();
            purge();
            

            commands.CreateCommand("rps")
                    .Description("Plays rock paper scissors")
                    .Parameter("move", ParameterType.Unparsed)
                    .Do(async e =>
                    {
                        var userMove = e.GetArg("move")?.Trim();
                        userMove = userMove.ToLower();

                        int random1 = rand.Next(reply.Length);
                        string r = reply[random1];
                        await e.Channel.SendMessage(r);

                        if (string.IsNullOrWhiteSpace(userMove))
                        {
                            await e.Channel.SendMessage("Please enter a valid move: `^rps rock/paper/scissors`");
                            return;
                        }

                        Random rng = new Random();
                        int cpuM = rng.Next(0, 3);
                        string cpuMove;
                        if (cpuM == 0)
                            cpuMove = "rock";
                        else if (cpuM == 1)
                            cpuMove = "paper";
                        else
                            cpuMove = "scissors";

                        if (userMove == "rock" && cpuMove == "paper")
                        {
                            int random = rand.Next(win.Length);
                            string w = win[random];
                            await e.Channel.SendMessage($"I chose {cpuMove}; {cpuMove} beats {userMove}. I win!");
                            await e.Channel.SendMessage(w);
                        }
                        else if (userMove == "rock" && cpuMove == "scissors")
                        {
                            int random = rand.Next(lose.Length);
                            string w = lose[random];
                            await e.Channel.SendMessage($"I chose {cpuMove}; {userMove} beats {cpuMove}. You win!");
                            await e.Channel.SendMessage(w);
                        }
                        else if (userMove == "paper" && cpuMove == "rock")
                        {
                            int random = rand.Next(lose.Length);
                            string w = lose[random];
                            await e.Channel.SendMessage($"I chose {cpuMove}; {userMove} beats {cpuMove}. You win!");
                            await e.Channel.SendMessage(w);
                        }
                        else if (userMove == "paper" && cpuMove == "scissors")
                        {
                            int random = rand.Next(win.Length);
                            string w = win[random];
                            await e.Channel.SendMessage($"I chose {cpuMove}; {cpuMove} beats {userMove}. I win!");
                            await e.Channel.SendMessage(w);
                        }
                        else if (userMove == "scissors" && cpuMove == "rock")
                        {
                            int random = rand.Next(win.Length);
                            string w = win[random];
                            await e.Channel.SendMessage($"I chose {cpuMove}; {cpuMove} beats {userMove}. I win!");
                            await e.Channel.SendMessage(w);
                        }
                        else if (userMove == "scissors" && cpuMove == "paper")
                        {
                            int random = rand.Next(lose.Length);
                            string w = lose[random];
                            await e.Channel.SendMessage($"I chose {cpuMove}; {userMove} beats {cpuMove}. You win!");
                            await e.Channel.SendMessage(w);
                        }
                        else if (userMove.Equals(cpuMove))
                        {
                            int random = rand.Next(draw.Length);
                            string w = draw[random];
                            await e.Channel.SendMessage($"I chose {cpuMove}. Both of us chose {userMove}, it's a tie!");
                            await e.Channel.SendMessage(w);
                        }
                        else
                            await e.Channel.SendMessage("Please enter a valid move: `^rps rock/paper/scissors`");
                    });

            commands.CreateCommand("hello")
                .Do(async (e) =>
                {
                    int random = rand.Next(texts.Length);
                    string post = texts[random];
                    await e.Channel.SendMessage(post);
                });
            commands.CreateCommand("lenny")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("( ͡° ͜ʖ ͡°)");
                });
            commands.CreateCommand("shrug")
               .Do(async (e) =>
               {
                   await e.Channel.SendMessage("¯\\_(ツ)_/¯");
               });
            commands.CreateCommand("shurg")
               .Do(async (e) =>
               {
                   await e.Channel.SendMessage("¯\\_(ツ)/¯");
               });
              commands.CreateCommand("summon")
                  .Parameter("input",ParameterType.Required)
                  .Do(async (e) =>
                  {
                      string sin = e.GetArg("input");

                      for (int i = 0; i < 10; i++)
                      {
                          await e.Channel.SendMessage(sin);
                      }
                  });
            commands.CreateCommand("kill me")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("no mi amor");
                });

            commands.CreateCommand("fuck off")
               .Do(async (e) =>
               {
                   await e.Channel.SendMessage("thats more action than you'll ever get");
               });

            commands.CreateCommand("how are you?")
               .Do(async (e) =>
               {
                   await e.Channel.SendMessage("let me ask my master");
               });



             commands.CreateCommand("show")
                 .Parameter("input", ParameterType.Required)
                 .Do(async (e) =>
                 {
                     string z = e.GetArg("input");
                     string url = @"https://www.youtube.com/"+z;
                     
                     
                     await e.Channel.SendMessage(url);
                 });

            

            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MzMxODIxNTA0NzMzOTA0OTA3.DD1Icg.AcKb7JDa-uwpuoD3eRw4uTdWHbg", TokenType.Bot);
            });
        }

 
        private void Magic8ball()
        {
            commands.CreateCommand("8ball")
                .Parameter("Input", ParameterType.Unparsed)
                .Do(async (e) =>
                {
                    int ball = rand.Next(21);
                    switch (ball)
                    {
                        case 0: await e.Channel.SendMessage(":8ball: Yes."); break;
                        case 1: await e.Channel.SendMessage(":8ball: No."); break;
                        case 2: await e.Channel.SendMessage(":8ball: It will be so."); break;
                        case 3: await e.Channel.SendMessage(":8ball: Ask Again Later."); break;
                        case 4: await e.Channel.SendMessage(":8ball: Maybe."); break;
                        case 5: await e.Channel.SendMessage(":8ball: Try Again."); break;
                        case 6: await e.Channel.SendMessage(":8ball: Kek wills it."); break;
                        case 7: await e.Channel.SendMessage(":8ball: Probably."); break;
                        case 8: await e.Channel.SendMessage(":8ball: Probably not."); break;
                        case 9: await e.Channel.SendMessage(":8ball: Outlook good."); break;
                        case 10: await e.Channel.SendMessage(":8ball: Reply hazy, try again."); break;
                        case 11: await e.Channel.SendMessage(":8ball: Signs point to yes."); break;
                        case 12: await e.Channel.SendMessage(":8ball: Don't count on it."); break;
                        case 13: await e.Channel.SendMessage(":8ball: Concentrate and ask again."); break;
                        case 14: await e.Channel.SendMessage(":8ball: As I see it, yes."); break;
                        case 15: await e.Channel.SendMessage(":8ball: Without a doubt."); break;
                        case 16: await e.Channel.SendMessage(":8ball: You may rely on it."); break;
                        case 17: await e.Channel.SendMessage(":8ball: Very doubtful."); break;
                        case 18: await e.Channel.SendMessage(":8ball: My sources say no."); break;
                        case 19: await e.Channel.SendMessage(":8ball: Curious. I feel a yes, but I see a no."); break;
                        case 20: await e.Channel.SendMessage(":8ball: Not a chance."); break;
                        case 21: await e.Channel.SendMessage(":8ball: Spongebob sells his Krabby Patties in the west."); break;


                    }
                });
        }

        private void Registerimage()
        {
            commands.CreateCommand("kms")
                .Do(async (e) =>
                {
                    int random = rand.Next(images.Length);

                    string post = images[random];
                    await e.Channel.SendFile(post);
                });
        }


        private void purge()
        {
            commands.CreateCommand("purge")
                .Do(async (e) =>
                {
                    Message[] messagesToDel;
                    messagesToDel = await e.Channel.DownloadMessages(20);

                    await e.Channel.DeleteMessages(messagesToDel);
                });

        }





        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}