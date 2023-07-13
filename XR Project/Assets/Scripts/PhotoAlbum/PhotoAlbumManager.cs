using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoAlbumManager : MonoBehaviour
{
    // Start is called before the first frame update
    // current photo id from photo list
    public int currentPhotoIdLeft = 0;
    public int currentPhotoIdRight = 1;
    public PhotoList photoList;
    public GameObject leftPage;
    public GameObject rightPage;
    
    void Start()
    {
        if (photoList.photos.Count < 2)
        {
            Debug.LogError("Photo list should have at least 2 photos");
            return;
        }

        if(leftPage == null || rightPage == null)
        {
            Debug.LogError("Left and right page should be assigned");
            return;
        }

        if (photoList == null)
        {
            Debug.LogError("Photo list should be assigned");
            return;
        }
        
        leftPage.GetComponent<Renderer>().material.mainTexture = photoList.photos[currentPhotoIdLeft];
        rightPage.GetComponent<Renderer>().material.mainTexture = photoList.photos[currentPhotoIdRight];    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePicture(int id)
    {
        if (id < 0 || id >= photoList.photos.Count)
        {
            Debug.LogError("Photo id is out of range");
            return;
        }

        leftPage.GetComponent<Renderer>().material.mainTexture = photoList.photos[id];

        if (id + 1 < photoList.photos.Count)
        {
            rightPage.GetComponent<Renderer>().material.mainTexture = photoList.photos[id + 1];
        }
        else
        {
            // disable 
            rightPage.GetComponent<Renderer>().material.mainTexture = null;
        }
    }

    public void TurnPage()
    {
        if (currentPhotoIdLeft == photoList.photos.Count - 1)
        {
            currentPhotoIdLeft = 0;
            currentPhotoIdRight = 1;;
        }
        else
        {
            currentPhotoIdLeft += 2;
            currentPhotoIdRight += 2;
        }
        ChangePicture(currentPhotoIdLeft);
        // leftPage.GetComponent<Renderer>().material.mainTexture = photoList.photos[id];
        // rightPage.GetComponent<Renderer>().material.mainTexture = photoList.photos[id + 1];
    }
}
