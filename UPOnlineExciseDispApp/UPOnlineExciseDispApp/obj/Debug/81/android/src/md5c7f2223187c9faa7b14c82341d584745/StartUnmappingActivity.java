package md5c7f2223187c9faa7b14c82341d584745;


public class StartUnmappingActivity
	extends android.support.v7.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onBackPressed:()V:GetOnBackPressedHandler\n" +
			"";
		mono.android.Runtime.register ("UPOnlineExciseDispApp.ActivityClass.StartUnmappingActivity, UPOnlineExciseDispApp", StartUnmappingActivity.class, __md_methods);
	}


	public StartUnmappingActivity ()
	{
		super ();
		if (getClass () == StartUnmappingActivity.class)
			mono.android.TypeManager.Activate ("UPOnlineExciseDispApp.ActivityClass.StartUnmappingActivity, UPOnlineExciseDispApp", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


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
