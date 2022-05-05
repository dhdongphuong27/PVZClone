using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPController : MonoBehaviour
{
    public int HP;

    public void ReceiveDamage(int DMG)
    {
        if (HP - DMG <= 0)
        {
            this.gameObject.transform.parent.gameObject.GetComponent<ObjectContainer>().isFull = false;
            Destroy(this.gameObject); 
            FindObjectOfType<AudioManager>().PlayAudio("gulp");
        }
        else
        {
            HP = HP - DMG;
        }
    }
    public void Shoveled()
    {
        this.gameObject.transform.parent.gameObject.GetComponent<ObjectContainer>().isFull = false;
        Destroy(this.gameObject); 
    }
}
