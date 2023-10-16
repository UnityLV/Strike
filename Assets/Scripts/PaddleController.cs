using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PaddleController : MonoBehaviour
{
    public Camera mainCamera;
    private Vector3 touchOffset;
    private bool isDragging = false;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                return; 
            }

            Vector3 touchWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y,
                -mainCamera.transform.position.z));

            if (touch.phase == TouchPhase.Began)
            {
                touchOffset = transform.position - touchWorldPosition;
                isDragging = true;
            }

            if (touch.phase == TouchPhase.Moved && isDragging)
            {
                Vector3 newPosition = touchWorldPosition + touchOffset;
                newPosition.z = 0;
                transform.position = newPosition;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                isDragging = false;
            }
        }
    }
}