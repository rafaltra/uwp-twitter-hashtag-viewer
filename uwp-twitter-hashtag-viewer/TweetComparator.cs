using System.Collections.Generic;
using Tweetinvi.Core.Interfaces;

namespace UwpTwitterHashtagViewer
{
    class TweetComparator : IEqualityComparer<ITweet>
    {
        public bool Equals(ITweet x, ITweet y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(ITweet obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
