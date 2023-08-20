using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : MonoBehaviour
{
    public SurfaceObject owningObject;
    public Vector3 localMoveDirection;

    public void OnClick()
    {
        owningObject.transform.localPosition += localMoveDirection;
    }
}
