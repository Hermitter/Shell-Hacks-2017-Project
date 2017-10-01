using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour
{
    //Quaternion AddRot = Quaternion.identity;
    float roll = 0;
    float pitch = 0;
    float yaw = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //https://keithmaggio.wordpress.com/2011/07/01/unity-3d-code-snippet-flight-script/
        Quaternion AddRot = Quaternion.identity;
        pitch = MATRIX.Gyroscope.roll * (Time.deltaTime * 2);
        roll = MATRIX.Gyroscope.pitch * (Time.deltaTime * 2)*-1;
		//roll = 0;
		//pitch = 0;
		yaw = 0;
		//yaw = yawFix() * (Time.deltaTime * 2);
		//print ("Yaw: " + yawFix());
		//print("Pitch: " + pitch);
		//print ("Roll: " + roll);

        AddRot.eulerAngles = new Vector3(pitch, yaw, roll);
        transform.rotation *= AddRot;
        Vector3 AddPos = Vector3.forward*2;
        AddPos = transform.rotation * AddPos;
        GetComponent<Rigidbody>().velocity = AddPos * (Time.deltaTime * 4000.0f);//orig 2000
    }

}