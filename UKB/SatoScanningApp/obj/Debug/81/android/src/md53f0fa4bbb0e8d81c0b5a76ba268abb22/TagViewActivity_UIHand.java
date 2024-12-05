package md53f0fa4bbb0e8d81c0b5a76ba268abb22;


public class TagViewActivity_UIHand
	extends android.os.Handler
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_handleMessage:(Landroid/os/Message;)V:GetHandleMessage_Landroid_os_Message_Handler\n" +
			"";
		mono.android.Runtime.register ("SatoScanningApp.ActivityClass.TagViewActivity+UIHand, SatoOnlineApp", TagViewActivity_UIHand.class, __md_methods);
	}


	public TagViewActivity_UIHand ()
	{
		super ();
		if (getClass () == TagViewActivity_UIHand.class)
			mono.android.TypeManager.Activate ("SatoScanningApp.ActivityClass.TagViewActivity+UIHand, SatoOnlineApp", "", this, new java.lang.Object[] {  });
	}


	public TagViewActivity_UIHand (android.os.Looper p0)
	{
		super (p0);
		if (getClass () == TagViewActivity_UIHand.class)
			mono.android.TypeManager.Activate ("SatoScanningApp.ActivityClass.TagViewActivity+UIHand, SatoOnlineApp", "Android.OS.Looper, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	public TagViewActivity_UIHand (md53f0fa4bbb0e8d81c0b5a76ba268abb22.TagViewActivity p0)
	{
		super ();
		if (getClass () == TagViewActivity_UIHand.class)
			mono.android.TypeManager.Activate ("SatoScanningApp.ActivityClass.TagViewActivity+UIHand, SatoOnlineApp", "SatoScanningApp.ActivityClass.TagViewActivity, SatoOnlineApp", this, new java.lang.Object[] { p0 });
	}


	public void handleMessage (android.os.Message p0)
	{
		n_handleMessage (p0);
	}

	private native void n_handleMessage (android.os.Message p0);

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
