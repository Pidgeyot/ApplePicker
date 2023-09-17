using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour {
    public static float bottomY = -10f;

    void Update () {
        if (transform.position.y < bottomY) {
            if(this.gameObject.tag == "Apple"){
                // Get a reference to the ApplePicker component of Main Camera
                AppleBasket apScript = Camera.main.GetComponent<AppleBasket>();

                // Call the public AppleMissed() method of apScript
                apScript.AppleMissed();
            }
            Destroy(this.gameObject);
        }
    }
}

