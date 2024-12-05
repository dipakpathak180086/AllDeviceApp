package md537a29ad0b915ad364cb06524aab98b8d;


public class TagMappingActivity_UIHand
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
		mono.android.Runtime.register ("SatoScanningApp.TagMappingActivity+UIHand, SatoOnlineApp", TagMappingActivity_UIHand.class, __md_methods);
	}


	public TagMappingActivity_UIHand ()
	{
		super ();
		if (getClass () == TagMappingActivity_UIHand.class)
			mono.android.TypeManager.Activate ("SatoScanningApp.TagMappingActivity+UIHand, SatoOnlineApp", "", this, new java.lang.Object[] {  });
	}


	public TagMappingActivity_UIHand (android.os.Looper p0)
	{
		super (p0);
		if (getClass () == TagMappingActivity_UIHand.class)
			mono.android.TypeManager.Activate ("SatoScanningApp.TagMappingActivity+UIHand, SatoOnlineApp", "Android.OS.Looper, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	public TagMappingActivity_UIHand (md537a29ad0b915ad364cb06524aab98b8d.TagMappingActivity p0)
	{
		super ();
		if (getClass () == TagMappingActivity_UIHand.class)
			mono.android.TypeManager.Activate ("SatoScanningApp.TagMappingActivity+UIHand, SatoOnlineApp", "SatoScanningApp.TagMappingActivity, SatoOnlineApp", this, new java.lang.Object[] { p0 });
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
