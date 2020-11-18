using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDoor : MonoBehaviour {
    public EnemyManager enemy;
    public TargetDragon dragon;
    private bool _start = false;

    private void Update()
    {
        if (_start)
            dragon.StartFight();
    }

    private void OnTriggerEnter(Collider other)
    {
        enemy.ShowSlider();
        _start = true;
    }
}
