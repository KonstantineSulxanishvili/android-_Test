using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSharp : MonoBehaviour
{
    enum MouseStates
    {
        NOT_DRAGING,

        DRAGING
    }

    private MouseStates currentMouseState = MouseStates.NOT_DRAGING;

    [SerializeField] private GameObject _target;

void Update()
{
    switch(currentMouseState)
    {
        case MouseStates.NOT_DRAGING:

         if(Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mouseRay.origin, mouseRay.direction, Mathf.Infinity);
            if(hit.collider != null)
            {
                _target =  hit.collider.gameObject;
                ChangeState(MouseStates.DRAGING);
            }
        }

        break;

    case MouseStates.DRAGING:
        if(Input.GetMouseButtonUp(0))
        {
           ChangeState(MouseStates.NOT_DRAGING);
           if(_target != null)
           {
               _target = null;
               break;
           }
        }

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10));
            _target.transform.position = mousePos;
            break;
    }
}
    void ChangeState(MouseStates targetStates)
    {
        currentMouseState = targetStates;
    }
}
