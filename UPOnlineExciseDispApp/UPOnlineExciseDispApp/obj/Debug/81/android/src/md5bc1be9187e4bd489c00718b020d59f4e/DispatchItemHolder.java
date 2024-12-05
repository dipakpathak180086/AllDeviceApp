package md5bc1be9187e4bd489c00718b020d59f4e;


public class DispatchItemHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("UPOnlineExciseDispApp.Adapter.DispatchItemHolder, UPOnlineExciseDispApp", DispatchItemHolder.class, __md_methods);
	}


	public DispatchItemHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == DispatchItemHolder.class)
			mono.android.TypeManager.Activate ("UPOnlineExciseDispApp.Adapter.DispatchItemHolder, UPOnlineExciseDispApp", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
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
