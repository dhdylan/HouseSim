using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SettingDirection
{
    X,
    Y,
    Z,
    Xneg,
    Yneg,
    Zneg
}

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

    [SerializeField]
    SettingDirection settingDirection = SettingDirection.Yneg;


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

        Vector3[] moveButtonOffsets = generateMoveButtonOffsets();

        for(int i=0; i<moveButtons.Length; i++)
        {
            moveButtons[i] = Instantiate(moveButtonPrefab, boxCollider.bounds.center, transform.rotation, transform);

            moveButtons[i].transform.localPosition = boxCollider.bounds.center + moveButtonOffsets[i];

            moveButtons[i].transform.rotation = Quaternion.LookRotation((moveButtons[i].transform.position - boxCollider.bounds.center) * 2);

            moveButtons[i].owningObject = this;
        }

        return moveButtons;
    }

    private Vector3[] generateMoveButtonOffsets()
    {
        if(settingDirection is SettingDirection.X || settingDirection is SettingDirection.Xneg)
        {
            Vector3[] moveButtonOffsets = new Vector3[4];
            moveButtonOffsets[0] = new Vector3(0f, 0f, boxCollider.bounds.extents.z + moveButtonPadding);
            moveButtonOffsets[1] = new Vector3(0f, -boxCollider.bounds.extents.y - moveButtonPadding, 0f);
            moveButtonOffsets[2] = new Vector3(0f, 0f, -boxCollider.bounds.extents.z - moveButtonPadding);
            moveButtonOffsets[3] = new Vector3(0f, boxCollider.bounds.extents.y + moveButtonPadding, 0f);
            return moveButtonOffsets;
        }
        else if(settingDirection is SettingDirection.Y || settingDirection is SettingDirection.Yneg)
        {

            Vector3[] moveButtonOffsets = new Vector3[4];
            moveButtonOffsets[0] = new Vector3(0f, 0f, boxCollider.bounds.extents.z + moveButtonPadding);
            moveButtonOffsets[1] = new Vector3(-boxCollider.bounds.extents.x - moveButtonPadding, 0f, 0f);
            moveButtonOffsets[2] = new Vector3(0f, 0f, -boxCollider.bounds.extents.z - moveButtonPadding);
            moveButtonOffsets[3] = new Vector3(boxCollider.bounds.extents.x + moveButtonPadding, 0f, 0f);
            return moveButtonOffsets;
        }
        else//(settingDirection is SettingDirection.Z || settingDirection is SettingDirection.Zneg)
        {
            Vector3[] moveButtonOffsets = new Vector3[4];
            moveButtonOffsets[0] = new Vector3(0f, boxCollider.bounds.extents.y + moveButtonPadding, 0f);
            moveButtonOffsets[1] = new Vector3(-boxCollider.bounds.extents.x - moveButtonPadding, 0f, 0f);
            moveButtonOffsets[2] = new Vector3(0f, -boxCollider.bounds.extents.y - moveButtonPadding, 0f);
            moveButtonOffsets[3] = new Vector3(boxCollider.bounds.extents.x + moveButtonPadding, 0f, 0f);
            return moveButtonOffsets;
        }
    }
}
