using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Net.Http;
using System.Reflection;
using Tweetinvi;
using Tweetinvi.Core;
using Tweetinvi.Core.Credentials;
using Tweetinvi.Core.Enum;
using Tweetinvi.Core.Extensions;
using Tweetinvi.Core.Interfaces;
using Tweetinvi.Core.Interfaces.Controllers;
using Tweetinvi.Core.Interfaces.DTO;
using Tweetinvi.Core.Interfaces.Models;
using Tweetinvi.Core.Interfaces.Streaminvi;
using Tweetinvi.Core.Parameters;
using Tweetinvi.Json;
using SavedSearch = Tweetinvi.SavedSearch;
using Stream = Tweetinvi.Stream;

namespace HumuTwitterBot
{
    class Start
    {
        public void RunBot()
        {
            Auth.SetUserCredentials("CONSUMER_KEY", "CONSUMER_SECRET", "ACCESS_TOKEN", "ACCESS_TOKEN_SECRET");

            WriteTweet wt = new WriteTweet();
            Console.WriteLine("Enter 'auto' to tweet a trending topic, or 'manual' to enter your own tweet.");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "auto":
                    wt.tweetTrending();
                    Console.WriteLine("sleeping two minutes");
                    Thread.Sleep(120000);
                    RunBot();
                    break;
                case "manual":
                    wt.tweetManual();
                    RunBot();
                    break;
            }
        }
    }
}
