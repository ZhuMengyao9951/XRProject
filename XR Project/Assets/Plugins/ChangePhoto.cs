using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class ChangePhoto : MonoBehaviour
{
	string FinalPath;

	public void SelectPhoto()
    {
		// Don't attempt to import/export files if the file picker is already open
		if (NativeFilePicker.IsFilePickerBusy())
			return;
		
#if UNITY_ANDROID
		// Use MIMEs on Android
		string[] fileTypes = new string[] { "image/*", "video/*" };
#else
		// Use UTIs on iOS
		string[] fileTypes = new string[] { "public.image", "public.movie" };
#endif

		// Pick image(s) and/or video(s)
		NativeFilePicker.Permission permission = NativeFilePicker.PickFile((path) =>
		{
			if (path == null)
				Debug.Log("Operation cancelled");
			else
			{
				FinalPath = path;
				Debug.Log("Picked file: " + FinalPath);
				StartCoroutine("LoadTexture");
			}
		}, fileTypes);

		Debug.Log("Permission result: " + permission);
		
	}

	IEnumerator LoadTexture()
    {
		/*
		WWW www = new WWW(FinalPath);
		while (!www.isDone)
			yield return null;
		this.gameObject.GetComponent<Renderer>().material.mainTexture = www.texture;
		*/
		
		UnityWebRequest wr = new UnityWebRequest(FinalPath);
		DownloadHandlerTexture texDl = new DownloadHandlerTexture(true);
		wr.downloadHandler = texDl;
		yield return wr.SendWebRequest();
		if (!wr.isNetworkError)
		{
			Texture2D tex = null;
			tex = texDl.texture;
			this.gameObject.GetComponent<Renderer>().material.mainTexture = tex;
		}
		
	}
}
