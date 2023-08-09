using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public CharacterController cc;
    public Transform vrCamera;
    public float angle = 20.0f;
    public float speed = 10.0f;
    public bool moveForward;
    private GameObject gun;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        gun = gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
        
    }
    public void shoot()
    {
        Debug.Log("shoot");
        StartCoroutine("Shoot");
    }
    IEnumerator Shoot()
    {
        gun.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(1f);

    }


    // Update is called once per frame
    void Update()
    {
        if (vrCamera.eulerAngles.x >= angle && vrCamera.eulerAngles.x < 90.0f)
        {
            moveForward = true;
        }
        else
        {
            moveForward = false;
        }
        if (moveForward)
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            cc.SimpleMove(speed * forward);
        }
    }
}
