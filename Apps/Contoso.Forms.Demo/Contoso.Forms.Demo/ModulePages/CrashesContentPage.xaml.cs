﻿using System;
using System.IO;
using Microsoft.Azure.Mobile.Crashes;
using Xamarin.Forms;

namespace Contoso.Forms.Demo
{
    public partial class CrashesContentPage : ContentPage
    {
        public CrashesContentPage()
        {
            InitializeComponent();
            if (Device.OS == TargetPlatform.iOS)
            {
                Icon = "socket.png";
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CrashesEnabledSwitchCell.On = Crashes.Enabled;
        }

        void TestCrash(object sender, System.EventArgs e)
        {
            Crashes.GenerateTestCrash();
        }

        void DivideByZero(object sender, System.EventArgs e)
        {
            int x = 42 / int.Parse("0");
        }

        void UpdateEnabled(object sender, System.EventArgs e)
        {
            if (CrashesEnabledSwitchCell != null)
            {
                Crashes.Enabled = CrashesEnabledSwitchCell.On;
            }
        }

        private void CrashWithAggregateException(object sender, EventArgs e)
        {
            throw PrepareException();
        }

        private static Exception PrepareException()
        {
            try
            {
                throw new AggregateException(SendHttp(), new ArgumentException("Invalid parameter", ValidateLength()));
            }
            catch (Exception e)
            {
                return e;
            }
        }

        private static Exception SendHttp()
        {
            try
            {
                throw new IOException("Network down");
            }
            catch (Exception e)
            {
                return e;
            }
        }

        private static Exception ValidateLength()
        {
            try
            {
                throw new ArgumentOutOfRangeException(null, "It's over 9000!");
            }
            catch (Exception e)
            {
                return e;
            }
        }
    }
}
