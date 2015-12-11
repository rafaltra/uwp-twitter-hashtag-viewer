using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Core.Enum;
using Tweetinvi.Core.Interfaces;
using Tweetinvi.Core.Parameters;

namespace Tweets_notld
{
    class TwitterParser
    {
        public const string HASHTAG = "MTVStars";
        public IEnumerable<ITweet> tweetList;

        public ObservableCollection<ITweet> observableTweets;

        public TwitterParser()
        {
            observableTweets = new ObservableCollection<ITweet>();
        }

        public void Parse()
        {
            var searchParameter = new TweetSearchParameters("%23"+HASHTAG)
            {
                MaximumNumberOfResults = 20,
                SearchType = SearchResultType.Recent
            };

            tweetList = Search.SearchTweets(searchParameter);

            foreach (ITweet tweet in tweetList)
            {
                observableTweets.Add(tweet);
            }
        }

        internal async Task ParseAsync()
        {
            await Task.Run(() =>
            {
                var searchParameter = new TweetSearchParameters("%23" + HASHTAG)
                {
                    MaximumNumberOfResults = 20,
                    SearchType = SearchResultType.Recent
                };

                tweetList = Search.SearchTweets(searchParameter);
            });

            observableTweets.Clear();
            foreach (ITweet tweet in tweetList)
            {
                observableTweets.Add(tweet);
            }
        }
    }
}
