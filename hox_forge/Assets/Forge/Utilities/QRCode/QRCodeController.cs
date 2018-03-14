//
// Copyright (c) Autodesk, Inc. All rights reserved.
// 
// This computer source code and related instructions and comments are the
// unpublished confidential and proprietary information of Autodesk, Inc.
// and are protected under Federal copyright and state trade secret law.
// They may not be disclosed to, copied or used by any third party without
// the prior written consent of Autodesk, Inc.
//
using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using System.Collections.Generic;
using System.ComponentModel;
#if !UNITY_WSA && !COROUTINE
using System.Net;
#endif
using SimpleJSON;
#if DAQRI_SMART_HELMET
using DAQRI;
#endif


namespace Autodesk.Forge.ARKit {

	//	#if UNITY_EDITOR
	//	public class QRCodeController : MonoBehaviour {
	//	
	//		#region Fields
	//		protected ARKit.HuD HuDParent =null ;
	//		public GameObject HuD =null ;
	//		public GameObject ForgeLoader =null ;
	//		protected WebCamTexture _wct =null ;
	//
	//		#endregion
	//
	//		#region Unity APIs
	//		protected virtual void Start () {
	//			//HuDParent =HuD.transform.parent.gameObject.GetComponent<ARKit.HuD> () ;
	//		}
	//
	//		protected virtual void Update () {
	//			if ( !_wct.isPlaying )
	//				return ;
	//		
	//			Color32[] pixels =_wct.GetPixels32 () ;
	//
	//			//List<BarcodeFormat> codeFormats = new List<BarcodeFormat> () ;
	//			//codeFormats.Add(BarcodeFormat.QR_CODE) ;
	//			IBarcodeReader reader =new BarcodeReader () /*{
	//				AutoRotate =true,
	//				TryInverted =true,
	//				Options ={
	//					PossibleFormats =codeFormats,
	//					TryHarder =true,
	//					ReturnCodabarStartEnd =true,
	//					PureBarcode =false
	//				}
	//			}*/ ;
	//			var result =reader.Decode (pixels, _wct.width, _wct.height) ;
	//			Debug.Log (result) ;
	//			//if ( result != null ) {
	//				_wct.Stop () ;
	//				//if ( result.BarcodeFormat.ToString () == "QR_CODE" )
	//				//	UnityEngine.Debug.Log (result.Text) ;
	//				//GameObject root =ForgeSceneInit.InitRoot () ;
	//
	//			GameObject root =new GameObject (ForgeConstants.ROOT) ;
	//			root.layer =LayerMask.NameToLayer (ForgeConstants.INTERACTIBLE) ;
	//
	//				root.SetActive (false) ;
	//				ForgeLoader loader =root.AddComponent<ForgeLoader> () ;
	//				loader.URN =ForgeLoaderConstants._URN ;
	//				loader.BEARER =ForgeLoaderConstants._BEARER ;
	//				loader.SCENEID =ForgeLoaderConstants._SCENEID ;
	//			//	loader.progressBar =_progressBar ;
	//				root.SetActive (true) ;
	//
	//				gameObject.SetActive (false) ;
	//			//}
	//		}
	//
	//		protected virtual void OnEnable () {
	//			if ( HuD ) {
	//				// GetComponentInParent works only if active.
	//				//ARKit.HuD hud =HuD.transform.parent.gameObject.GetComponent<ARKit.HuD> () ;
	//				HuDParent =HuD.transform.parent.gameObject.GetComponent<ARKit.HuD> () ;
	//				HuDParent.ActivatePanel (HuD) ;
	//			}
	//			InitCamera (GetComponent<Renderer> ()) ;
	//		}
	//
	//		protected virtual void OnDisable () {
	//			StopCamera () ;
	//			if ( HuD ) {
	//				//ARKit.HuD hud =HuD.GetComponentInParent<ARKit.HuD> () ;
	//				HuDParent =HuD.transform.parent.gameObject.GetComponent<ARKit.HuD> () ;
	//				HuDParent.DeactivatePanel (HuD) ;
	//			}
	//		}
	//
	//		#endregion
	//
	//		#region Methods
	//		protected void InitCamera (Renderer renderer =null) {
	//			WebCamDevice[] devices =WebCamTexture.devices ;
	//			if ( Application.platform == RuntimePlatform.Android ) {
	//				foreach ( WebCamDevice cam in devices ) {
	//					if ( cam.isFrontFacing ) {
	//						_wct =new WebCamTexture (cam.name, Screen.height, Screen.width, 12) ;
	//						if ( _wct != null ) {
	//							_wct.deviceName =cam.name ;
	//							if ( renderer != null )
	//								renderer.material.mainTexture =_wct ;
	//							_wct.Play () ;
	//							break ;
	//						}
	//					}
	//				}
	//			} else {
	//				string deviceName =devices [0].name ;
	//				_wct =new WebCamTexture (deviceName, Screen.height, Screen.width, 12) ;
	//				if ( _wct != null ) {
	//					if ( renderer != null )
	//						renderer.material.mainTexture =_wct ;
	//					_wct.Play () ;
	//				}
	//			}
	//		}
	//
	//		protected void StopCamera () {
	//			_wct.Stop () ;
	//			_wct =null ;
	//		}
	//
	//		public void Scan () {
	//			gameObject.SetActive (!gameObject.activeSelf) ;
	//		}
	//
	//		#endregion
	//
	//	}
	//	#elif UNITY_WSA
	//	public class QRCodeController : MonoBehaviour {
	//
	//		#region Enums
	//		//public enum BitmapFormat {
	//		//	Unknown =0,
	//		//	Gray8 =1,
	//		//	Gray16 =2,
	//		//	RGB24 =3,
	//		//	RGB32 =4,
	//		//	ARGB32 =5,
	//		//	BGR24 =6,
	//		//	BGR32 =7,
	//		//	BGRA32 =8,
	//		//	RGB565 =9,
	//		//	RGBA32 =10,
	//		//	UYVY =11,
	//		//	YUYV =12
	//		//}
	//
	//		#endregion
	//	
	//		#region Fields
	//		protected ARKit.HuD HuDParent =null ;
	//		public GameObject HuD =null ;
	//		public GameObject ForgeLoader =null ;

