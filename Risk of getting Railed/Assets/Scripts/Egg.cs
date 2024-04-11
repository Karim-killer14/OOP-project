using UnityEngine;

public class Egg : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

}
