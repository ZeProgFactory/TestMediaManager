
using MediaManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestMediaManager
{
   // Learn more about making custom code visible in the Xamarin.Forms previewer
   // by visiting https://aka.ms/xamarinforms-previewer
   [DesignTimeVisible(true)]
   public partial class MainPage : ContentPage
   {
      public MainPage()
      {
         InitializeComponent();

         // Hook into events
         CrossMediaManager.Current.StateChanged += Current_StateChanged;
      }

      private void Current_StateChanged(object sender, MediaManager.Playback.StateChangedEventArgs e)
      {
         Device.BeginInvokeOnMainThread(() =>
         {
            labelInfo.Text = $"{e.State} {CrossMediaManager.Current.Duration} {CrossMediaManager.Current.MediaQueue.Current?.Title}";
         });
      }

      private async void Button_Audio_Clicked(object sender, EventArgs e)
      {
         //Audio
         await CrossMediaManager.Current.Play("https://ia800806.us.archive.org/15/items/Mp3Playlist_555/AaronNeville-CrazyLove.mp3");
      }

      private async void Button_Video_Clicked(object sender, EventArgs e)
      {
         //Video
         await CrossMediaManager.Current.Play("http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4");
      }

      public IList<string> Mp3UrlList => new[]
      {
         "https://ia800806.us.archive.org/15/items/Mp3Playlist_555/AaronNeville-CrazyLove.mp3",
         "https://ia800605.us.archive.org/32/items/Mp3Playlist_555/CelineDion-IfICould.mp3",
         "https://ia800605.us.archive.org/32/items/Mp3Playlist_555/Daughtry-Homeacoustic.mp3",
         "https://storage.googleapis.com/uamp/The_Kyoto_Connection_-_Wake_Up/01_-_Intro_-_The_Way_Of_Waking_Up_feat_Alan_Watts.mp3",
         "https://aphid.fireside.fm/d/1437767933/02d84890-e58d-43eb-ab4c-26bcc8524289/d9b38b7f-5ede-4ca7-a5d6-a18d5605aba1.mp3"
      };

      private async void Button_PlayMultiple_Clicked(object sender, EventArgs e)
      {
         await CrossMediaManager.Current.Play(Mp3UrlList);
      }
   }
}
