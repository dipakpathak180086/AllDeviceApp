using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using AndroidApp = Android.App.Application;
using Android;
using System.Threading;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace ThreePointCheck_App.Droid
{
    [Activity(Label = "ThreePointCheck_App", Icon = "@drawable/Qrcode", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        string apkFile = "";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //java.text.DateFormat dateFormat = android.text.format.DateFormat.getDateFormat(getApplicationContext());
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            CheckAppPermissionsAsync();
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            StrictMode.VmPolicy.Builder builder = new StrictMode.VmPolicy.Builder();
            StrictMode.SetVmPolicy(builder.Build());
            //Task.Run(() =>
            //{
            //    try
            //    {

            //        CheckForUpdate();
            //    }
            //    catch (Exception ex)
            //    {
            //        Toast.MakeText(this, ex.Message.ToString(), ToastLength.Long).Show();
            //    }
            //});

            LoadApplication(new App());

            CommonClass.CommonVariable.Version = PackageManager.GetPackageInfo(PackageName, PackageInfoFlags.Activities).VersionCode.ToString();

        }
        private void CheckAppPermissionsAsync()
        {
            if ((int)Build.VERSION.SdkInt < 23)
            {
                return;
            }
            else
            {
                if (PackageManager.CheckPermission(Manifest.Permission.ReadExternalStorage, PackageName) != Permission.Granted
                    && PackageManager.CheckPermission(Manifest.Permission.WriteExternalStorage, PackageName) != Permission.Granted)
                {
                    var permissions = new string[] { Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage };
                    RequestPermissions(permissions, 1);
                    Thread.Sleep(3000);
                    //               var intent = new Intent(Android.Provider.Settings.ActionApplicationDetailsSettings,
                    //Android.Net.Uri.Parse("package:" + Forms.Context.PackageName));
                    //Forms.Context.StartActivity(intent);
                }

            }
        }
        private void CheckForUpdate()
        {

            // apkFile = Android.OS.Environment.ExternalStorageDirectory + "/Denso_3Point/ThreePointCheck_App.apk";

//#if DEBUG
             apkFile = GetFTPFile("ftp://172.28.41.246/SATO/DENSO_ORM.DENSO_ORM.apk", "VISITOR", "123456");
//#else
            apkFile = GetFTPFile("ftp://10.91.86.22//ThreePointCheck_App.apk", "sar.manikandan.m", "Sato@123");

            //#endif
            var pckInfo = PackageManager.GetPackageArchiveInfo(apkFile, PackageInfoFlags.Activities);
            int CurVCode = PackageManager.GetPackageInfo(PackageName, PackageInfoFlags.Activities).VersionCode;
            //PackageManager.GetPackageInfo()
            int newVCode = pckInfo.VersionCode;
            if (newVCode != CurVCode)
            {
                AlertDialog.Builder dlg = new AlertDialog.Builder(this);
                dlg.SetMessage("New update found.Do you want to update?");
                dlg.SetPositiveButton("Yes", UpdateApplication);
                dlg.SetNegativeButton("No", CloseApp);
                RunOnUiThread(() => { dlg.Show(); });

            }
        }

        private void CloseApp(object sender, DialogClickEventArgs e)
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
        private string GetFTPFile(string path, string Username, string password)
        {

            string filePath = Android.OS.Environment.ExternalStorageDirectory + "/Denso_3Point/ThreePointCheck_App.apk";
            FtpWebRequest req = (FtpWebRequest)WebRequest.Create(path);
            req.Method = WebRequestMethods.Ftp.DownloadFile;
            req.UseBinary = true;
            req.UsePassive = false;
            req.KeepAlive = false;
            req.Timeout = System.Threading.Timeout.Infinite;
            req.AuthenticationLevel = System.Net.Security.AuthenticationLevel.None;
            req.Credentials = new NetworkCredential(Username, password);
            using (var ftpStream = req.GetResponse().GetResponseStream())
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    ftpStream.CopyTo(fileStream);
                }
            }

            return filePath;
        }
        private void UpdateApplication(object sender, DialogClickEventArgs e)
        {

            //Intent intent = new Intent(Intent.ActionDelete);
            //intent.SetData(Android.Net.Uri.FromFile(. package:Com.android.DENSO_ORM.DENSO_ORM));
            //StartActivity(intent);
            //Uri packageURI = Uri("package:Com.android.DENSO_ORM.DENSO_ORM");
            //Intent uninstallIntent = new Intent(Intent.ACTION_DELETE, packageURI);
            //startActivity(uninstallIntent);

            Intent intent = new Intent(Intent.ActionInstallPackage);
            intent.SetDataAndType(Android.Net.Uri.FromFile(new Java.IO.File(apkFile)), "application/vnd.android.package-archive");
            //intent.SetFlags(ActivityFlags.flag)
            intent.SetFlags(ActivityFlags.NewTask);

            StartActivity(intent);

            //StartActivity(Intent.CreateChooser(intent, "ORM"));




            //Android.OS.Process.KillProcess(Android.OS.Process.MyPid());

            //Intent promptInstall = new Intent(Intent.ActionView).SetDataAndType(Android.Net.Uri.FromFile(new Java.IO.File(apkFile)), "application/vnd.android.package-archive");
            ////Intent promptInstall = new Intent(Intent.ActionView).SetData(Android.Net.Uri.Parse("/sdcard/Download/Inspections.Inspections-Signed.apk")).SetType("application/vnd.android.package-archive");
            //promptInstall.AddFlags(ActivityFlags.NewTask);
            //StartActivity(promptInstall);




        }
        protected override void OnPause()
        {
            //Android.Content.Context context;
            //Intent i = new Intent(context, typeof(MainActivity));
            //i.AddFlags(ActivityFlags.NewTask);
            //context.StartActivity(i);
            base.OnPause();
            //Intent intent = new Intent(AndroidApp.Context, typeof(MainActivity));
            //intent.AddFlags(ActivityFlags.NewTask);
            //AndroidApp.Context.StartActivity(intent);
        }
        protected override void OnStart()
        {
            base.OnStart();
        }
        protected override void OnStop()
        {
            //Intent i = new Intent(context, typeof(MainActivity));
            //i.AddFlags(ActivityFlags.NewTask);
            //context.StartActivity(i);
            base.OnStop();

            //Intent intent = new Intent(AndroidApp.Context, typeof(MainActivity));
            //intent.AddFlags(ActivityFlags.NewTask);
            //AndroidApp.Context.StartActivity(intent);
        }
    }
}