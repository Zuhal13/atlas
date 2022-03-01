using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Move : MonoBehaviour
{


    [SerializeField] private float speed;
    float worldSize;
    float doorValue;

    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("addDoor"))
        {
            Debug.Log("Bu büyüten kapı");
            doorValue = other.gameObject.GetComponent<Door>().operationValue;
            worldSize += doorValue;
            transform.DOScale((worldSize), 1);
        }

        if (other.gameObject.CompareTag("subDoor"))
        {
            Debug.Log("Bu kücülten kapı");
            doorValue = other.gameObject.GetComponent<Door>().operationValue;
            worldSize -= doorValue;
            transform.DOScale((worldSize), 1);

        }


    }
}