using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    private AudioSource audioOpen;
    private bool isOpened;
    // Start is called before the first frame update
    void Start()
    {
        audioOpen = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if ((col.collider.tag == "Player" || col.collider.tag == "Enemy") && !isOpened)
        {
            //audioOpen.Play(0);
            if (transform.eulerAngles.z == 180 || transform.eulerAngles.z == 270)
            {
                 transform.position = new Vector3(transform.position.x + transform.localScale.x / 2, transform.position.y - transform.localScale.x / 2, transform.position.z);
            }
            else if(transform.eulerAngles.z == 0 || transform.eulerAngles.z == 90)
            {
                transform.position = new Vector3(transform.position.x - transform.localScale.x / 2, transform.position.y + transform.localScale.x / 2, transform.position.z);
            }
            isOpened = true;
            gameObject.transform.Rotate(0, 0, 90);
        }
    }
        public bool openTheDoor
    {
        get { return isOpened; }
    }
    
}
