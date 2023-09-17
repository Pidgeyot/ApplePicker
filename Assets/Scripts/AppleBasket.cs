using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AppleBasket : MonoBehaviour {
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -9f;
    public List<GameObject> basketList;
    public Text livesText;

    void Start () {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++) {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + i;
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
       //Find and update lives
        GameObject livesGO = GameObject.Find("Lives");
        livesText = livesGO.GetComponent<Text>();
        livesText.text = "Lives: " + basketList.Count.ToString();
    }

    public void AppleMissed() {
    // Destroy all of the falling Apples
    GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tempGO in appleArray) {
            Destroy(tempGO);
        }
    
        // Destroy one of the Baskets
        // Get the index of the last Basket in basketList
        int basketIndex = basketList.Count - 1;
        // Get a reference to that Basket GameObject
        GameObject basketGO = basketList[basketIndex];
        // Remove the Basket from the list and destroy the GameObject
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);
        livesText.text = "Lives: " + basketList.Count.ToString("#,0");

        // If there are no Baskets left, restart the game
        if (basketList.Count == 0) {
            SceneManager.LoadScene("Scene_0");
        }
    }
}
