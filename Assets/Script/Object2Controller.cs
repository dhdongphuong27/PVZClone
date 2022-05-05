using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object2Controller : MonoBehaviour
{
    public GameObject bullet;
    public List<GameObject> zombies;
    public float attackCooldown;
    private float attackTime;
    public bool isAttacking;
    public int ATK;
     
    private void Update()
    {
        if (attackTime <= Time.time)
        {
            GameObject bulletInstance = Instantiate(bullet, transform);
            bulletInstance.GetComponent<BulletController>().ATK = ATK;
            FindObjectOfType<AudioManager>().PlayAudio("firepea");
            attackTime = Time.time + attackCooldown;
        }
    }
}
