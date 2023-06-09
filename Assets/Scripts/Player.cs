using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 10;
    private float xRange = 8;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

        if (!GameManager.Instance.isGameActive)
            Die();

        KeepInBounds();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Stuff"))
        {
            if (collision.gameObject.GetComponent<Stuff>().StuffType == StuffTypes.Good &&
                (collision.gameObject.GetComponent<LockedStuff>() == null ||
                !collision.gameObject.GetComponent<LockedStuff>().IsLocked))
            {
                GameManager.Instance.AddScore(5);
                Destroy(collision.gameObject);
            }
            else
            {
                Destroy(collision.gameObject);
                Die();
            }

        }
    }
    private void Die() // Abstraction
    {
        GameManager.Instance.GameOver();
        Destroy(gameObject);
    }
    private void KeepInBounds()
    {
        if (transform.position.x > xRange)
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        else if (transform.position.x < -xRange)
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
    }
}
