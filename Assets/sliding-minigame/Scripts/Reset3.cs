using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset3 : MonoBehaviour {

    public Rigidbody Target, H2, H3, V2, V3;

    public void OnMouseDown()
    {
        var gameObjects = GameObject.FindGameObjectsWithTag("playerPiece");
        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }
        Instantiate(Target, new Vector3(-2f, 0.5f, 0.5f), Target.rotation);
        Instantiate(V3, new Vector3(-0.5f, 0.5f, 0.5f), V3.rotation);
        Instantiate(V3, new Vector3(2.5f, 0.5f, 1.5f), V3.rotation);
        Instantiate(V2, new Vector3(-2.5f, 0.5f, 2f), H2.rotation);
        Instantiate(V2, new Vector3(1.5f, 0.5f, -2f), H2.rotation);
        Instantiate(H2, new Vector3(-1f, 0.5f, 2.5f), H2.rotation);
        Instantiate(H3, new Vector3(1.5f, 0.5f, -0.5f), H3.rotation);
        Instantiate(H3, new Vector3(-1.5f, 0.5f, -2.5f), H3.rotation);
    }
}