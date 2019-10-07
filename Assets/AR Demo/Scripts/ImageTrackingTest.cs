using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class ImageTrackingTest : MonoBehaviour
{
    public ARTrackedImageManager trackerImageManager;
    public Button homeButton;
    private void Awake()
    {
        trackerImageManager = GetComponent<ARTrackedImageManager>();
        homeButton.onClick.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene(0));
    }

    private void OnEnable()
    {
        trackerImageManager.trackedImagesChanged += OnTrackedImageChanged;
    }

    private void OnTrackedImageChanged(ARTrackedImagesChangedEventArgs obj)
    {
        foreach (ARTrackedImage trackedImage in obj.added)
        {
            trackedImage.transform.localScale = new Vector3(trackedImage.referenceImage.size.x, 0.005f, trackedImage.referenceImage.size.x);
        }
        foreach (ARTrackedImage trackedImage in obj.updated)
        {
            trackedImage.transform.localScale = new Vector3(trackedImage.referenceImage.size.x, 0.005f, trackedImage.referenceImage.size.x);
        }
    }

    private void OnDisable()
    {
        trackerImageManager.trackedImagesChanged -= OnTrackedImageChanged;
    }
}