using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Com.Rdbe.BarcodeHelper;
using Newtonsoft.Json.Linq;
using System;
using static Android.Graphics.ColorSpace;

namespace AppTest
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity , IIbarcodeEvent
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);


            BarcodeHelper myBarcodeHelper = new BarcodeHelper();
            myBarcodeHelper.SetBarcodeEvnet(this);

            Button btn_connectBarcode = FindViewById<Button>(Resource.Id.btn_connectBarcode);
            btn_connectBarcode.Click += (s, e) =>
            {
                var context = Android.App.Application.Context;
                var res = myBarcodeHelper.ConnectScanner(this);
                Console.WriteLine("debug == " + res);
            };

            Button btn_trigerBarcode = FindViewById<Button>(Resource.Id.btn_trigerBarcode);
            btn_trigerBarcode.Click += (s, e) =>
            {
                var res = myBarcodeHelper.TrigerScan();
                Console.WriteLine("debug == " + res);
            };

            Button btn_closeBarcode = FindViewById<Button>(Resource.Id.btn_closeBarcode);
            btn_closeBarcode.Click += (s, e) =>
            {
                myBarcodeHelper.CloseScanner();
            };

        }


        public void OnBarcodeStr(string barcodestr)
        {
            Console.WriteLine("barcoed data == " + barcodestr);
            //Toast.MakeText(this, $"barcoed data = " + barcodestr, ToastLength.Short).Show();
            this.RunOnUiThread(() => {
                Toast.MakeText(this, $"barcoed data = " + barcodestr, ToastLength.Short).Show();
            });
        
        }
    }
}