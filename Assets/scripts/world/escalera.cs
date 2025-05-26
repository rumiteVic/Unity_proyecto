using UnityEngine;

public class LadderClimb : MonoBehaviour
{
    public float climbSpeed = 3f; // Velocidad de subida
    public bool isOnLadder = false;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isOnLadder && Input.GetKey(KeyCode.UpArrow))
        {
            // Mover al personaje hacia arriba
            //transform.Translate(Vector3.up * climbSpeed * Time.deltaTime);
            rb.velocity = new Vector2(rb.velocity.x, climbSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ladder")
            {
            isOnLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            isOnLadder = false;
        }
    }
}