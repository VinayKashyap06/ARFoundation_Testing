using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class FaceTrackingTest : MonoBehaviour
{
    [Serializable]
    private struct FaceMaterials
    {
        public string name;
        public Material mat;
        public Sprite imageSprite;
    }


    private ARFaceManager arFaceManager;
    public Button homeButton;
    public Image imagePrefab;
    public Transform imageHolder;
    [SerializeField]
    private FaceMaterials[] faceMaterials;
    private void Awake()
    {
        arFaceManager = GetComponent<ARFaceManager>();
        homeButton.onClick.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene(0));
        SetImageElements();
        
    }
    
    
    private void OnEnable()
    {
 
    }
    public void SetMaterial(int index)
    {
        Debug.Log("count of trackables"+arFaceManager.trackables.count);
        foreach (var item in arFaceManager.trackables)
        {           
            item.GetComponent<MeshRenderer>().material = faceMaterials[index].mat;
            Debug.Log("item managed");
        }
    }

    private void SetImageElements()
    {
        for (int i = 0; i < faceMaterials.Length; i++)
        {
            GameObject image = GameObject.Instantiate(imagePrefab.gameObject);
            PatternImageView view=image.GetComponent<PatternImageView>();
            view.index = i;
            view.SetSprite(faceMaterials[i].imageSprite);
            view.faceTracking = this;
            image.transform.SetParent(imageHolder.transform);
        }
    }
}