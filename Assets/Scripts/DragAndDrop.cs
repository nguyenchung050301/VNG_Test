using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    private bool canDrag = false;
    private Camera _camera;
    private Vector3 mouseWorldPosition;
    private void Awake()
    {
        _camera = Camera.main;
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            canDrag = true;
    //        Debug.Log("Mouse Entered");
        }
            
    }
    private void OnMouseDrag()
    {
        if (canDrag)
        {
           transform.position = DragPosition(Input.mousePosition, transform.position);
    //        Debug.LogFormat("Mouse Dragging");
        }
      
    }
    private void OnMouseUp()
    {
        canDrag = false;
   //     Debug.Log("Mouse Exited");
    }
    private Vector3 DragPosition(Vector3 mousePos, Vector3 objectPos)
    {
        mouseWorldPosition = _camera.ScreenToWorldPoint(mousePos);
        return new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, objectPos.z) + offset;

    }
}
