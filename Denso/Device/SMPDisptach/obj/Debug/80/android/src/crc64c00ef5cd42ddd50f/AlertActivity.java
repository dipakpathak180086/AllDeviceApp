package crc64c00ef5cd42ddd50f;


public class AlertActivity
	extends android.app.Dialog
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_dismiss:()V:GetDismissHandler\n" +
			"n_onBackPressed:()V:GetOnBackPressedHandler\n" +
			"";
		mono.android.Runtime.register ("SMPDisptach.AlertActivity, SMPDisptach", AlertActivity.class, __md_methods);
	}


	public AlertActivity (android.content.Context p0)
	{
		super (p0);
		if (getClass () == AlertActivity.class) {
			mono.android.TypeManager.Activate ("SMPDisptach.AlertActivity, SMPDisptach", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void dismiss ()
	{
		n_dismiss ();
	}

	private native void n_dismiss ();


	public void onBackPressed ()
	{
		n_onBackPressed ();
	}

	private native void n_onBackPressed ();

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}