using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Move : NetworkBehaviour
{
    public Camera cam;
    public float playerSense = 2f;


    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer) {
            cam.gameObject.SetActive(true);


        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer) {
            return;
        }
        float x_mov = Input.GetAxisRaw("Horizontal");
        float z_mov = Input.GetAxisRaw("Vertical");

        Vector3 x_vel = transform.right * x_mov;
        Vector3 z_vel = transform.forward * z_mov;
        Vector3 vel = (x_vel + z_vel).normalized * 4;
        Debug.Log(z_mov);
        
        transform.position = (transform.position + vel * Time.deltaTime);


        float hMove = Input.GetAxisRaw("Mouse X");
        float vMove = Input.GetAxisRaw("Mouse Y");


        transform.rotation = (transform.rotation * Quaternion.Euler(new Vector3(0, hMove, 0) * playerSense ));
        cam.transform.Rotate(new Vector3(vMove * -playerSense, 0, 0));


    }
}
