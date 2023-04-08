using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 5;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Stuff"))
        {
            if (collision.gameObject.GetComponent<Stuff>().StuffType == StuffTypes.Good)
                GameManager.Instance.AddScore(5);
            else
            {
                Die(collision.gameObject);
            }

        }
    }
    private void Die(GameObject stuffToDestroy)
    {
        GameManager.Instance.GameOver();
        Destroy(stuffToDestroy.gameObject);
        Destroy(gameObject);
    }
}
