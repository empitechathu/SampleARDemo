using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{
    private ARRaycastManager _raycastManager;
    private GameObject _gameObject;

    void Start()
    {
        // get the components
        _raycastManager = FindObjectOfType<ARRaycastManager>();
        _gameObject = transform.GetChild(0).gameObject;
      
        // hide the placement visual
        _gameObject.SetActive(false);

    }

    void Update()
    {
        // shoot the raycast from the center of the screen
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        _raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);
      
        // if we hit the ARPlane , update the position and rotation
        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            if (!_gameObject.activeInHierarchy)
            {
                _gameObject.SetActive(true);
            }
        }
    }
}
