using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PatternImageView : MonoBehaviour, IPointerDownHandler
{
    public int index;
    public FaceTrackingTest faceTracking;
    public void OnPointerDown(PointerEventData eventData)
    {
        faceTracking.SetMaterial(index);
    }

    public void SetSprite(Sprite sprite)
    {
        this.GetComponent<Image>().sprite = sprite;
    }

}