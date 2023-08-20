using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceObject : MonoBehaviour
{
    [SerializeField]
    MoveButton up;
    [SerializeField]
    MoveButton left;
    [SerializeField]
    MoveButton down;
    [SerializeField]
    MoveButton right;

    bool moveMode = false;


    private void Start()
    {
        up.owningObject = this;
        left.owningObject = this;
        down.owningObject = this;
        right.owningObject = this;
    }

    public void ToggleMoveMode()
    {
        moveMode = !moveMode;

        SetMoveButtonVisibility(moveMode);
    }

    private void SetMoveButtonVisibility(bool show)
    {
        up.gameObject.SetActive(show);
        left.gameObject.SetActive(show);
        down.gameObject.SetActive(show);
        right.gameObject.SetActive(show);
    }
}
