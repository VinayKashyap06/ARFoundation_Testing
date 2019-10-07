using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MenuController : MonoBehaviour
{
    public Button imageTracking;
    public Button faceTracking;
    public Button quitTracking;

    private void Start()
    {
        imageTracking.onClick.AddListener(ImageExample);
        faceTracking.onClick.AddListener(FaceExample);
        quitTracking.onClick.AddListener(() => Application.Quit());
    }

    private void ImageExample()
    {
        SceneManager.LoadScene(1);
    }

    private void FaceExample()
    {
        SceneManager.LoadScene(2);
    }
}
