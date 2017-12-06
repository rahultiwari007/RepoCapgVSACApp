using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.AppCenter.Push;
using Android.Content;
using Android.Media;
using Android.Support.V4.App;
using Android.Graphics;

namespace CapgVSACApp.Droid
{
    [Activity(Label = "CapgVSACApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            Push.PushNotificationReceived += (sender, e) =>
            {

                // Add the notification message and title to the message
                var summary = $"Push notification received:" +
                                    $"\n\tNotification title: {e.Title}" +
                                    $"\n\tMessage: {e.Message}";

                // If there is custom data associated with the notification,
                // print the entries
                if (e.CustomData != null)
                {
                    summary += "\n\tCustom data:\n";
                    foreach (var key in e.CustomData.Keys)
                    {
                        summary += $"\t\t{key} : {e.CustomData[key]}\n";
                    }
                }
                sendNotification(e.Message, e.Title);
                // Send the notification summary to debug output
                System.Diagnostics.Debug.WriteLine(summary);
            };
            LoadApplication(new App());
        }
        private void sendNotification(String title, String messageBody)
        {
            Intent[] intents = new Intent[1];
            Intent intent = new Intent(this, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);
            intent.PutExtra("IncidentNo", title);
            intent.PutExtra("ShortDesc", messageBody);
            intent.PutExtra("Description", messageBody);
            intents[0] = intent;
            PendingIntent pendingIntent = PendingIntent.GetActivities(this, 0, intents, PendingIntentFlags.OneShot);
           Android.Net.Uri defaultSoundUri = RingtoneManager.GetDefaultUri(RingtoneType.Notification);
            NotificationCompat.Builder notificationbuilder =
            new NotificationCompat.Builder(this)
                    .SetSmallIcon(Resource.Drawable.icon)
                    .SetContentTitle(title)
                    .SetContentText(messageBody)
                    .SetAutoCancel(true)
                    .SetSound(defaultSoundUri)
                    .SetContentIntent(pendingIntent)
            .SetLargeIcon(BitmapFactory.DecodeResource(Resources, Resource.Drawable.icon)); ;

            NotificationManager notificationManager = (NotificationManager)this.GetSystemService(Context.NotificationService);
            notificationManager.Notify(0, notificationbuilder.Build());
        }
        protected override void OnNewIntent(Android.Content.Intent intent)
        {

            base.OnNewIntent(intent);
            Push.CheckLaunchedFromNotification(this, intent);
        }
    }
}

