﻿using Windows.UI.Xaml.Controls;
using Tweetinvi;
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UwpTwitterHashtagViewer
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

            DoTimer();
        }

        private async void DoTimer()
        {
            while (true)
            {
                await twitterParser.ParseAsync();
                await Task.Delay(5000);
            }
        }

        private void InitializeTwitter()
        {
            Auth.SetUserCredentials("vBAvGQo2VyRq8T2bzPAHu8Mt6", "ZJ15cpQnWwgQTTutlkuqyB2T0OoVk83LfpfHeVOR9AQFD2nQyU", "3719969956-8jCJdi3YnZWfsRdAE2O6ogLViPw69rNTeBO1I9P", "bt2UC8Ac1A5ZSG87eriuDl2euGbrJcdsK9wlg7bmWETv1");
            twitterParser = new TwitterParser();
            MyGridView.ItemsSource = twitterParser.observableTweets;
        }
    }
}