	//		#endregion
	//
	//		#region Unity APIs
	//		protected virtual void Start () {
	//			//HuDParent =HuD.transform.parent.gameObject.GetComponent<ARKit.HuD> () ;
	//			//ScanCode () ;
	//		}
	//
	//		protected virtual void Update () {
	//			//byte[] pixelBytes =Color32ArrayToByteArray (pixels) ;
	//			//MediaFrameQrProcessing.ZXing.ZXingQRCodeDecoder.ZXingQRCodeDecoder () ;
	//			//var result =MediaFrameQrProcessing.ZXing.ZXingQRCodeDecoder.DecodeBufferToQRCode (
	//			//	pixelBytes,
	//			//	_wct.width, _wct.height,
	//			//	BitmapFormat.ARGB32 
	//			//) ;
	//		}
	//
	//		protected virtual void OnEnable () {
	//			if ( HuD ) {
	//				// GetComponentInParent works only if active.
	//				//ARKit.HuD hud =HuD.transform.parent.gameObject.GetComponent<ARKit.HuD> () ;
	//				HuDParent =HuD.transform.parent.gameObject.GetComponent<ARKit.HuD> () ;
	//				HuDParent.ActivatePanel (HuD) ;
	//			}
	//			ScanCode () ;
	//		}
	//
	//		protected virtual void OnDisable () {
	//			if ( HuD ) {
	//				//ARKit.HuD hud =HuD.GetComponentInParent<ARKit.HuD> () ;
	//				HuDParent =HuD.transform.parent.gameObject.GetComponent<ARKit.HuD> () ;
	//				HuDParent.DeactivatePanel (HuD) ;
	//			}
	//		}
	//
	//		#endregion
	//
	//		#region Methods
	//		public void Scan () {
	//			gameObject.SetActive (!gameObject.activeSelf) ;
	//		}
	//
	//		public void ScanCode () {
	//			MediaFrameQrProcessing.Wrappers.ZXingQrCodeScanner.ScanFirstCameraForQrCode (
	//				result => {
	//						Debug.Log (result) ;
	//						UnityEngine.WSA.Application.InvokeOnAppThread (() => {
	//							//if ( result.BarcodeFormat.ToString () == "QR_CODE" )
	//								//	UnityEngine.Debug.Log (result) ;
	//
	//							Debug.Log (result) ;
	//
	//								GameObject root =ForgeSceneInit.InitRoot () ;
	//								root.SetActive (false) ;
	//								ForgeLoader loader =root.AddComponent<ForgeLoader> () ;
	//								loader.URN =ForgeLoaderConstants._URN ;
	//								loader.BEARER =ForgeLoaderConstants._BEARER ;
	//								loader.SCENEID =ForgeLoaderConstants._SCENEID ;
	//							//	loader.progressBar =_progressBar ;
	//								root.SetActive (true) ;
	//
	//								gameObject.SetActive (false) ;
	//
	//							Debug.Log ("over") ;
	//						},
	//						false
	//					) ;
	//				},
	//				TimeSpan.FromSeconds (30)
	//			) ;
	//		}
	//
	//		private static byte[] Color32ArrayToByteArray (Color32[] colors) {
	//			if ( colors == null || colors.Length == 0 )
	//				return (null) ;
	//			int lengthOfColor32 =Marshal.SizeOf<Color32> () ;
	//			int length =lengthOfColor32 * colors.Length ;
	//			byte[] bytes =new byte [length] ;
	//			GCHandle handle =default (GCHandle) ;
	//			try {
	//				handle =GCHandle.Alloc (colors, GCHandleType.Pinned) ;
	//				IntPtr ptr =handle.AddrOfPinnedObject () ;
	//				Marshal.Copy (ptr, bytes, 0, length) ;
	//			} finally {
	//				if ( handle != default (GCHandle) )
	//					handle.Free () ;
	//			}
	//			return (bytes) ;
	//		}
	//
	//		#endregion
	//
	//	}

#if DAQRI_SMART_HELMET
	public class QRCodeController : MonoBehaviour {

