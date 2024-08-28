
using UnityEngine;

public class JunkRotate : JunkAbstract
{
    [SerializeField] protected float speed = 9f;

    protected virtual void FixedUpdate()
    {
        this.Rotating();
    }

    protected virtual void Rotating()
    {
        float randomSpeed = Random.Range(9, 15);
        Vector3 eulers = new Vector3(0, 0, 1);
        this.junkCtrl.Model.Rotate(eulers*randomSpeed*Time.fixedDeltaTime);
    }
}
