using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField]
    LayerMask mask;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            ShootMoveRay();
    }

    public void ShootMoveRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 10f, mask);
        MoveButton moveButton;
        if (hit.transform.TryGetComponent<MoveButton>(out moveButton))
        {
            moveButton.OnClick();
        }
    }
}
