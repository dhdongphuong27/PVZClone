using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject draggingObject;
    public GameObject currentContainer;
    public static GameController instance;
    public float sunRegen;
    public float baseRegen;
    public float sun;
    private float elapsed;
    public Text text;
    public string map;

    void Awake(){
        instance = this;
    }
    void Start()
    {
        baseRegen = 5/1;
        sun = 50;
        elapsed = 0f;

    }
    public void stopRegen()
    {
        baseRegen = 0;
    }
    void Update()
    {   
        elapsed += Time.deltaTime;
        sunRegen = baseRegen + (baseRegen*GameObject.FindGameObjectsWithTag("Sunflower").Length);
        if (elapsed>=1f){
            elapsed = elapsed % 1f;
            sun = sun + sunRegen*Time.timeScale;
            text.GetComponent<UnityEngine.UI.Text>().text = sun.ToString();
        }
    }

    public void PlaceObject()
    {
        string objName = draggingObject.GetComponent<ObjectDragging>().card.object_game.name;
        if (currentContainer != null && currentContainer.GetComponent<ObjectContainer>().isFull == false)
        {
            if (objName == "Object1" && sun >= 50)
            {
                sun = sun - 50;
                Instantiate(draggingObject.GetComponent<ObjectDragging>().card.object_game, currentContainer.transform);
                FindObjectOfType<AudioManager>().PlayAudio("plant");
                currentContainer.GetComponent<ObjectContainer>().isFull = true;
            }
            else if (objName == "Object2" && sun >= 100)
            {
                sun = sun - 100;
                GameObject objectGame = Instantiate(draggingObject.GetComponent<ObjectDragging>().card.object_game, currentContainer.transform);
                FindObjectOfType<AudioManager>().PlayAudio("plant");
                currentContainer.GetComponent<ObjectContainer>().isFull = true;
            }
            else if (objName == "Object3" && sun >= 50)
            {
                sun = sun - 50;
                Instantiate(draggingObject.GetComponent<ObjectDragging>().card.object_game, currentContainer.transform);
                FindObjectOfType<AudioManager>().PlayAudio("plant");
                currentContainer.GetComponent<ObjectContainer>().isFull = true;
            }
            else if (objName == "Object4" && sun >= 200)
            {
                sun = sun - 200;
                GameObject objectGame = Instantiate(draggingObject.GetComponent<ObjectDragging>().card.object_game, currentContainer.transform);
                FindObjectOfType<AudioManager>().PlayAudio("plant");
                currentContainer.GetComponent<ObjectContainer>().isFull = true;
            }
            else if (objName == "Object5" && sun >= 175)
            {
                sun = sun - 175;
                GameObject objectGame = Instantiate(draggingObject.GetComponent<ObjectDragging>().card.object_game, currentContainer.transform);
                FindObjectOfType<AudioManager>().PlayAudio("plant");
                currentContainer.GetComponent<ObjectContainer>().isFull = true;
            }
            //Not enough sun
            else
            {
                StartCoroutine(NotEnoughSun());
            }
            text.GetComponent<UnityEngine.UI.Text>().text = sun.ToString();
        }
        else if (currentContainer != null && currentContainer.GetComponent<ObjectContainer>().isFull == true
                         && objName == "Shovel")
        {
            Instantiate(draggingObject.GetComponent<ObjectDragging>().card.object_game, currentContainer.transform);
            currentContainer.GetComponent<ObjectContainer>().isFull = false;
        }
    }
    IEnumerator NotEnoughSun()
    {
        text.GetComponent<UnityEngine.UI.Text>().color = Color.red;
        FindObjectOfType<AudioManager>().PlayAudio("notenoughsun");
        yield return new WaitForSeconds(1);
        text.GetComponent<UnityEngine.UI.Text>().color = Color.white;
    }
    public void DestroyAllZombies()
    {
        if (sun >= 600)
        {
            sun-=600;
            GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
            foreach (GameObject zombie in zombies)
            {
                zombie.GetComponent<ZombieController>().ReceiveDamage(99999);
            }
            FindObjectOfType<AudioManager>().PlayAudio("explosionnnnnn");
        }
        else {
            StartCoroutine(NotEnoughSun());
        }   
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
