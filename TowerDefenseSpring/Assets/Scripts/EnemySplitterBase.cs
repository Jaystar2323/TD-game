using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySplitterBase : Enemy
{

    public override void onDeath()
    {
        GetComponentInParent<EnemySplitter>().onDeath();
    }

}
