package md537a29ad0b915ad364cb06524aab98b8d;


public class ReceiveItemHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("SatoScanningApp.ReceiveItemHolder, SatoOnlineApp", ReceiveItemHolder.class, __md_methods);
	}


	public ReceiveItemHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == ReceiveItemHolder.class)
			mono.android.TypeManager.Activate ("SatoScanningApp.ReceiveItemHolder, SatoOnlineApp", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
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
