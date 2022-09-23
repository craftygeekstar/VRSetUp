using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MarkerMovement : MonoBehaviour
{
    //Controller rotation
    public GameObject controller;
    private float rotZ, rotY;
    Quaternion rotation;
    [SerializeField] private int XOffset;

    //Controller boundaries
    private Vector3 normal, lastPos;
    private Vector3 markerDir;
    [SerializeField] GameObject boundingBox;
    [SerializeField] Collider boundingBoxSize;


    void Start()
    {
        normal = -transform.forward;
    }

    void FixedUpdate()
    {

        Vector3 rayOrigin = controller.transform.position;
        Vector3 rayDir = -controller.transform.forward;
        float denominator = Vector3.Dot(rayDir, normal);

        //Keeps the object within certain boundaries of a different object
        if (denominator > 0.00001f)
        {
            float distance = Vector3.Dot(transform.position - rayOrigin, normal) / denominator;
            var collisionPoint = rayOrigin + rayDir * distance;
            float xPos = Mathf.Clamp(collisionPoint.x, boundingBox.transform.position.x - boundingBoxSize.bounds.size.x / 2, boundingBox.transform.position.x + boundingBoxSize.bounds.size.x / 2);
            float yPos = Mathf.Clamp(collisionPoint.y, boundingBox.transform.position.y - boundingBoxSize.bounds.size.y / 2, boundingBox.transform.position.y + boundingBoxSize.bounds.size.y / 2);

            transform.position = Vector3.Lerp(transform.position, new Vector3(xPos, yPos, transform.position.z), 0.4f);


            // //Clamping rotation of the hammer
            // if (controller.transform.rotation.eulerAngles.z <= 15 && controller.transform.rotation.eulerAngles.z >= 0 ||
            //     controller.transform.rotation.eulerAngles.z <= 360 && controller.transform.rotation.eulerAngles.z >= 345)
            // {
            //     rotZ = controller.transform.rotation.eulerAngles.z;
            // }
            // if (controller.transform.rotation.eulerAngles.y <= 15 && controller.transform.rotation.eulerAngles.y >= 0 ||
            //    controller.transform.rotation.eulerAngles.y <= 360 && controller.transform.rotation.eulerAngles.y >= 345)
            // {
            //     rotY = controller.transform.localRotation.eulerAngles.y;
            // }

            // //rotates hammer based on controller rotation
            // rotation = Quaternion.Euler(0, rotY * 2, rotZ + XOffset);
            // transform.rotation = rotation;

        }
        
        markerDir = transform.position - lastPos;
        lastPos = transform.position;
    }

    
}
