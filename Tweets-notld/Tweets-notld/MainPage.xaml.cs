using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Tweetinvi;
using Tweetinvi.Core.Credentials;
using Tweetinvi.Core.Enum;
using Tweetinvi.Core.Parameters;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Tweets_notld
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private TwitterParser twitterParser;
        public MainPage()
        {
            this.InitializeComponent();
            InitializeTwitter();

            var timer = new System.Threading.Timer(
                e => ParseTweets(),
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(5)
            );
        }

        private void InitializeTwitter()
        {
            Auth.SetUserCredentials("vBAvGQo2VyRq8T2bzPAHu8Mt6", "ZJ15cpQnWwgQTTutlkuqyB2T0OoVk83LfpfHeVOR9AQFD2nQyU", "3719969956-8jCJdi3YnZWfsRdAE2O6ogLViPw69rNTeBO1I9P", "bt2UC8Ac1A5ZSG87eriuDl2euGbrJcdsK9wlg7bmWETv1");
            twitterParser = new TwitterParser();
            ParseTweets();
            MyGridView.ItemsSource = twitterParser.observableTweets;
        }

        private void ParseTweets()
        {
            twitterParser.Parse();
        }
    }
}