		#region Fields
		protected ARKit.HuD HuDParent = null;
		public GameObject HuD = null;
		public GameObject ForgeLoader = null;
		public GameObject Progress = null;
		protected GameObject _root = null;

		public GameObject qrCodeOverley;
		public GameObject scanBar;
		public Image indicator;
		public GameObject skipButton;

#if UNITY_EDITOR
		private WebCamTexture camTexture;
		private Rect screenRect;
#endif

		#endregion

		#region Unity APIs
		//protected virtual void Awake () {
		//}

#if UNITY_EDITOR
		private void Start () {
			screenRect = new Rect (0, 0, Screen.width, Screen.height);
			WebCamDevice [] devices = WebCamTexture.devices;
			foreach ( WebCamDevice device in devices ) {
				Debug.Log (device.name);
			}
			camTexture = new WebCamTexture (WebCamTexture.devices [1].name) {
				requestedHeight = Screen.height,
				requestedWidth = Screen.width
			};
			if ( camTexture != null ) {
				camTexture.Play ();
			}
		}
#else
        protected virtual void Start()
        {
            //HuDParent =HuD.transform.parent.gameObject.GetComponent<ARKit.HuD> () ;
        }
#endif

		//		protected virtual void Update () {
		//			byte[] bytes =ServiceManager.Instance.GetColorCameraBuffer () ;
		//			Texture2D tex =ServiceManager.Instance.GetColorCameraTexture () ;
		//			Vector2 dimensions =ServiceManager.Instance.GetColorCameraDimensions () ;
		//			//Color32[] pixels =GetColorArray (bytes) ;
		//			Color32[] pixels =GetColorArray (bytes, (int)dimensions.x, 3, true) ;
		//			tex.SetPixels32 (pixels) ;
		//			tex.Apply () ;
		//
		//			//List<BarcodeFormat> codeFormats = new List<BarcodeFormat> () ;
		//			//codeFormats.Add(BarcodeFormat.QR_CODE) ;
		//			IBarcodeReader reader =new BarcodeReader () /*{
		//				AutoRotate =true,
		//				TryInverted =true,
		//				Options ={
		//					PossibleFormats =codeFormats,
		//					TryHarder =true,
		//					ReturnCodabarStartEnd =true,
		//					PureBarcode =false
		//				}
		//			}*/ ;
		//			var result =reader.Decode (pixels, (int)dimensions.x, (int)dimensions.y) ;
		//			//Debug.Log (result) ;
		//			if ( result != null ) {
		//				MydebugClear () ;
		//				Mydebug (result.Text) ;
		//				StopCamera () ;
		//				gameObject.SetActive (false) ;
		//
		////				//if ( result.BarcodeFormat.ToString () == "QR_CODE" )
		////				//	UnityEngine.Debug.Log (result.Text) ;
		////				//_root =ForgeSceneInit.InitRoot () ;
		////
		////				_root =new GameObject (ForgeConstants.ROOT) ;
		////				_root.transform.localPosition =new Vector3 (0, 0, -1.7f) ;
		////				_root.layer =LayerMask.NameToLayer (ForgeConstants.INTERACTIBLE) ;
		////
		////				_root.SetActive (false) ;
		////				ForgeLoader loader =_root.AddComponent<ForgeLoader> () ;
		////				loader.URN =ForgeLoaderConstants._URN ;
		////				loader.BEARER =ForgeLoaderConstants._BEARER ;
		////				loader.SCENEID =ForgeLoaderConstants._SCENEID ;
		////				//	loader.progressBar =_progressBar ;
		////				_root.SetActive (true) ;
		////
		//////				ForgeLoader loader =ForgeLoader.AddLoaderToGameObject (
		//////					_root,
		//////					ForgeLoaderConstants._URN,
		//////					ForgeLoaderConstants._SCENEID,
		//////					ForgeLoaderConstants._BEARER
		//////				) ;
		////
		////
		////
		//				// Generate isolated QR code
		////				string dir =Application.streamingAssetsPath ;
		////				string filename =System.IO.Path.Combine (dir, loader.URN + ".png") ;
		////				Texture2D texture =GenerateQRCode (result.Text, 256) ;
		////				SaveTexture2DToFile (texture, filename) ;
		////				// Generate the Tracking Object
		//
		//				//_root.transform.localPosition =new Vector3 (0, 0, -1.7f) ;
		//				//_root.layer =LayerMask.NameToLayer (ForgeConstants.INTERACTIBLE) ;
		//
		//				RestClient rest =new RestClient (new Uri (result.Text)) ;
		//				Mydebug ("Firing request " + result.Text) ;
		//				rest.FireRequest (
		//					(object sender, AsyncCompletedEventArgs args) => {
		//						if ( args == null || args.UserState == null ) {
		//							Mydebug ("args issue") ;
		//							return ;
		//						}
		//						if ( args.Error != null ) {
		//							Debug.Log (Autodesk.Forge.ARKit.ForgeLoader.GetCurrentMethod () + " " + args.Error.Message) ;
		//							Mydebug ("Error: " + args.Error.Message) ;
		//							return ;
		//						}
		//
		//						DownloadDataCompletedEventArgs args2 =args as DownloadDataCompletedEventArgs ;
		//						byte[] data =args2.Result ;
		//						string textData =System.Text.Encoding.UTF8.GetString (data) ;
		//						Debug.Log (textData) ;
		//						//Mydebug (textData) ;
		//						JSONNode json =JSONNode.Parse (textData) ;
		//
		//						Mydebug ("urn: " + json ["urn"]) ;
		//						Mydebug ("scene_id: " + json ["scene_id"]) ;
		//						//Mydebug ("token: " + json ["token"]) ;
		//
		//						UnityMainThreadDispatcher.Instance ().Enqueue (() => {
		//							Mydebug ("on main thread") ;
		//							/*ForgeLoader loader =*/Autodesk.Forge.ARKit.ForgeLoader.AddLoaderToGameObject (
		//								null,
		//								json ["urn"],
		//								json ["scene_id"],
		//								json ["token"]
		//							) ;
		//						}) ;
		//					}
		//				) ;
		//
		//			}
		//		}

