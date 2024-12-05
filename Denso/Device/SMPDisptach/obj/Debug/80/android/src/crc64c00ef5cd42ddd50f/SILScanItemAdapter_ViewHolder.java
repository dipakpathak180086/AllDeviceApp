package crc64c00ef5cd42ddd50f;


public class SILScanItemAdapter_ViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("SMPDisptach.SILScanItemAdapter+ViewHolder, SMPDisptach", SILScanItemAdapter_ViewHolder.class, __md_methods);
	}


	public SILScanItemAdapter_ViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == SILScanItemAdapter_ViewHolder.class) {
			mono.android.TypeManager.Activate ("SMPDisptach.SILScanItemAdapter+ViewHolder, SMPDisptach", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
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
