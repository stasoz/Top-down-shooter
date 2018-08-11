using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEnemy : MonoBehaviour {
    
    public abstract void installValues();
    public abstract void moveForPlayer();
    public abstract void creatingBullets();
}
