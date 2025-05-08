using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Support.V7.Widget;
using Android.Widget;
using Android.Media;
using System.Threading.Tasks;
using System.Threading;

namespace SMPDisptach
{
    [Activity(Label = "AlertActivity")]
    public class AlertActivity : Dialog
    {
        clsGlobal clsGlobal;
        EditText txtAlert;
        Activity activity;
        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;
        bool _bMatched;
        bool scanningComplete = false;
        public AlertActivity(Activity activity) : base(activity)
        {
            //clsGlobal = new clsGlobal();
            this.activity = activity;
           
        }
        private void StartPlayingSound(bool isSaved = false)
        {
            try
            {

                if (isSaved)
                {
                    mediaPlayerSound = MediaPlayer.Create(this.Context, Resource.Raw.SavedSound);
                }
                else
                {
                    StopPlayingSound();
                    mediaPlayerSound = MediaPlayer.Create(this.Context, Resource.Raw.Beep);
                }
                mediaPlayerSound.Start();
            }
            catch (Exception ex) { throw ex; }
        }
        private void StopPlayingSound()
        {
            try
            {
                if (mediaPlayerSound != null)
                {
                    mediaPlayerSound.Stop();
                    mediaPlayerSound.Release();
                    mediaPlayerSound = null;
                    scanningComplete = false;
                }
            }
            catch (Exception ex) { throw ex; }
        }
    
        private void SoundForNG()
        {
            try
            {
                Task.Run(() =>
                {
                    StartPlayingSound();
                    Thread.Sleep(3000);
                    StopPlayingSound();
                });

            }
            catch (Exception ex) { throw ex; }
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);
                RequestWindowFeature((int)WindowFeatures.NoTitle);
                SetContentView(Resource.Layout.activity_Alert);
                txtAlert = FindViewById<EditText>(Resource.Id.editEnterPassword);
                txtAlert.KeyPress += TxtAlert_KeyPress;
                TextView lblAlertMessage = FindViewById<TextView>(Resource.Id.lblAlertMessage);
                Button btnCancel = FindViewById<Button>(Resource.Id.btnCancel);
                btnCancel.Click += (e, a) =>
                {
                    this.Hide();
                };
                lblAlertMessage.Text = clsGlobal.mAlertMeassage;
                txtAlert.Focusable = true;
                txtAlert.RequestFocus();
                Button btnUnlock= FindViewById<Button>(Resource.Id.btnUnlock);
                btnUnlock.Click += (e, a) =>
                {
                    clsGlobal.ReadAlertPasswordMaster();
                    if (clsGlobal.mAlertPassword=="")
                    {
                        clsGlobal.showToastNGMessage("Password is not available,Try again!!!", this.Context);
                        SoundForNG();
                        return;
                    }
                    if (clsGlobal.mAlertPassword != txtAlert.Text.Trim())
                    {
                        clsGlobal.showToastNGMessage("Invalid Password,Try again!!!", this.Context);
                        SoundForNG();
                        return;
                    }
                       
                    clsGlobal.DeleteAlertMessage();
                    Dismiss();
                };

                
                //vibrator = this.activity.GetSystemService(this VibratorService) as Vibrator;

            }
            catch (Exception ex)
            {
                clsGlobal.ShowMessage(ex.Message, activity, MessageTitle.ERROR);
            }

            // Create your application here
        }

        private void TxtAlert_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {
                        clsGlobal.ReadAlertPasswordMaster();
                        if (clsGlobal.mAlertPassword != txtAlert.Text.Trim())
                        {
                            clsGlobal.showToastNGMessage("Invalid Password,Try again!!!", this.Context);
                            SoundForNG();
                            return;
                        }

                        clsGlobal.DeleteAlertMessage();
                        Dismiss();
                    }
                    else
                        e.Handled = false;
                }
            }
            catch (Exception ex)
            {
                clsGlobal.ShowMessage(ex.Message, activity, MessageTitle.ERROR);
            }
        }

        public override void Dismiss()
        {
            base.Dismiss();
        }

        public override void OnBackPressed() { }
    }
  
}