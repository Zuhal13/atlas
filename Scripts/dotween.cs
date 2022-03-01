using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class dotween : MonoBehaviour
{
    public List<GameObject> world = new List<GameObject>();
    public GameObject worldObject;
    public GameObject cam;

    public Transform parent;
    int doorValue;
    [Range(0, 300)] public int worldSize;

    void Start()
    {
        DOTween.Init();
    }


    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (Input.GetKeyDown(KeyCode.Space))
        {

            transform.DOScale(5, 1);
            Debug.Log("Girdi");
        }
    }

}