using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{
    public float movementSpeed;
    public int ATK;
    public Sprite fireBullet;
    void Update()
    {
        //transform.Translate(new Vector3(movementSpeed,0,0));
        Vector3 newPosition = transform.position;
        newPosition.x += movementSpeed*Time.timeScale*Time.deltaTime*500;
        transform.position = newPosition;
        if (transform.position.x>2000)
        {
            Destroy(this.gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            if (collision.gameObject.name == "Zombie1(Clone)")
            {
                FindObjectOfType<AudioManager>().PlayAudio("zombie1hit");
            }
            else if (collision.gameObject.name == "Zombie2(Clone)")
            {
                FindObjectOfType<AudioManager>().PlayAudio("zombie2hit");
            }
            else if (collision.gameObject.name == "Zombie3(Clone)")
            {
                FindObjectOfType<AudioManager>().PlayAudio("zombie3hit");
            }
            collision.gameObject.GetComponent<ZombieController>().ReceiveDamage(ATK);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Torch")
        {
            ATK = 200;
            this.gameObject.GetComponent<Image>().sprite = fireBullet;
        }
        
    }
    
}
