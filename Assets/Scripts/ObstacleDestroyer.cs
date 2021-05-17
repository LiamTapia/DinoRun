using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : DamageController
{
    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void Interact()
    {
        base.Interact();
        Destroy(gameObject);
    }
}
