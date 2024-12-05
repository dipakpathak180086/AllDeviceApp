package crc641d3fc8ac174c4028;


public class BatterySTOScanning
	extends android.app.Activity
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
		mono.android.Runtime.register ("BatteryDispatchScannerOnline.ActivityClass.BatterySTOScanning, BatteryDispatchScannerOnline", BatterySTOScanning.class, __md_methods);
	}


	public BatterySTOScanning ()
	{
		super ();
		if (getClass () == BatterySTOScanning.class) {
			mono.android.TypeManager.Activate ("BatteryDispatchScannerOnline.ActivityClass.BatterySTOScanning, BatteryDispatchScannerOnline", "", this, new java.lang.Object[] {  });
		}
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
