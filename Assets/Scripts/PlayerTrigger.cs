﻿using UnityEngine;
using System.Collections;

public class PlayerTrigger : MonoBehaviour
{
    private int Collected = 0; //Set up a variable to store how many you've collected
    public AudioClip CollectedClip;     //This is the sound that will play after you collect one
    public AudioClip EnemyClip;
    public AudioSource PlayerSource;     //This is the sound that
    public AudioSource EnemySource;
    public float Volume = 1.0f;
    public float CanvasX = 10f;
    public float CanvasY = 10f;
    public float CanvasWidth = 100f; //NOT smaller than 100 or the score wont show
    public float CanvasHeight = 20f;


    //This is the text that displayed how many you've collected in the top left corner
    void OnGUI(string Message, string Type)
    {
        GUI.Label(new Rect(CanvasX, CanvasY, CanvasWidth, CanvasHeight), Message + Collected);
        if (Type=="numeric")
        {
            GUI.Label(new Rect(CanvasX, CanvasY, CanvasWidth, CanvasHeight), Message + Collected);
        }   
        
        else if(Type=="text")
        {
            GUI.Label(new Rect(CanvasX, CanvasY, CanvasWidth, CanvasHeight),  Message);
        }
    }

    private void OnTriggerEnter(Collider other)
    { //Checks to see if you've collided with another object

        if (other.CompareTag("Collectable"))
        { //checks to see if this object is tagged with "collectable"
            PlayerSource.PlayOneShot(CollectedClip); //plays the sound assigned to collectedSound
            Collected++; //adds a count of +1 to the collected variable
            Destroy(other.gameObject); //destroy's the collectable
            OnGUI("Collected", "numeric");
            if (Collected >= 3)
            {
                OnGUI("勝者は貴方！！！", "text");
            }
        }

        if (other.CompareTag("Enemy"))
        { //checks to see if this object is tagged with "collectable"
            EnemySource.PlayOneShot(EnemyClip); //plays the sound assigned to collectedSound
            OnGUI("死亡（笑笑笑）", "text");
        }
    }
}