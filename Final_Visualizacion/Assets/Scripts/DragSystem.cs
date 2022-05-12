using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSystem : MonoBehaviour
{
    public bool startDrag, inUse;


    void Update()
    {
        if (startDrag)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void StartDragUI()
    {
        startDrag = true;
    }

    public void StopDragUI()
    {
        startDrag = false;
    }

}
