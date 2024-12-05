package md537a29ad0b915ad364cb06524aab98b8d;


public class ReceivingActivity_UIHand
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
		mono.android.Runtime.register ("SatoScanningApp.ReceivingActivity+UIHand, SatoOnlineApp", ReceivingActivity_UIHand.class, __md_methods);
	}


	public ReceivingActivity_UIHand ()
	{
		super ();
		if (getClass () == ReceivingActivity_UIHand.class)
			mono.android.TypeManager.Activate ("SatoScanningApp.ReceivingActivity+UIHand, SatoOnlineApp", "", this, new java.lang.Object[] {  });
	}


	public ReceivingActivity_UIHand (android.os.Looper p0)
	{
		super (p0);
		if (getClass () == ReceivingActivity_UIHand.class)
			mono.android.TypeManager.Activate ("SatoScanningApp.ReceivingActivity+UIHand, SatoOnlineApp", "Android.OS.Looper, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	public ReceivingActivity_UIHand (md537a29ad0b915ad364cb06524aab98b8d.ReceivingActivity p0)
	{
		super ();
		if (getClass () == ReceivingActivity_UIHand.class)
			mono.android.TypeManager.Activate ("SatoScanningApp.ReceivingActivity+UIHand, SatoOnlineApp", "SatoScanningApp.ReceivingActivity, SatoOnlineApp", this, new java.lang.Object[] { p0 });
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
