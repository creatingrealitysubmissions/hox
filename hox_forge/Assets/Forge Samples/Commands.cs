//
// Copyright (c) Autodesk, Inc. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
//
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
#if !UNITY_WSA
using System.Net;
#endif
using SimpleJSON;


namespace Autodesk.Forge.ARKit {

	[System.Serializable]
	public class oAuthCompletedEvent : UnityEvent<string> {
	}

	public class Commands : MonoBehaviour {

		#region Fields
		public string bearer = "";
		public GameObject loader =null ;
		public GameObject combobox =null ;

		[SerializeField]
		public oAuthCompletedEvent oAuthCompleted = new oAuthCompletedEvent ();

		protected JSONNode scenesList;

		#endregion

		#region Unity APIs
		protected void Awake () {
			oAuth2Legged ();
		}

		#endregion

		#region Commands
		public void oAuth2Legged () {
			oAuth2Legged rest =new oAuth2Legged () ;
			rest.FireRequest (
				(object sender, AsyncCompletedEventArgs args) => {
					if ( args == null || args.UserState == null )
						return ;
					if ( args.Error != null ) {
						UnityMainThreadDispatcher.Instance ().Enqueue (() => {
							Debug.Log (Autodesk.Forge.ARKit.ForgeLoader.GetCurrentMethod () + " " + args.Error.Message) ;
						}) ;
						return ;
					}

					//UploadValuesCompletedEventArgs args2 =args as UploadValuesCompletedEventArgs ;
					//byte[] data =args2.Result ;
					//string textData =System.Text.Encoding.UTF8.GetString (data) ;

					UploadStringCompletedEventArgs args2 =args as UploadStringCompletedEventArgs ;
					string textData =args2.Result ;

					JSONNode json =JSONNode.Parse (textData) ;

					bearer =json ["access_token"];
					UnityMainThreadDispatcher.Instance ().Enqueue (() => {
						oAuthCompleted.Invoke (bearer);
					}) ;

					if ( loader != null ) {
						UnityMainThreadDispatcher.Instance ().Enqueue (() => {
							ForgeLoader forgeLoader =loader.GetComponent<ForgeLoader> () ;
							forgeLoader.BEARER =bearer;
							if ( string.IsNullOrEmpty (forgeLoader.URN) || string.IsNullOrEmpty (forgeLoader.SCENEID) )
								return ;
							loader.SetActive (true) ;
						}) ;
					}
				}
			) ;
		}

		public void ListScenes (string bearer) {
			ForgeLoader forgeLoader = loader.GetComponent<ForgeLoader> ();
			string url =ForgeLoaderConstants._endpoint1 + forgeLoader.URN + "/scenes" ;
			Hashtable headers =new Hashtable ();
			headers.Add ("Authorization", "Bearer " + bearer) ;
			RestClient rest =new RestClient (new System.Uri (url), headers) ;
			rest.FireRequest (
				(object sender, AsyncCompletedEventArgs args) => {
					if ( args == null || args.UserState == null )
						return ;
					if ( args.Error != null ) {
						UnityMainThreadDispatcher.Instance ().Enqueue (() => {
							Debug.Log (Autodesk.Forge.ARKit.ForgeLoader.GetCurrentMethod () + " " + args.Error.Message) ;
						}) ;
						return ;
					}

					DownloadDataCompletedEventArgs args2 =args as DownloadDataCompletedEventArgs ;
					string textData =System.Text.Encoding.UTF8.GetString (args2.Result) ;

					scenesList =JSONNode.Parse (textData) ;

					if ( scenesList.AsArray.Count > 0 ) {
						UnityMainThreadDispatcher.Instance ().Enqueue (() => {
							Dropdown dd =combobox.GetComponent<Dropdown> () ;
							foreach ( JSONNode child in scenesList.AsArray ) {
								dd.options.Add (new Dropdown.OptionData (child.Value)) ;
							}
						}) ;
					}

				}
			) ;
		}

		public void LoadScene (int scene) {
			if ( scene <= 0 || scene > scenesList.AsArray.Count )
				return;
			scene--;
			ForgeLoader forgeLoader = loader.GetComponent<ForgeLoader> ();

			GameObject obj = new GameObject ();
			obj.SetActive (false);
			ForgeLoader objLoader =obj.AddComponent<ForgeLoader> ();
			objLoader.URN = forgeLoader.URN;
			objLoader.BEARER = bearer;
			objLoader.SCENEID = scenesList.AsArray [scene].Value;
			objLoader.ProcessedNodes = forgeLoader.ProcessedNodes;
			objLoader.ProcessingNodesCompleted = forgeLoader.ProcessingNodesCompleted;
			obj.SetActive (true);
		}

		#endregion

	}

}
