using UnityEngine;

public enum StuffTypes { Good, Bad }
public class Stuff : MonoBehaviour
{
    [SerializeField] protected StuffTypes stuffType;
    protected float drag = 1;
    protected Material[] materials;

    public StuffTypes StuffType // Encapsulation
    {
        get { return stuffType; }
    }

    protected virtual void Start()
    {
        materials = GameManager.Instance.Materials;
        GetComponent<Rigidbody>().drag = drag;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (stuffType == StuffTypes.Good)
                GameManager.Instance.GameOver();

            Destroy(gameObject);
        }
    }
}
