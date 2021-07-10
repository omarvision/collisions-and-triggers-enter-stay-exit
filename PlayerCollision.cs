using UnityEngine;

//  Collision Between GameObjects
//  -----------------------------
//  1. Both gameobjects need colliders
//  2. At least one gameobject needs Rigidbody
//   - collision (objects are solid)
//   - trigger   (objects are pass thru)

public class PlayerCollision : MonoBehaviour
{
    #region --- helpers ---
    public enum CollideType
    {
        CollisionEnter,
        CollisionStay,
        CollisionExit,
        TriggerEnter,
        TriggerStay,
        TriggerExit,
    }
    #endregion

    public TextMesh tm = null;
    private string msg = "";

    private void OnCollisionEnter(Collision collision)
    {
        string s1 = msg + string.Format("{0} CollisionEnter {1}", this.name, collision.gameObject.name);
        tm.text = s1;
        Debug.Log(s1);
    }
    private void OnCollisionStay(Collision collision)
    {
        string s1 = msg + string.Format("{0} CollisionStay {1}", this.name, collision.gameObject.name);
        tm.text = s1;
        Debug.Log(s1);
    }
    private void OnCollisionExit(Collision collision)
    {
        string s1 = msg + string.Format("{0} CollisionExit {1}", this.name, collision.gameObject.name);
        tm.text = s1;
        Debug.Log(s1);
    }
    private void OnTriggerEnter(Collider other)
    {
        string s1 = msg + string.Format("{0} TriggerEnter {1}", this.name, other.gameObject.name);
        tm.text = s1;
        Debug.Log(s1);
    }
    private void OnTriggerStay(Collider other)
    {
        string s1 = msg + string.Format("{0} TriggerStay {1}", this.name, other.gameObject.name);
        tm.text = s1;
        Debug.Log(s1);
    }
    private void OnTriggerExit(Collider other)
    {
        string s1 = msg + string.Format("{0} TriggerExit {1}", this.name, other.gameObject.name);
        tm.text = s1;
        Debug.Log(s1);
    }

    public void HitCollided(CollideType code, Collision collision, string child)
    {
        msg = child + ", ";
        switch (code)
        {
            case CollideType.CollisionEnter:
                OnCollisionEnter(collision);
                break;
            case CollideType.CollisionStay:
                OnCollisionStay(collision);
                break;
            case CollideType.CollisionExit:
                OnCollisionExit(collision);
                break;
        }
    }
    public void HitCollided(CollideType code, Collider other, string child)
    {
        msg = child + ", ";
        switch (code)
        {
            case CollideType.TriggerEnter:
                OnTriggerEnter(other);
                break;
            case CollideType.TriggerStay:
                OnTriggerStay(other);
                break;
            case CollideType.TriggerExit:
                OnTriggerExit(other);
                break;
        }
    }
}
