using System.Collections;
using UnityEditor;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove instance;


    public float Speed = 10f;


    private Rigidbody playerbody;

    public bool stuck = false;

  
  


    void Start()
    {
        instance = this;
        playerbody = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (!stuck && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    void Jump()
    {
        playerbody.velocity = new Vector3(0, Speed, 0);
    }

    public  void OnCollisionEnter(Collision collision)
    {
              
            if (collision.gameObject.CompareTag("Roller"))
            {
                stuck = true;
                playerbody.isKinematic = true;
                transform.parent = collision.transform;
            }
        

        if (collision.gameObject.CompareTag("Player"))
        {
            GeneralManager.instance.GameOverPanel.SetActive(true);
            Debug.Log("gameOver");


        }

    }
    
}