using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRB;
    [SerializeField] private float speed;
    private float limitSuperior;
    private float limitInferior;
    public int player_lives = 4;
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        SetMinMax();
    }

    public void Movimiento(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        myRB.velocity = new Vector2(0, input.y * speed);

    }
    void SetMinMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        limitInferior = -bounds.y;
        limitSuperior = bounds.y;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Candy")
        {
            CandyGenerator.instance.ManageCandy(other.gameObject.GetComponent<CandyController>(), this);
        }
        if(other.tag == "Enemy")
        {
            EnemyGenerator.instance.ManageEnemy(other.gameObject.GetComponent<EnemyController>(), this);
        }
        if(other.tag == "Power")
        {
            PowerGenerator.instance.ManagePower(other.gameObject.GetComponent<PowerController>(), this);
        }
    }
}