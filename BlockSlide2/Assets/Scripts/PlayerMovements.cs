using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private float leftLimit = -10.0f;

    [SerializeField]
    private float rightLimit = 10.0f;

    [SerializeField]
    private float width = 2.0f;

    //[SerializeField]
    //private float jumpForce = 5.0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameState == GameState.GameOver) {
            return;
        }
        if (Input.GetKey(KeyCode.A)) { 
            Vector3 positionDelta = speed * Time.deltaTime * Vector3.left;
            if (transform.position.x + positionDelta.x > leftLimit + width/2) { 
                transform.position += positionDelta;
            }
        }
        if (Input.GetKey(KeyCode.D)) {
            Vector3 positionDelta = speed * Time.deltaTime * Vector3.right;
            if (transform.position.x + positionDelta.x < rightLimit - width/2) {
                transform.position += positionDelta;
            }
        }
    }


}
