using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineTriggerTransition : MonoBehaviour
{
    public Animator m_Animator;

    private void OnTriggerEnter2D(Collider2D col)
    {
               
        if (col.transform.CompareTag("Player"))
        {
            m_Animator.SetTrigger("IsWarping");
            print("vwarp");
        }
    }
}
