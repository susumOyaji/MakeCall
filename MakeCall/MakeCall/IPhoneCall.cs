using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


using Xamarin.Forms;

namespace MakeCall
{
        public interface IPhoneCall
        {
            string MakeQuickCall(string PhoneNumber);
        }
    
}