using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iDamageable
{
    bool ApplyDamage(Rigidbody rigidbody, float force);

}
