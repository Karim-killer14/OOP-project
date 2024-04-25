using UnityEngine;

public class FlyingEye : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (GameObject.Find("BattleSystem").GetComponent<BattleSystem>().state == BattleState.WON)
        {
            Debug.Log("Skeleton is dead");
            anim.SetTrigger("dead");
        }
        
    }

}