using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienDeathController : Interactable
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void Interact()
    {
        animator.SetTrigger("isDeath");
        Destroy(gameObject,0.2f);
    }
}
