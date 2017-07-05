using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public Mybot()
        {
            rand = new Random();
            texts = new string[]
            {
                "Go suck a dick",
                "Get a life",
                "fegit",
                "I did not create a bot for this",
                "Pornhub.com"


            };
            images = new string[]
            {

               "images\\m.jpg",
               "images\\n.jpg",
               "images\\o.jpg"
            };
            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });
            commands = discord.GetService<CommandService>();

            Registerimage();
            purge();

            commands.CreateCommand("hello")
                .Do(async (e) =>
                {
                    int random = rand.Next(texts.Length);
                    string post = texts[random];
                    await e.Channel.SendMessage(post);
                });

            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MzMxODIxNTA0NzMzOTA0OTA3.DD1Icg.AcKb7JDa-uwpuoD3eRw4uTdWHbg", TokenType.Bot);
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
            commands.CreateCommand("p")
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
