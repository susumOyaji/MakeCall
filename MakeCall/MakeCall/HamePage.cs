using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;


namespace MakeCall
{
    public class HamePage:ContentPage
    {
        public HamePage()
        {
            Entry numEntry = new Entry
            {
                Placeholder = "Contact numger",
                Text = "",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            Button call_btn = new Button
            {
                BackgroundColor = Color.FromRgb(102, 2.4, 102),
                Text = "Call",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    numEntry,
                    call_btn
                }

            };

            call_btn.Clicked += (sender, args) =>
            {
                try
                {
                    if(numEntry.Text == "")
                    {
                        DisplayAlert("Alert", "Specify the number to start the call.", "OK");
                    }
                    else
                    {
                        DependencyService.Get<IPhoneCall>().MakeQuickCall(numEntry.Text.ToString());
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }

            };


        }


    }

}
