
using Android.App;
using Android.Content;
using Android.Views.InputMethods;
using SingleLine_App.CustomControls;
using SingleLine_App.Droid;
// Path to ScanEditor class

using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ScanEditor), typeof(ScanEditorRenderer))]
namespace SingleLine_App.Droid
{
   //
    class ScanEditorRenderer : EditorRenderer
    {
        public ScanEditorRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                ((ScanEditor)e.NewElement).PropertyChanging += OnPropertyChanging;
            }

            if (e.OldElement != null)
            {
                ((ScanEditor)e.OldElement).PropertyChanging -= OnPropertyChanging;
            }
            // Disable the Keyboard on Focus
            Control.ShowSoftInputOnFocus = false;
        }

        private void OnPropertyChanging(object sender, PropertyChangingEventArgs propertyChangingEventArgs)
        {
            // Check if the view is about to get Focus
            if (propertyChangingEventArgs.PropertyName == VisualElement.IsFocusedProperty.PropertyName)
            {
                try
                {
                    // incase if the focus was moved from another Entry
                    // Forcefully dismiss the Keyboard 
                    InputMethodManager imm = (InputMethodManager)Context.GetSystemService(Context.InputMethodService);
                    imm.HideSoftInputFromWindow(Control.WindowToken, 0);
                }
                catch (Exception ex)
                {
                    _ = ex;
                }
            }
        }

    }
}