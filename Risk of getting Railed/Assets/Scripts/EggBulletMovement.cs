using UnityEngine;

public class EggBulletMovement : MonoBehaviour
{
    public float firespeedleft;
    public float firespeeddown;
    public float deadzone;
    
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left*firespeedleft*Time.deltaTime + Vector3.down*firespeeddown*Time.deltaTime;

        if (transform.position.x < deadzone)
        {
            Destroy(gameObject);
        }
    }
}
