using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject eggbullet;
    public float fireRate;
    public float timer=0;
    public bool shoot;
    public int bulletcount = 0;
 
    

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            shoot = true;
        }
        if (shoot == true&&bulletcount<10)
        {
            if (timer < fireRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                Instantiate(eggbullet, transform.position, transform.rotation);
                bulletcount++;
                timer = 0;
            }
        }
        if(bulletcount >= 10)
        {
            bulletcount = 0;
            shoot = false;
        }
    }
}
/* if(Input.GetKeyDown(KeyCode.Space)==true )
        {
            shoot = true;
        }
        if (shoot == true)
        {*/