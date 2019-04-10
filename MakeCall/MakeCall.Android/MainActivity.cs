using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Telecom;
using Android.Telephony;
using Android.Net.Sip;

namespace MakeCall.Droid
{
    [Activity(Label = "MakeCall", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        //@Override
        public override Connection onCreateIncomingConnection(PhoneAccountHandle connectionManagerPhoneAccount, ConnectionRequest request)
        {

            //Toast.makeText(getApplicationContext(), "onCreateIncomingConnection called", Toast.LENGTH_SHORT).show();
            Connection incomingCallCannection = createConnection(request);
            incomingCallCannection.SetRinging();
            return incomingCallCannection;
        }

        //@Override
        public override Connection onCreateOutgoingConnection(PhoneAccountHandle connectionManagerPhoneAccount, ConnectionRequest request)
        {
            //Toast.makeText(getApplicationContext(), "onCreateOutgoingConnection called", Toast.LENGTH_SHORT).show();

            Connection outgoingCallConnection = createConnection(request);
            outgoingCallConnection.SetDialing();

            return outgoingCallConnection;
        }

        private Connection createConnection(ConnectionRequest request)
        {
            mConnection = new Connection(){

            //@Override
            public override void onStateChanged(int state)
            {
                super.onStateChanged(state);
            }

            //@Override
            public override void onDisconnect()
            {
                super.onDisconnect();
                mConnection.setDisconnected(new DisconnectCause(DisconnectCause.CANCELED));
                mConnectionsAvailableForConference.clear();
                mConnection.destroy();
            }

            //@Override
            public override void onSeparate()
            {
                super.onSeparate();
            }

            //@Override
            public override void onAbort()
            {
                super.onAbort();
                mConnection.setDisconnected(new DisconnectCause(DisconnectCause.CANCELED));
                mConnection.destroy();
            }

            //@Override
            public override void onHold()
            {
                super.onHold();
            }

            //@Override
            public override void onAnswer()
            {
                super.onAnswer();
                mConnection.setActive();
            }

            //@Override
            public override void onReject()
            {
                super.onReject();
                mConnection.setDisconnected(new DisconnectCause(DisconnectCause.CANCELED));
                mConnection.destroy();

            }
        };
        mConnection.setAddress(request.getAddress(), TelecomManager.PRESENTATION_ALLOWED);
        mConnection.setExtras(request.getExtras());
        return mConnection;
}




}
}