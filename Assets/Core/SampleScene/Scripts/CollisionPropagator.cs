using UnityEngine;
using System.Collections;

public class CollisionPropagator : MonoBehaviour
{

    [SerializeField]
    private Transform targetOfPropagation;

    private void Start()
    {
        if (targetOfPropagation != null) return;

        if (transform.parent == null) return;

        targetOfPropagation = transform.parent;
    }


    public void OnCollisionEnter(Collision collision)
    {
        targetOfPropagation.SendMessage("OnCollisionEnter", collision, SendMessageOptions.DontRequireReceiver);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        targetOfPropagation.SendMessage("OnTriggerStay2D", collision, SendMessageOptions.DontRequireReceiver);
    }

    public void OnTriggerStay(Collider other)
    {
        targetOfPropagation.SendMessage("OnTriggerStay", other, SendMessageOptions.DontRequireReceiver);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        targetOfPropagation.SendMessage("OnTriggerExit2D", collision, SendMessageOptions.DontRequireReceiver);
    }

    public void OnTriggerExit(Collider other)
    {
        targetOfPropagation.SendMessage("OnTriggerExit", other, SendMessageOptions.DontRequireReceiver);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        targetOfPropagation.SendMessage("OnTriggerEnter2D", collision, SendMessageOptions.DontRequireReceiver);
    }

    public void OnTriggerEnter(Collider other)
    {
        targetOfPropagation.SendMessage("OnTriggerEnter", other, SendMessageOptions.DontRequireReceiver);
    }

    public void OnMouseUpAsButton()
    {
        targetOfPropagation.SendMessage("OnMouseUpAsButton", SendMessageOptions.DontRequireReceiver);
    }

    public void OnMouseUp()
    {
        targetOfPropagation.SendMessage("OnMouseUp", SendMessageOptions.DontRequireReceiver);
    }

    public void OnMouseOver()
    {
        targetOfPropagation.SendMessage("OnMouseOver", SendMessageOptions.DontRequireReceiver);
    }

    public void OnMouseExit()
    {
        targetOfPropagation.SendMessage("OnMouseExit", SendMessageOptions.DontRequireReceiver);
    }

    public void OnMouseEnter()
    {
        targetOfPropagation.SendMessage("OnMouseEnter", SendMessageOptions.DontRequireReceiver);
    }

    public void OnMouseDrag()
    {
        targetOfPropagation.SendMessage("OnMouseDrag", SendMessageOptions.DontRequireReceiver);
    }

    public void OnMouseDown()
    {
        targetOfPropagation.SendMessage("OnMouseDown", SendMessageOptions.DontRequireReceiver);
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        targetOfPropagation.SendMessage("OnCollisionStay2D", collision, SendMessageOptions.DontRequireReceiver);
    }

    public void OnCollisionStay(Collision collision)
    {
        targetOfPropagation.SendMessage("OnCollisionStay", collision, SendMessageOptions.DontRequireReceiver);
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        targetOfPropagation.SendMessage("OnCollisionExit2D", collision, SendMessageOptions.DontRequireReceiver);
    }

    public void OnCollisionExit(Collision collision)
    {
        targetOfPropagation.SendMessage("OnCollisionExit", collision, SendMessageOptions.DontRequireReceiver);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        targetOfPropagation.SendMessage("OnCollisionEnter2D", collision, SendMessageOptions.DontRequireReceiver);
    }
}

