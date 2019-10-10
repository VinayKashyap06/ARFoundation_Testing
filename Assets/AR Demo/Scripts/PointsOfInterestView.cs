using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PointsOfInterestView : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Object clicked");
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}