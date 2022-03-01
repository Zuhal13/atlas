using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class playerMovement : MonoBehaviour
{

    public float speed;
    public float backForce;
    Vector3 mousePosition;
    Collider m_Collider;
    Vector3 m_Size;
    public bool isFinished;
   
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

    }
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.CompareTag("addDoor"))
        {
            transform.DOScale(5, 1);
            Debug.Log("Girdi");
        }

        if (collision.gameObject.tag == "subDoor")
        {
            transform.DOScale(new Vector3(1, 1, 1), 1);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }

}

