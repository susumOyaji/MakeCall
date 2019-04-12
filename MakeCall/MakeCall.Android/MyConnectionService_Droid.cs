using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//using Android.Telecom.PhoneAccountHandle;
//using Android.Telecom.ConnectionRequest;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Telecom;
using Android.Util;
using Java.Lang;
using Xamarin.Forms;
using MakeCall.Droid;


[assembly: Dependency(typeof(MyConnectionService_Droid))]
namespace MakeCall.Droid
{
    public class MyConnectionService_Droid : ConnectionService
    {
        //テレコムサブシステムは、アプリの呼び出しに応じてこのメソッドを呼び出しplaceCall(Uri, Bundle) 、新しい発信通話を作成します
        public  override  Connection OnCreateOutgoingConnection(PhoneAccountHandle connectionManagerPhoneAccount, ConnectionRequest request)
       {
            Connection connection = base.OnCreateOutgoingConnection(connectionManagerPhoneAccount, request);
            Log.d(TAG, connection.getDisconnectCause().getReason());
            return connection;
       }
        
        //アプリがplaceCall(Uri, Bundle)メソッドを呼び出し、発信呼び出しを行うことができない場合、テレコムサブシステムはこのメソッドを呼び出します。
        public override void OnCreateOutgoingConnectionFailed(PhoneAccountHandle connectionManagerPhoneAccount, ConnectionRequest request)
        {
            if (request != null)
            {
                //Log.d(TAG, request.toString());
            }
            base.OnCreateOutgoingConnectionFailed(connectionManagerPhoneAccount, request);
        }

        private static readonly string TAG = "MyService";
        public override Connection onCreateIncomingConnection(PhoneAccountHandle connectionManagerPhoneAccount, ConnectionRequest request)
        {
            Log.i(TAG, "onCreateIncomingConnection60");
            //Log.i(TAG, connectionManagerPhoneAccount.toString());
            //Log.i(TAG, request.toString());
            return base.OnCreateIncomingConnection(connectionManagerPhoneAccount, request);
        }















    }
}