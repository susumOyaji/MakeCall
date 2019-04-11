using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Telecom;

using Java.Lang;
using Xamarin.Forms;
using MakeCall.Droid;


[assembly: Dependency(typeof(MyConnectionService_Droid))]
namespace MakeCall.Droid
{
    public class MyConnectionService_Droid : ConnectionService
    {
         



    public  override  Connection OnCreateOutgoingConnection(PhoneAccountHandle connectionManagerPhoneAccount, ConnectionRequest request)
       {
            Connection connection = base.OnCreateOutgoingConnection(connectionManagerPhoneAccount, request);
            //Log.d(TAG, connection.getDisconnectCause().getReason());
            return connection;
       }



        












    }
}