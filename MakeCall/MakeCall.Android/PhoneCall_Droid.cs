﻿using System;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Telephony;


using Xamarin.Forms;
using MakeCall.Droid;

[assembly:Dependency(typeof(PhoneCall_Droid))]
namespace MakeCall.Droid
{
    public class PhoneCall_Droid : IPhoneCall
    {
        public void MakeQuickCall(string PhoneNumber)
        {
            try
            {
                var uri = Android.Net.Uri.Parse(string.Format("tel:{0}", PhoneNumber));
                var intent = new Intent(Intent.ActionCall, uri);
                
                Xamarin.Forms.Forms.Context.StartActivity(intent);

            }
            catch(Exception ex)
            {
                new AlertDialog.Builder(Android.App.Application.Context).SetPositiveButton("OK", (sender, args) =>
                 {

                 })
                .SetMessage(ex.ToString())
                .SetTitle("Android Exception")
                .Show();
            }
            
        }
    }
}