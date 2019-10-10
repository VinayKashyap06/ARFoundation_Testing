using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlacementController : MonoBehaviour
{
    [SerializeField]private GameObject prefab;
    public GameObject prefabToAdd { get {
            return prefab;
        }
        set {
            prefab = value;
        }
    }
    private ARRaycastManager raycastManager;
    private static List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();    
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {

            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        else
        {
            touchPosition = default;
            return false;
        }
    }

    private void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPos))
            return;
        if (raycastManager.Raycast(touchPos,raycastHits,TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = raycastHits[0].pose;

            GameObject.Instantiate(prefabToAdd, hitPose.position, hitPose.rotation);
        }

    }
}
