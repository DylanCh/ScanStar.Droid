using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Util;
using System.Text;
using System.Threading;
//using Java.Lang;
using Android.Content;
using Android.Net;
using Android.Webkit;


namespace ScanStar.Droid
{
    [Activity(Label = "ScanStar.Droid", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        
        const int RequestCameraPermissionID = 1001;
		SurfaceView cameraView;
		TextView textView;
        Button button;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            button = FindViewById<Button>(Resource.Id.myButton);
            cameraView = FindViewById<SurfaceView>(Resource.Id.textView);
            textView = FindViewById<TextView>(Resource.Id.textView);


            button.Click += delegate { 
                selectIntentDialog();
            };
        } // end oncreate



		// Change objects to TextBlocks
		void HandleReceivedDetection(string url, char type)
		{
            if (type.Equals('p'))
            {
                button.Click += delegate
                {
                    Intent dial = new Intent(Intent.ActionCall, Uri.Parse(url));
                    StartActivity(dial);
                };
            }
            else if (type.Equals('w')){
                button.Click += delegate {
                    WebView webView = new WebView(Application.Context);
                    //webView.SetWebViewClient(new WebViewClient());
                    webView.LoadUrl(url);
                };
            }
	
		} // end HandleReceivedDetection

        void selectIntentDialog(){
            char type;
            LayoutInflater inflater = (LayoutInflater)this.GetSystemService(Context.LayoutInflaterService);
            View pop = inflater.Inflate(Resource.Layout.SimpleDropDownLayout, null);
            PopupWindow popupWindow = new PopupWindow(pop);
            ListView listView = new ListView(Application.Context);
			var adapter = new ArrayAdapter<string>(this,
												   //FindViewById(Resource.Layout.SimpleDropDownLayout),
                                                   Resource.Layout.Main,
                                                   new string[] {"Call", "Email","Send SMS" });

            listView.Adapter = adapter;
            popupWindow.ShowAsDropDown(this.FindViewById(Resource.Layout.Main),0,0);

			//var pop = new XLab.Forms.Controls.PopupLayout();
			
            //RunOnUiThread(()=>{
                
            //});
		}

        //class Runnable :IRunnable{
        //    public override void Run(){
        //        SparseArray<object> items = null; //= detections.getDetectedItems();
        //        if (items.Size() != 0)
        //        {
        //            string str;
        //            textView.Post(); // end post
        //            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
        //            for (int i = 0; i < items.Size(); ++i)
        //            {
        //            }
        //        }
        //    }
        //}

    }


}

