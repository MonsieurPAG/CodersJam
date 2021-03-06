﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoderJam
{
    public class Player : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public GameObject spawn;
        public GameObject Haut;
        public GameObject Bas;
        public GameObject Gauche;
        public GameObject Droite;
        public GameObject tache;

        private Rigidbody rb;
        private Vector3 movement;
        private int lifemax;

        private void Awake()
        {
            lifemax = 8;
            StaticVariable.Life = lifemax;
            StaticVariable.Death = 0;
            StaticVariable.Win = 0;
            rb = this.GetComponent<Rigidbody>();

        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            float hAxis = Input.GetAxis("Horizontal");
            float vAxis = Input.GetAxis("Vertical");
            movement = new Vector3(hAxis, vAxis, 0) * moveSpeed * Time.deltaTime;

            explosion();

        }

        private void FixedUpdate()
        {
            rb.MovePosition(transform.position + movement);
        }

        void explosion()
        {
            //tache.GetComponent<SpriteRenderer>().sharedMaterial.color = Random.ColorHSV(0f,1f,0f,0f);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(tache, Haut.transform.position, Quaternion.identity);
                Instantiate(tache, Bas.transform.position, Quaternion.identity);
                Instantiate(tache, Gauche.transform.position, Quaternion.identity);
                Instantiate(tache, Droite.transform.position, Quaternion.identity);
                StaticVariable.Life--;
                lifeManager();
            }
        }

        void lifeManager()
        {
            if (StaticVariable.Life <= 0)
            {
                this.transform.position = spawn.transform.position;
                StaticVariable.Death++;
                StaticVariable.Life = lifemax;
            }
        }
    
    }
}