		protected virtual void Update () {
			if ( qrCodeOverley != null ) {
				qrCodeOverley.SetActive (true);
			}
			if ( scanBar != null ) {
				scanBar.SetActive (true);
			}
			IBarcodeReader reader = new BarcodeReader ();
#if UNITY_EDITOR
			var result = reader.Decode (camTexture.GetPixels32 (), camTexture.width, camTexture.height);
#else
            byte[] bytes = ServiceManager.Instance.GetColorCameraBuffer();
            Texture2D tex = ServiceManager.Instance.GetColorCameraTexture();
            Vector2 dimensions = ServiceManager.Instance.GetColorCameraDimensions();
            Color32[] pixels = GetColorArray(bytes, (int)dimensions.x, 3, true);
            tex.SetPixels32(pixels);
            tex.Apply();
            var result = reader.Decode(pixels, (int)dimensions.x, (int)dimensions.y);
#endif
			if ( result != null ) {
				Debug.Log (result.Text);
				//Mydebug.Clear();
				StopCamera ();
				if ( scanBar != null ) {
					scanBar.SetActive (false);
				}
				if ( indicator != null ) {
					indicator.gameObject.SetActive (true);
				}
				if ( panelController != null && panelController.menuTitle != null ) {
					panelController.menuTitle.text = "Scanning complete";
				}
				if ( skipButton != null ) {
					skipButton.SetActive (false);
				}
				Invoke ("DisableQROverlay", 1f);
				gameObject.SetActive (false);

				RestClient rest = new RestClient (new Uri (result.Text));
				rest.FireRequest (
					(object sender, AsyncCompletedEventArgs args) => {
						if ( args == null || args.UserState == null )
							return;
						if ( args.Error != null ) {
							Debug.Log (Autodesk.Forge.ARKit.ForgeLoader.GetCurrentMethod () + " " + args.Error.Message); // Need to handle this situation better.
							return;
						}

						DownloadDataCompletedEventArgs args2 = args as DownloadDataCompletedEventArgs;
						byte [] data = args2.Result;
						string textData = System.Text.Encoding.UTF8.GetString (data);
						Debug.Log (textData);
						JSONNode json = JSONNode.Parse (textData);
						//Mydebug.Log("urn: " + json["urn"]);
						//Mydebug.Log("scene_id: " + json["scene_id"]);
						//Mydebug.Log ("token: " + json ["token"]) ;

						UnityMainThreadDispatcher.Instance ().Enqueue (() => {
							ForgeLoader loader = Autodesk.Forge.ARKit.ForgeLoader.AddLoaderToGameObject (
								null,
								json ["urn"],
								json ["scene_id"],
								json ["token"]
							);
							_root = loader.gameObject;
							loader.ProcessedNodes.AddListener (new UnityAction<float> (ProcessedNodesCB));
							loader.ProcessingNodesCompleted.AddListener (new UnityAction<int> (ProcessingNodesCompletedCB));
						});
					}
				);
			}
		}

