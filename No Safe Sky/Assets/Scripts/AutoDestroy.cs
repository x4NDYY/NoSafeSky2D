using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    void Start()
    {
        Animator anim = GetComponent<Animator>();

        float length = anim.GetCurrentAnimatorStateInfo(0).length;

        Destroy(gameObject, length);
    }
}
