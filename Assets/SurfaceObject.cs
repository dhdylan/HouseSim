using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SurfaceObject : MonoBehaviour
{
    [SerializeField]
    BoxCollider boxCollider;

    [SerializeField]
    MoveButton[] moveButtons;

    [SerializeField]
    MoveButton moveButtonPrefab;

    [SerializeField]
    float moveButtonPadding = 0.5f;

    [SerializeField]
    bool moveMode = false;


    private void Start()
    {
        moveButtons = InstantiateMoveButtons();
    }

    public void ToggleMoveMode()
    {
        moveMode = !moveMode;

        SetMoveButtonVisibility(moveMode);
    }

    private void SetMoveButtonVisibility(bool show)
    {
        
    }

    private MoveButton[] InstantiateMoveButtons()
    {
        MoveButton[] moveButtons = new MoveButton[4];

        Vector3[] moveButtonOffsets = new Vector3[4];
        moveButtonOffsets[0] = new Vector3(0f, 0f, boxCollider.bounds.extents.z + moveButtonPadding);
        moveButtonOffsets[1] = new Vector3(-boxCollider.bounds.extents.x - moveButtonPadding, 0f, 0f);
        moveButtonOffsets[2] = new Vector3(0f, 0f, -boxCollider.bounds.extents.z - moveButtonPadding);
        moveButtonOffsets[3] = new Vector3(boxCollider.bounds.extents.x + moveButtonPadding, 0f, 0f);

        for(int i=0; i<moveButtons.Length; i++)
        {
            moveButtons[i] = Instantiate(moveButtonPrefab, boxCollider.bounds.center + moveButtonOffsets[i], transform.rotation, transform);
            moveButtons[i].transform.rotation = Quaternion.LookRotation(transform.TransformDirection(moveButtonOffsets[i]), Vector3.up);
            moveButtons[i].transform.Rotate(new Vector3(0f, 90f, 0f));
        }

        return moveButtons;
    }
}
