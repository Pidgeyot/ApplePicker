using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour {
    public ScoreCounter scoreCounter;

    void Start () {
        // Find a GameObject named ScoreCounter in the Scene Hierarchy
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // Get the ScoreCounter (Script) component of scoreGO
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    void Update () {
        // Get the current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;

        // The Camera's z position sets how far to push the mouse into 3D
        // If this line causes a NullReferenceException, select the Main Camera
        // in the Hierarchy and set its tag to MainCamera in the Inspector.
        mousePos2D.z = -Camera.main.transform.position.z;

        // Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Move the x position of this Basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll) {
    // Find out what hit this basket
    GameObject collidedWith = coll.gameObject;
    if (collidedWith.CompareTag("Apple")) {
        Destroy(collidedWith);
        // Increase the score
        scoreCounter.score += 100;
        HighScore.TRY_SET_HIGH_SCORE( scoreCounter.score );
    }
    
    if (collidedWith.CompareTag("EvilApple")) {
        Destroy(collidedWith);
        // Increase the score
        scoreCounter.score -= 100;
        // Get a reference to the ApplePicker component of Main Camera
        AppleBasket apScript = Camera.main.GetComponent<AppleBasket>();
        // Call the public AppleMissed() method of apScript
        apScript.AppleMissed();
    }
}

}
