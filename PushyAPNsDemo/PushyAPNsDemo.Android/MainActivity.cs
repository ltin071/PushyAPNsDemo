using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ME.Pushy.Sdk;
using System.Threading.Tasks;
using Android.Util;
using Android;
using Android.Support.V4.Content;
using Android.Support.V4.App;

namespace PushyAPNsDemo.Droid
{
    [Activity(Label = "PushyAPNsDemo", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            Pushy.Listen(this);
            // Check whether the user has granted us the READ/WRITE_EXTERNAL_STORAGE permissions
            if (ContextCompat.CheckSelfPermission(Application.Context, Manifest.Permission.WriteExternalStorage) != Permission.Granted)
            {
                // Request both READ_EXTERNAL_STORAGE and WRITE_EXTERNAL_STORAGE so that the
                // Pushy SDK will be able to persist the device token in the external storage
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage }, 0);
            }

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            LoadApplication(new App());
            RegPushy();
        }
        private async void RegPushy()
        {
                await RegisterForPushNotifications();
            
        }
        private async Task RegisterForPushNotifications()
        {
            // Execute Pushy.Register() in a background thread
            await Task.Run(() =>
            {
                try
                {
                    // Assign a unique token to this device
                    string deviceToken = Pushy.Register(Application.Context);
                    Pushy.Subscribe("news", Application.Context);

                    // Log it for debugging purposes
                    Log.Debug("MyApp", "Pushy device token: " + deviceToken);

                    // Send the token to your backend server via an HTTP GET request
                    //new URL("https://{YOUR_API_HOSTNAME}/register/device?token=" + deviceToken).OpenConnection();
                }
                catch (Exception exc)
                {
                    // Log error to console
                    Log.Error("MyApp", exc.Message, exc);
                    return;
                }

                // Succeeded, optionally do something to alert the user
            });
        }

    }
}