using UnityEngine;
using UnityEngine.Events;

public class DoWhenTrigger : MonoBehaviour
{
    public UnityEvent whenEntersTrigger;
    public LayerMask enterLayer;
    [Space]
    public UnityEvent whenLeavesTrigger;
    public LayerMask leaveLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((enterLayer.value & 1 << collision.gameObject.layer) != 0)
            whenEntersTrigger.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((leaveLayer.value & 1 << collision.gameObject.layer) != 0)
            whenLeavesTrigger.Invoke();
    }
}
