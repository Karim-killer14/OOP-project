using UnityEngine;

public class Wing : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

}
