using UnityEngine;
using UnityEngine.UI;

public class RollerRotation : MonoBehaviour
{
    public static RollerRotation instance;

    private Rigidbody roller;

    public float rotationSpeed = 7f;

    private float RotateDirection = 1f;

    public float countertowin = 12f;

    public Text Knifes ;
    void Start()
    {
        instance = this;

        roller = GetComponent<Rigidbody>();

        Knifes.text = "Knifes Left :" + countertowin.ToString();

        InvokeRepeating("Randomdirection", 12f, 5f);
    }

    void FixedUpdate()
    {
        RotateObject();
    }

    void RotateObject()
    {
        transform.Rotate(Vector3.forward, RotateDirection * rotationSpeed * Time.fixedDeltaTime);
        // roller.angularVelocity = Vector3.forward * RotateDirection * rotationSpeed * Mathf.Deg2Rad;
    }

    void Randomdirection()
    {
        RotateDirection *= -1;

    }
    public void OnCollisionEnter(Collision collision)
    {

        countertowin -= 1;
        Knifes.text = "Knifes Left :" + countertowin.ToString();
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("decrease_counter" + countertowin);
            if(countertowin == 0)
            {
              GeneralManager.instance.WinPopup();


            }


        }
    }
}
