using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOpenDoor : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void DoorOpens()
    {
        anim.SetBool("Opens", true);

    }

    public void DoorCloses()
    {
        anim.SetBool("Opens", false);

    }



}