		protected void ProcessedNodesCB (float n) {
			if ( Progress == null )
				return;
			Progress.SetActive (true);
			Text text = Progress.GetComponentInChildren<Text> (true);
			text.text = Mathf.Round (n * 100).ToString () + "%";
		}

		protected void ProcessingNodesCompletedCB (int n) {
			// be careful here, the root node, and the scene future root node aren't yet linked
			//            ForgeProperties[] propsArr = _root.GetComponentsInChildren<ForgeProperties>();
			//            ForgeProperties props = propsArr[0];
			//            JSONNode node = props.Properties["props"]["marker"];

			//root.transform.localPosition =new Vector3 (11, -0f, 38f) ;
			_root.AddComponent<VIOInitializer> ();
			commands.SetTheModel (_root);

			if ( ForgeLoaderEngine.IsMarkerDefined (_root.GetComponentInChildren<ForgeProperties> ().gameObject, null) ) {
				Debug.Log ("Marker is defined");
				commands.LookforTrackedObject ();
			} else {
				Debug.Log ("Marker is not defined");
				panelController.JumpToPanelIndex (5);
			}
			if ( Progress != null )
				Progress.SetActive (false);
		}

		protected virtual void OnEnable () {
			if ( HuD ) {
				// GetComponentInParent works only if active.
				//ARKit.HuD hud =HuD.transform.parent.gameObject.GetComponent<ARKit.HuD> () ;
				HuDParent = HuD.transform.parent.gameObject.GetComponent<ARKit.HuD> ();
				HuDParent.ActivatePanel (HuD);
			}
			if ( CameraPreview ) {
				bCameraPreviewWasActve = CameraPreview.activeSelf;
				CameraPreview.SetActive (false);
			}
			InitCamera (GetComponent<Renderer> ());
		}

		protected virtual void OnDisable () {
			StopCamera ();
			if ( CameraPreview )
				CameraPreview.SetActive (bCameraPreviewWasActve);
			if ( HuD ) {
				//ARKit.HuD hud =HuD.GetComponentInParent<ARKit.HuD> () ;
				HuDParent = HuD.transform.parent.gameObject.GetComponent<ARKit.HuD> ();
				HuDParent.DeactivatePanel (HuD);
			}
		}

		#endregion

		#region Methods
		protected void InitCamera (Renderer renderer = null) {
			if ( ServiceManager.InstanceExists )
				ServiceManager.Instance.RegisterVideoTextureUser (this);
			//ServiceManager.Instance.RegisterVideoTextureUser (this, true) ; // HD
		}

