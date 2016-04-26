﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SpacePool
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MediaElement mediaElement;
       private MediaElement clickElement;

        

        // get background and click audio
        public async void LoadAudio()
        {
            mediaElement = new MediaElement();
            mediaElement.AutoPlay = true;
            mediaElement.IsLooping = true;
            StorageFolder folder1 = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            StorageFile file1 = await folder1.GetFileAsync("spaceambience.wav");
            var stream1 = await file1.OpenAsync(FileAccessMode.Read);
            mediaElement.SetSource(stream1, file1.ContentType);
            clickElement = new MediaElement();
            clickElement.AutoPlay = false;
            StorageFolder folder2 = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            StorageFile file2 = await folder2.GetFileAsync("click.wav");
            var stream2 = await file2.OpenAsync(FileAccessMode.Read);
            clickElement.SetSource(stream2, file2.ContentType);
        }

        public MainPage()
        {
            this.InitializeComponent();

            ApplicationView.PreferredLaunchWindowingMode
                = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.PreferredLaunchViewSize = new Size(1280, 720);

            // load audio elements
            LoadAudio();
            // play background audio
            mediaElement.Play();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            // get to Game Page when clicked
            this.Frame.Navigate(typeof(GamePage));
            // play the click sound as the button gets clicked
            clickElement.Play();
        }

        private void InstructionsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(InstructionsPage));
            clickElement.Play();
        }

        private void CreditButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Credits));
            clickElement.Play();
        }
    }
}
