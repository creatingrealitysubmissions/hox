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
using System.Collections.Generic;
using UnityEngine;

#if DAQRI_SMART_HELMET
namespace Autodesk.Forge.ARKit {

	public class ZxingController : MonoBehaviour {

#region Fields
		public Transform textMeshObject =null ;
		protected TextMesh textMesh =null ;

#endregion

#region Unity APIs
		protected virtual void Start () {
			if ( this.textMeshObject )
				this.textMesh =this.textMeshObject.GetComponent<TextMesh> () ;
			this.OnReset () ;
		}

#endregion

#region Methods
		public void OnScan () {
			if ( this.textMesh )
				this.textMesh.text ="scanning for 30s" ;
#if !UNITY_EDITOR
			MediaFrameQrProcessing.Wrappers.ZXingQrCodeScanner.ScanFirstCameraForQrCode (
				result => {
					UnityEngine.WSA.Application.InvokeOnAppThread (() => {
							if ( this.textMesh )
								this.textMesh.text =result ?? "not found" ;
						},
						false
					) ;
				},
				TimeSpan.FromSeconds (30)
			) ;
#endif
		}

		public void OnRun () {
			if ( this.textMesh )
				this.textMesh.text ="running forever" ;
#if !UNITY_EDITOR
			MediaFrameQrProcessing.Wrappers.ZXingQrCodeScanner.ScanFirstCameraForQrCode (
				result => {
					UnityEngine.WSA.Application.InvokeOnAppThread (() => {
							if ( this.textMesh )
								this.textMesh.text =$"Got result {result} at {DateTime.Now}" ;
						},
						false
					) ;
				},
				null
			) ;
#endif
		}

		public void OnReset () {
			if ( this.textMesh )
				this.textMesh.text ="say scan or run to start" ;
		}

#endregion

	}

}

#endif