		protected void StopCamera () {
			if ( ServiceManager.InstanceExists )
				ServiceManager.Instance.UnregisterVideoTextureUser (this);
		}

		public void Scan () {
			gameObject.SetActive (!gameObject.activeSelf);
		}

		protected static Color32 [] EncodeQRCode (string textForEncoding, int width, int height) {
			var writer = new BarcodeWriter {
				Format = BarcodeFormat.QR_CODE,
				Options = new QrCodeEncodingOptions {
					Height = height,
					Width = width
				}
			};
			return (writer.Write (textForEncoding));
		}

		public static Texture2D GenerateQRCode (string url, int size = 256) {
			Texture2D encoded = new Texture2D (size, size);
			Color32 [] color32 = EncodeQRCode (url, size, size);
			encoded.SetPixels32 (color32);
			encoded.Apply ();
			return (encoded);
		}

		private static byte [] Color32ArrayToByteArray (Color32 [] colors) {
			if ( colors == null || colors.Length == 0 )
				return (null);
			int lengthOfColor32 = Marshal.SizeOf (typeof (Color32));
			int length = lengthOfColor32 * colors.Length;
			byte [] bytes = new byte [length];
			GCHandle handle = default (GCHandle);
			try {
				handle = GCHandle.Alloc (colors, GCHandleType.Pinned);
				IntPtr ptr = handle.AddrOfPinnedObject ();
				Marshal.Copy (ptr, bytes, 0, length);
			} finally {
				if ( handle != default (GCHandle) )
					handle.Free ();
			}
			return (bytes);
		}

		public Color32 [] GetColorArray (byte [] bytes, int stride = 3) {
			if ( bytes == null || bytes.Length == 0 || bytes.Length % stride != 0 )
				return (null);
			Color32 [] colors = new Color32 [bytes.Length / stride];
			for ( var i = 0 ; i < bytes.Length ; i += stride )
				colors [i / stride] = new Color32 (bytes [i], bytes [i + 1], bytes [i + 2], 255);
			return (colors);
		}

		public Color32 [] GetColorArray (byte [] bytes, int width = 640, int stride = 3, bool flipY = true) {
			if ( bytes == null || bytes.Length == 0 || bytes.Length % stride != 0 || bytes.Length % width != 0 )
				return (null);
			Color32 [] colors = new Color32 [bytes.Length / stride];
			int rowBytesLength = stride * width;
			int nbRows = bytes.Length / rowBytesLength;
			for ( int y = 0, c = 0 ; y < nbRows ; y++ ) {
				for ( int x = 0 ; x < rowBytesLength ; x += stride, c++ ) {
					int i = x + (nbRows - y - 1) * rowBytesLength;
					colors [c] = new Color32 (bytes [i], bytes [i + 1], bytes [i + 2], 255);
				}
			}
			return (colors);
		}

		protected void SaveRawBytesToFile (byte [] bytes, string filename) {
			System.IO.File.WriteAllBytes (filename, bytes);
		}

		protected void SaveRawImageToFile (byte [] bytes, string filename) {
			Texture2D tex = new Texture2D (1, 1);
			tex.LoadImage (bytes);
			SaveTexture2DToFile (tex, filename);
		}

		protected void SaveTexture2DToFile (Texture2D texture, string filename) {
			System.IO.File.WriteAllBytes (filename, texture.EncodeToPNG ());
		}

		protected Texture2D LoadTexture2DFromFile (string filename) {
			byte [] bytes = System.IO.File.ReadAllBytes (filename);
			Texture2D tex = new Texture2D (1, 1);
			tex.LoadImage (bytes);
			return (tex);
		}

		private void DisableQROverlay () {
			if ( skipButton != null ) {
				skipButton.SetActive (true);
			}
			if ( panelController != null )
				panelController.GoToNextPanel ();
			if ( qrCodeOverley != null ) {
				qrCodeOverley.SetActive (false);
			}
			if ( scanBar != null ) {
				scanBar.SetActive (true);
			}
			if ( indicator != null ) {
				indicator.gameObject.SetActive (false);
			}

		}

#if UNITY_EDITOR
		private void OnGUI () {
			GUI.DrawTexture (screenRect, camTexture, ScaleMode.ScaleToFit);
		}
#endif
		#endregion

	}

#endif

}
