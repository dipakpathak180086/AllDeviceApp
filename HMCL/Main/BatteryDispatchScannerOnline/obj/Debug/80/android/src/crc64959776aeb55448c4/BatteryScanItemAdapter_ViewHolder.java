package crc64959776aeb55448c4;


public class BatteryScanItemAdapter_ViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("BatteryDispatchScannerOnline.BatteryScanItemAdapter+ViewHolder, BatteryDispatchScannerOnline", BatteryScanItemAdapter_ViewHolder.class, __md_methods);
	}


	public BatteryScanItemAdapter_ViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == BatteryScanItemAdapter_ViewHolder.class) {
			mono.android.TypeManager.Activate ("BatteryDispatchScannerOnline.BatteryScanItemAdapter+ViewHolder, BatteryDispatchScannerOnline", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}

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
