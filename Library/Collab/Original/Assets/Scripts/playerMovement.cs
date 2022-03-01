﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class playerMovement : MonoBehaviour
{
    public List<GameObject> world = new List<GameObject>();
    public GameObject worldObject;

    private bool isDecrease = false;
    public bool isFinished = false;
    bool firstCircleFull = false;

    private float doorValue;
    private float worldSize;

    public float speed;
    public float backForce;
    Vector3 mousePosition;
    Collider m_Collider;
    Vector3 m_Size;
   
    void Start()
    {
        //Fetch the Collider from the GameObject
        m_Collider = GetComponent<Collider>();

        //Fetch the size of the Collider volume
        m_Size = m_Collider.bounds.size;

        //Output to the console the size of the Collider volume
        Debug.Log("Collider Size : " + m_Size);

        DOTween.Init();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!isFinished)
        {
            float horizontal = 0;
            if (Input.GetMouseButtonDown(0))
            {
                mousePosition = Input.mousePosition;
            }
            if (Input.GetMouseButton(0))
            {
                horizontal = (Input.mousePosition.x - mousePosition.x) / Screen.width * 1.5f;
                mousePosition = Input.mousePosition;
            }
            backForce = Mathf.Clamp(backForce + Time.deltaTime * 3.25f, -1, 1);

            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * -speed * backForce + new Vector3(0, 0, 1) * horizontal * 5;
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -3.5f, 3.5f));
        }
        void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.gameObject.name);
            if (other.gameObject.CompareTag("addDoor"))
            {
                Debug.Log("Bu büyüten kapı");
                doorValue = other.gameObject.GetComponent<Doors>().operationValue;
                worldSize += doorValue;
                transform.DOScale((worldSize), 1);
            }

            if (other.gameObject.CompareTag("subDoor"))
            {
                Debug.Log("Bu kücülten kapı");
                doorValue = other.gameObject.GetComponent<Doors>().operationValue;
                worldSize -= doorValue;
                transform.DOScale((worldSize), 1);

            }
        }

        }


}

