package md537a29ad0b915ad364cb06524aab98b8d;


public class DirectDispatchActivity_UIHand
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
		mono.android.Runtime.register ("SatoScanningApp.DirectDispatchActivity+UIHand, SatoOnlineApp", DirectDispatchActivity_UIHand.class, __md_methods);
	}


	public DirectDispatchActivity_UIHand ()
	{
		super ();
		if (getClass () == DirectDispatchActivity_UIHand.class)
			mono.android.TypeManager.Activate ("SatoScanningApp.DirectDispatchActivity+UIHand, SatoOnlineApp", "", this, new java.lang.Object[] {  });
	}


	public DirectDispatchActivity_UIHand (android.os.Looper p0)
	{
		super (p0);
		if (getClass () == DirectDispatchActivity_UIHand.class)
			mono.android.TypeManager.Activate ("SatoScanningApp.DirectDispatchActivity+UIHand, SatoOnlineApp", "Android.OS.Looper, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	public DirectDispatchActivity_UIHand (md537a29ad0b915ad364cb06524aab98b8d.DirectDispatchActivity p0)
	{
		super ();
		if (getClass () == DirectDispatchActivity_UIHand.class)
			mono.android.TypeManager.Activate ("SatoScanningApp.DirectDispatchActivity+UIHand, SatoOnlineApp", "SatoScanningApp.DirectDispatchActivity, SatoOnlineApp", this, new java.lang.Object[] { p0 });
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
