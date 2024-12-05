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
    [Activity(Label = "PopupActivity")]
    public class PopupActivity : Dialog
    {
        clsGlobal clsGLB;
        EditText txtBarcode;
        Activity activity;
        MediaPlayer mediaPlayerSound;
        Vibrator vibrator;
        bool _bMatched;
        bool scanningComplete = false;
        public PopupActivity(Activity activity) : base(activity)
        {
            clsGLB = new clsGlobal();
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
                SetContentView(Resource.Layout.activity_ProcessType);
                clsGlobal.mDNHAKanbanString = "";
                clsGlobal.mSupplierKanbanString = "";
                clsGlobal.mCustomerKanbanString = "";
                Spinner cmbProcess1 = FindViewById<Spinner>(Resource.Id.spinnerProcess1);
                Spinner cmbProcess2 = FindViewById<Spinner>(Resource.Id.spinnerProcess2);
                TextView lblProcess1 = FindViewById<TextView>(Resource.Id.lblProcess1);
                TextView lblProceess2 = FindViewById<TextView>(Resource.Id.lblProcess2);
                Button btnCancel = FindViewById<Button>(Resource.Id.btnCancel);
                btnCancel.Click += (e, a) =>
                {
                    this.Hide();
                };
                Button btnSet = FindViewById<Button>(Resource.Id.btnSet);
                btnSet.Click += (e, a) =>
                {
                    if (clsGlobal.mSILType == "2POINTS")
                    {
                        if (cmbProcess1.SelectedItemPosition == 0)
                        {
                            clsGLB.showToastNGMessage("Select Process 1", this.Context);
                            SoundForNG();
                            return;
                        }
                        if (cmbProcess1.SelectedItem.Equals("DNHA"))
                        {
                            clsGlobal.mDNHAKanbanString = "DNHA";
                        }
                        if (cmbProcess1.SelectedItem.Equals("CUSTOMER"))
                        {
                            clsGlobal.mCustomerKanbanString = "CUSTOMER";
                        }
                        if (cmbProcess1.SelectedItem.Equals("SUPPLIER"))
                        {
                            clsGlobal.mSupplierKanbanString = "SUPPLIER";
                        }
                    }
                    if (clsGlobal.mSILType == "3POINTS")
                    {
                        if (cmbProcess1.SelectedItemPosition == 0)
                        {
                            clsGLB.showToastNGMessage("Select Process 1", this.Context);
                            SoundForNG();
                            return;
                        }
                        if (cmbProcess2.SelectedItemPosition == 0)
                        {
                            clsGLB.showToastNGMessage("Select Process 2", this.Context);
                            SoundForNG();
                            return;
                        }
                        if (cmbProcess1.SelectedItem.Equals(cmbProcess2.SelectedItem))
                        {
                            clsGLB.showToastNGMessage("Select Process 1 & Process 2 Item can't be same.", this.Context);
                            SoundForNG();
                            return;
                        }
                        if (!cmbProcess1.SelectedItem.Equals("SUPPLIER") && !cmbProcess1.SelectedItem.Equals("DNHA"))
                        {
                            clsGLB.showToastNGMessage("Please select either SUPPLIER or DNHA.", this.Context);
                            SoundForNG();
                            return;
                        }
                        if (!cmbProcess2.SelectedItem.Equals("CUSTOMER"))
                        {
                            clsGLB.showToastNGMessage("Select Process 2 Only Customer can be Selected.", this.Context);
                            SoundForNG();
                            return;
                        }
                        if (cmbProcess1.SelectedItem.Equals("DNHA"))
                        {
                            clsGlobal.mDNHAKanbanString = "DNHA";
                        }
                        if (cmbProcess1.SelectedItem.Equals("CUSTOMER"))
                        {
                            clsGlobal.mCustomerKanbanString = "CUSTOMER";
                        }
                        if (cmbProcess1.SelectedItem.Equals("SUPPLIER"))
                        {
                            clsGlobal.mSupplierKanbanString = "SUPPLIER";
                        }
                        if (cmbProcess2.SelectedItem.Equals("DNHA"))
                        {
                            clsGlobal.mDNHAKanbanString = "DNHA";
                        }
                        if (cmbProcess2.SelectedItem.Equals("CUSTOMER"))
                        {
                            clsGlobal.mCustomerKanbanString = "CUSTOMER";
                        }
                        if (cmbProcess2.SelectedItem.Equals("SUPPLIER"))
                        {
                            clsGlobal.mSupplierKanbanString = "SUPPLIER";
                        }
                       
                    }
                    Dismiss();
                };

                List<string> listProcess1 = new List<string>();
                listProcess1.Add("--SELECT--");
                listProcess1.Add("DNHA");
                listProcess1.Add("CUSTOMER");
                listProcess1.Add("SUPPLIER");

                List<string> listProcess2 = new List<string>();
                listProcess2.Add("--SELECT--");
                listProcess2.Add("DNHA");
                listProcess2.Add("CUSTOMER");
                

                if (clsGlobal.mSILType == "2POINTS")
                {
                    lblProcess1.Visibility = ViewStates.Visible;
                    lblProceess2.Visibility = ViewStates.Gone;
                    cmbProcess1.Visibility = ViewStates.Visible;
                    cmbProcess2.Visibility = ViewStates.Gone;

                }
                else
                {
                    lblProcess1.Visibility = ViewStates.Visible;
                    lblProceess2.Visibility = ViewStates.Visible;
                    cmbProcess1.Visibility = ViewStates.Visible;
                    cmbProcess2.Visibility = ViewStates.Visible;

                }
                ArrayAdapter<string> arrayAdapter1 =   new ArrayAdapter<string>(this.Context, Resource.Layout.Spinner, listProcess1);
                cmbProcess1.Adapter = arrayAdapter1;
                cmbProcess1.SetSelection(0);
                ArrayAdapter<string> arrayAdapter2 = new ArrayAdapter<string>(this.Context, Resource.Layout.Spinner, listProcess2);
                cmbProcess2.Adapter = arrayAdapter2;
                cmbProcess2.SetSelection(0);
                //vibrator = this.activity.GetSystemService(this VibratorService) as Vibrator;

            }
            catch (Exception ex)
            {
                clsGLB.ShowMessage(ex.Message, activity, MessageTitle.ERROR);
            }

            // Create your application here
        }

        private void TxtBarcode_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.Event.Action == KeyEventActions.Down)
                {
                    if (e.KeyCode == Keycode.Enter)
                    {
                        if (!string.IsNullOrEmpty(txtBarcode.Text))
                        {
                            if (txtBarcode.Text.Trim() == "IZ3G3VDPRTN+NETEZEQROQ==")
                            {
                                _bMatched = true;
                                Dismiss();
                            }
                            else
                                clsGLB.ShowMessage("Invalid Barcode", activity, MessageTitle.ERROR);
                        }
                        else
                            clsGLB.ShowMessage("Scan Admin QR Code", activity, MessageTitle.ERROR);
                    }
                    else
                        e.Handled = false;
                }
            }
            catch (Exception ex1)
            {
                clsGLB.ShowMessage(ex1.Message, activity, MessageTitle.ERROR);
            }
            finally
            {
                txtBarcode.Text = string.Empty;
                txtBarcode.RequestFocus();
            }
        }

        public event EventHandler<DialogEventArgs> DialogClosed;
        public override void Dismiss()
        {
            base.Dismiss();
            if (DialogClosed != null)
                DialogClosed(this, new DialogEventArgs { bMatch = _bMatched });
        }

        public override void OnBackPressed() { }
    }
    public class DialogEventArgs
    {
        //you can put other properties here that may be relevant to check from activity
        //for example: if a cancel button was clicked, other text values, etc.

        public bool bMatch { get; set; }
    }
}