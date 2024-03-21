using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    [Range (0,10)]
    [SerializeField] private float speed;
    private bool playerClick;
    private Rigidbody2D body;
    
    void Start(){
        body = GetComponent<Rigidbody2D>();
    }
    void Update(){
        if (!playerClick) return;
        MoveUsingMouse(); 
    }
    void MoveUsingMouse(){
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        // move body to mouse position
        body.MovePosition(Vector2.MoveTowards(transform.position, mousePosition, speed * 1000 * Time.deltaTime));
    }
    void OnMouseDown(){
        playerClick = true;
    }
    void OnMouseUp(){
        playerClick = false;
    }
    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Wall")){
            Debug.Log("Player hit the wall");
        }
        
    }
    
}
