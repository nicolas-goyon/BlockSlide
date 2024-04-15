using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowMovements : MonoBehaviour
{

    [SerializeField]
    private float speed = 5.0f;


    [SerializeField]
    private float destroyMark = -10.0f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < destroyMark) {
            Destroy(gameObject);
        }

        if (GameManager.gameState == GameState.GameOver) {
            return;
        }
        Vector3 positionDelta = speed * Time.deltaTime * Vector3.back;
        transform.position += positionDelta;

    }

    public void SetSpeed(float speed) {
        this.speed = speed;
    }

    public void SetDestroyMark(float destroyMark) {
        this.destroyMark = destroyMark;
    }
}
