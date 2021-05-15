using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdMovement : MonoBehaviour
{
    public Vector3 Initial_Position;
    public int bird_speed;
    public string Scene_name;
    private bool Bird_enable_time ;
    private float Bird_wait_time;
    private void Awake()
    {
        Initial_Position = transform.position;
    }
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red; 
    }
    private void OnMouseUp()
    {
        Vector2 spring_force = Initial_Position - transform.position;
        GetComponent<SpriteRenderer>().color = Color.white;
        GetComponent<Rigidbody2D>().gravityScale = 1;
        GetComponent<Rigidbody2D>().AddForce(bird_speed * spring_force);
        Bird_enable_time = true;
    }

    private void OnMouseDrag()
    {
        Vector3 dragPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Jei point a click korbo oita pathabe
        transform.position = new Vector3(dragPosition.x, dragPosition.y);
    }

    private void Update()
    {
        if(Bird_enable_time && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.5)
        {
            Bird_wait_time += Time.deltaTime;
        }
        if (transform.position.x > 10 || transform.position.x < -10 || transform.position.y > 10 || transform.position.y < -10 
            || Bird_wait_time>2.5)
        {
            SceneManager.LoadScene(Scene_name);
        }
        
    }

   
}
