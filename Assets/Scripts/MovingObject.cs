using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObject : MonoBehaviour
{
    public float moveTime = 0.1f; //tiempo que dura un movimiento
    public LayerMask blockingLayer; //capa a la que pertenece

    private float movementSpeed; //velocidad de movimiento
    private BoxCollider2D boxCollider; //referencia al box collider
    private Rigidbody2D rb2D; //referencia al rigidbody

    protected virtual void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {
        movementSpeed = 1f / moveTime;

    }

    /*protected IEnumerator SmoothMovement(Vector2 end) //corutina para movimiento
    {
        float distanciaRestante = Vector2.Distance(rb2D.position, end);
        while (distanciaRestante > float.Epsilon)
        {
            Vector2 posicionNueva = Vector2.MoveTowards(rb2D.position, end, movementSpeed * Time.deltaTime);
            rb2D.MovePosition(posicionNueva);
            distanciaRestante = Vector2.Distance(rb2D.position, end);
            yield return null;
        }

        //rb2D.MovePosition(end);
    }*/

    protected IEnumerator SmoothMovement(Vector3 end)
    {
        //The object is now moving.
        //isMoving = true;

        //Calculate the remaining distance to move based on the square magnitude of the difference between current position and end parameter. 
        //Square magnitude is used instead of magnitude because it's computationally cheaper.
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

        //While that distance is greater than a very small amount (Epsilon, almost zero):
        while (sqrRemainingDistance > float.Epsilon)
        {
            //Find a new position proportionally closer to the end, based on the moveTime
            Vector3 newPostion = Vector3.MoveTowards(rb2D.position, end, movementSpeed * Time.deltaTime);

            //Call MovePosition on attached Rigidbody2D and move it to the calculated position.
            rb2D.MovePosition(newPostion);

            //Recalculate the remaining distance after moving.
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;

            //Return and loop until sqrRemainingDistance is close enough to zero to end the function
            yield return null;
        }
    }

        protected bool Move(int xDir, int yDir, out RaycastHit2D hit) //movimiento
        { 
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(xDir, yDir);
        boxCollider.enabled = false;
        hit = Physics2D.Linecast(start, end, blockingLayer);

        boxCollider.enabled = true;
        
        if (hit.transform == null)
        {
            StartCoroutine(SmoothMovement(end));
            return true;
        }
        return false;
        //StartCoroutine(SmoothMovement(end));
        //return true;
        }       

    protected abstract void OnCantMove(GameObject go);

    protected virtual void AttemptMove(int xDir, int yDir)
    {
        RaycastHit2D hit;
        bool canMove = Move(xDir, yDir, out hit);

        if (canMove) return;

        OnCantMove(hit.transform.gameObject);
    }
}