using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Core.Enum;
using Tweetinvi.Core.Interfaces;
using Tweetinvi.Core.Parameters;

namespace UwpTwitterHashtagViewer
{
    class TwitterParser
    {
        public const string HASHTAG = "MTVStars";

        public ObservableCollection<ITweet> observableTweets;

        public TwitterParser()
        {
            observableTweets = new ObservableCollection<ITweet>();
        }

        internal async Task ParseAsync()
        {
            IEnumerable<ITweet> tweetList = null;
            await Task.Run(() =>
            {
                var searchParameter = new TweetSearchParameters("%23" + HASHTAG)
                {
                    MaximumNumberOfResults = 20,
                    SearchType = SearchResultType.Recent
                };

                tweetList = Search.SearchTweets(searchParameter);
            });

            if (tweetList != null) {
                TweetComparator comparator = new TweetComparator();
                IEnumerable<ITweet> tweetsToRemove = observableTweets.Where(t => !tweetList.Contains(t, comparator)).ToList();
                foreach (ITweet tweet in tweetsToRemove)
                {
                    observableTweets.Remove(tweet);
                }

                IEnumerable<ITweet> tweetsToAdd = tweetList.Where(t => !observableTweets.Contains(t, comparator)).ToList();
                foreach (ITweet tweet in tweetsToAdd)
                {
                    observableTweets.Add(tweet);
                }
            }
        }
    }
}
