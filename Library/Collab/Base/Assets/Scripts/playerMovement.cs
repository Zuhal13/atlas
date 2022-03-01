using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    public List<GameObject> world = new List<GameObject>();
    public GameObject worldObject;
    public GameObject cam;
    public ParticleSystem blodEffect;
   

    public Transform parent;
    float distance = .7f;
    int doorValue;
    [Range(0, 300)] public int worldCount;

    private bool isDecrease = false;
    public bool isFinished = false;
    bool firstCircleFull = false;

    GameObject rocket;
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


}

