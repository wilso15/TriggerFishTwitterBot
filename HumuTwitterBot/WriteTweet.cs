using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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
    public class WriteTweet
    {
        Random rand = new Random();
        List<string> trendingTopics = new List<string>();

        public void tweetTrending()
        {
            trendingTopics = getTrendingTweets();
            string topic = trendingTopics[rand.Next(0, trendingTopics.Count)];
            string message = String.Format("{0} #{1}", FileMediaGetter.getFileItem("HumuFishFacts.txt"), topic);
            var tweet = Tweet.PublishTweet(message);
        }

        public List<string> getTrendingTweets()
        {
            int place = 2423945;
            var trends = Trends.GetTrendsAt(place);

            var trendTermToSearch = trends.Trends.ToList();
            List<string> trendingTopics = new List<string>();
            foreach (var topic in trendTermToSearch)
            {
                if (topic.Name.StartsWith("#"))
                {
                    string topicNoHash = topic.Name.Remove(0, 1);
                    trendingTopics.Add(topicNoHash);
                }
                else
                {
                    trendingTopics.Add(topic.Name);
                }
            }
            trendingTopics.Remove(" ");
            return trendingTopics;
        }

        public void tweetManual()
        {
            Console.WriteLine("Enter a tweet to be published:");
            string message = Console.ReadLine();
            var tweet = Tweet.PublishTweet(message);
        }

        public void tweetUser()
        {

        }
    }
}
