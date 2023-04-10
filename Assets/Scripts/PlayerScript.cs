using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3;

    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * -moveSpeed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * -moveSpeed;

        transform.Translate(x, 0, z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag == "Finish")
        {
            logic.SetColor(collision.collider.gameObject, Color.green);
            logic.gameWin(transform.position);
        }
        else
        {
            if(collision.gameObject.tag != "Hit")
            {
                logic.SetColor(collision.collider.gameObject, Color.red);
                collision.gameObject.tag = "Hit";
                logic.restartGame();
            }
        }
    }
}
