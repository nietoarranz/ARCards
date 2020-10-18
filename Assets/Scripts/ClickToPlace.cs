using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]

public class ClickToPlace : MonoBehaviour
{

    public GameObject gameObjectToInstantiate;
    public Button lockButton;

    private Vector2 touchPosition;
    private GameObject spawnedObject;
    private ARRaycastManager rayManager;
    private bool isLocked = false;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        rayManager = GetComponent<ARRaycastManager>();
        if (lockButton != null)
        {
            lockButton.onClick.AddListener(Lock);
        }

    }

    private void Lock()
    {
        isLocked = !isLocked;
    }


    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;

    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
        }
       
       /*if(!TryGetTouchPosition(out Vector2 touchPosition))
            return;*/

        if (rayManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(gameObjectToInstantiate, hitPose.position, hitPose.rotation);
            }
            else
            {
                if (!isLocked)
                {
                    spawnedObject.transform.position = hitPose.position;
                }
            }

        }
    }
}