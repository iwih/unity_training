using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerMotion : MonoBehaviour
{
    public Rigidbody RigidBody;
    public float MotionForce;
    public float SideSwayForce;
    public Camera CameraScene;
    public Vector3 CameraOffset;

    // Update is called once per frame
    void Update()
    {
        // main motion force
        RigidBody.AddForce(0, 0, 2000 * Time.deltaTime);

        // sidesway forces by controller
        if (Input.GetKey("right"))
            RigidBody.AddForce(SideSwayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        else if (Input.GetKey("left"))
            RigidBody.AddForce(-1 * SideSwayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        RigidBody.rotation.Set(0, 0, 0, 0);
        // camera location updating
        CameraScene.transform.position = RigidBody.transform.position + CameraOffset;
    }

    void OnCollisionEnter(Collision collision)
    {
        // if (collision.collider.tag == "Obstacle")
        //     this.enabled = false;
    }
}
