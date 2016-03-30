﻿using System;
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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace SpacePool
{
    public sealed partial class Enemy1 : UserControl
    {
        public double LocationX { get; set; }
        public double LocationY { get; set; }

        public Enemy1()
        {
            this.InitializeComponent();
            Width = 100;
            Height = 180;
        }
         
        // rect for enemy1
        public Rect GetRect()
        {
            return new Rect(LocationX, LocationY, Width, Height);
        }

        public void SetLocation()
        {
            SetValue(Canvas.LeftProperty, LocationX);
            SetValue(Canvas.TopProperty, LocationY);
        }
    }
}