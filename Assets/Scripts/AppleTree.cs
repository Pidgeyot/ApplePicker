using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {
    // Speed at which the AppleTree moves
    public float speed = 1f;
    
    [Header("Inscribed")]
    // Prefab for instantiating apples
    public GameObject applePrefab;

    // Prefab for instantiating evil apples
    public GameObject evilApplePrefab;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change directions
    public float changeDirChance = 0.1f;

    // Chance that the AppleTree will change speed
    public float changeSpeedChance = 0.1f;

    // Seconds between Apples instantiations
    public float appleDropDelay = 1f;

    //Chance to spawn evil apple
    public float evilAppleChance = 0.001f;

    void Start () {
        // Start dropping apples
        Invoke("DropApple", 2f );
    }

    void DropApple() {
        if(Random.value < evilAppleChance){
            GameObject evilApple = Instantiate<GameObject>(evilApplePrefab);
            evilApple.transform.position = transform.position;
        }else{
            GameObject apple = Instantiate<GameObject>(applePrefab);
            apple.transform.position = transform.position;
        }
        Invoke("DropApple", appleDropDelay);
    }


    void Update () {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Changing Direction
        if (pos.x < -leftAndRightEdge) {
        speed = Mathf.Abs(speed);   // Move right
        } else if (pos.x > leftAndRightEdge) {
        speed = -Mathf.Abs(speed);  // Move left
        }

    }

    void FixedUpdate() {
        if (Random.value < changeDirChance) {
        speed *= -1;  // Change direction
        }

        //Changing speed
        if(Random.value < changeSpeedChance){
            speed = Mathf.Abs(speed) + 1; 
        }
    }
}
