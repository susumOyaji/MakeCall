using System;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Telephony;


using Java.Util;
using Uri = Android.Net.Uri;


using Xamarin.Forms;
using MakeCall.Droid;

[assembly:Dependency(typeof(PhoneCall_Droid))]
namespace MakeCall.Droid
{
    public class PhoneCall_Droid : IPhoneCall
    {
        [Obsolete]
        public void MakeQuickCall(string PhoneNumber)
        {

            var context = Forms.Context;
            /*   
            var intent = new Intent(Intent.ActionCall);
            intent.SetData(Uri.Parse("tel:" + PhoneNumber));
            context.StartActivity(intent);
            */


            var callIntent = new Intent(Intent.ActionCall);
            new AlertDialog.Builder(context)
                .SetMessage("Call " + PhoneNumber + "?")
                .SetNeutralButton("Call", delegate {
                    callIntent.SetData(Android.Net.Uri.Parse("tel:" + PhoneNumber));
                    context.StartActivity(callIntent);
                })
                .SetNegativeButton("Cancel", delegate { })
                .Show();
        






        /*
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


            var dlg = new AlertDialog.Builder(Android.App.Application.Context);
            dlg.SetTitle("タイトル");
            dlg.SetMessage("メッセージ");
            dlg.SetPositiveButton( //OKボタンの処理
                "OK", (s, a) => Toast.MakeText(Android.App.Application.Context, "OK", ToastLength.Short).Show());
            dlg.SetNegativeButton( //Cancelボタンの処理
                "Cancel", (s, a) => Toast.MakeText(Android.App.Application.Context, "Cancel", ToastLength.Short).Show());
            dlg.Create().Show();



        }*/

    }
    }
}