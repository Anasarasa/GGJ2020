﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurPierre : MonoBehaviour
{
    private bool EPEE = false;
    private bool PIOCHE = true;
    private bool HACHE = false;
  
    private float timeToDestroy = 6f;
    public bool destructed = false;
    private float timeBeforeDestroying;

    float neededTime;
    float neededTimeRepear;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var murRenderer = this.GetComponent<Renderer>();

        if (destructed == true)
        {
            timeBeforeDestroying += Time.deltaTime;
            
            murRenderer.material.SetColor("_Color", Color.red);
            if (timeBeforeDestroying > 15)
                Destroy(gameObject);
        }
        else
        {
            murRenderer.material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f); //On remet le cochon bien 
        }
    }

    void OnTriggerStay(Collider other) //Si on rencontre un mob
    {

        if (other.gameObject.tag == "destroyer") //Si c'est le joueur qui détruit
        {
            if (destructed == false) //Si le cochon n'est pas détruit
            {
                neededTime += Time.deltaTime;
                if (neededTime > timeToDestroy)
                {
                    destructed = true;

                }
            }
        }


        if (other.gameObject.tag == "repareur") //Si c'est le joueur qui détruit
        {

            if (destructed == true) //Si le cochon est détruit
            {

                neededTimeRepear += Time.deltaTime;
                if (neededTimeRepear > timeToDestroy)
                {
                    destructed = false;

                }
            }
        }

       
    }

}
