using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class CollidePassUp : MonoBehaviour
{
    public PlayerCollision parentScript = null;

    private void Start()
    {
        parentScript = GetRootParent(this.transform).GetComponent<PlayerCollision>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        parentScript.HitCollided(PlayerCollision.CollideType.CollisionEnter, collision, this.name);
    }
    private void OnCollisionStay(Collision collision)
    {
        parentScript.HitCollided(PlayerCollision.CollideType.CollisionStay, collision, this.name);
    }
    private void OnCollisionExit(Collision collision)
    {
        parentScript.HitCollided(PlayerCollision.CollideType.CollisionExit, collision, this.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        parentScript.HitCollided(PlayerCollision.CollideType.TriggerEnter, other, this.name);
    }
    private void OnTriggerStay(Collider other)
    {
        parentScript.HitCollided(PlayerCollision.CollideType.TriggerStay, other, this.name);
    }
    private void OnTriggerExit(Collider other)
    {
        parentScript.HitCollided(PlayerCollision.CollideType.TriggerExit, other, this.name);
    }

    private Transform GetRootParent(Transform go)
    {
        //recursively keep going til root parent
        if (go.transform.parent != null)
            return GetRootParent(go.transform.parent);
        else
            return go.transform;
    }
}
