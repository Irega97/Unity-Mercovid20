using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public float moveTime = 0.1f; //tiempo que dura un movimiento
    public LayerMask blockingLayer; //capa a la que pertenece

    private float movementSpeed; //velocidad de movimiento
    private BoxCollider2D boxCollider; //referencia al box collider
    private Rigidbody2D rb2D; //referencia al rigidbody

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        movementSpeed = 1f / moveTime;

    }

    protected IEnumerator SmoothMovement(Vector2 end) //corutina para movimiento
    {
        float distanciaRestante = Vector2.Distance(rb2D.position, end);
        while (distanciaRestante > float.Epsilon)
        {
            Vector2 posicionNueva = Vector2.MoveTowards(rb2D.position, end, movementSpeed * Time.deltaTime);
            rb2D.MovePosition(posicionNueva);
            distanciaRestante = Vector2.Distance(rb2D.position, end);
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
    }

    protected abstract void OnCantMove(GameObject go);

    protected void AttemptMove(int xDir, int yDir)
    {
        RaycastHit2D hit;
        bool canMove = Move(xDir, yDir, out hit);

        if (canMove) return;

        OnCantMove(hit.transform.gameObject);
    }
}