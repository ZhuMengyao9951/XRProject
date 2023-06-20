using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePhoto : MonoBehaviour
{
    public GameObject EmptyFrame;
    public Button btn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangePhoto()
    {
        EmptyFrame.GetComponent<Renderer>().material.mainTexture = btn.GetComponent<Image>().sprite.texture;
    }
}
