using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using SavingsPigs.Mobile.Droid;
using SavingsPigs.Mobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly:Dependency(typeof(NotificationHelper))]
namespace SavingsPigs.Mobile.Droid
{
    public class NotificationHelper : INotification
    {
        private Context mContext;
        private NotificationManager mNotificationManager;
        private NotificationCompat.Builder mBuilder;
        public static string NOTIFICATION_CHANNEL_ID = "10203";

        public NotificationHelper()
        {
            mContext = global::Android.App.Application.Context;
        }

        public async Task CreateNotification(string title, string message)
        {
            try
            {
                mBuilder = new NotificationCompat.Builder(mContext);
                mBuilder.SetContentTitle(title)
                        .SetContentText(message)
                        .SetSmallIcon(Resource.Mipmap.icon)
                        .SetChannelId(NOTIFICATION_CHANNEL_ID)
                        .SetAutoCancel(true)
                        .SetPriority((int)NotificationPriority.High)
                        .SetVisibility((int)NotificationVisibility.Public);

                mNotificationManager = mContext.GetSystemService(Context.NotificationService) as NotificationManager;

                if(global::Android.OS.Build.VERSION.SdkInt >= global::Android.OS.BuildVersionCodes.O)
                {
                    NotificationImportance importance = global::Android.App.NotificationImportance.High;

                    NotificationChannel notificationChannel = new NotificationChannel(NOTIFICATION_CHANNEL_ID, title, importance);
                    notificationChannel.EnableLights(true);
                    notificationChannel.EnableVibration(true);
                    notificationChannel.SetShowBadge(true);
                    notificationChannel.Importance = NotificationImportance.High;
                    notificationChannel.SetVibrationPattern(new long[] { 100, 200, 300, 400, 500, 400, 300, 200, 400 });

                    if(mNotificationManager != null)
                    {
                        mBuilder.SetChannelId(NOTIFICATION_CHANNEL_ID);
                        mNotificationManager.CreateNotificationChannel(notificationChannel); 
                    }
                    mNotificationManager.Notify(0, mBuilder.Build());
                }
            }
            catch (Exception)
            {

            }
        }
    }
}