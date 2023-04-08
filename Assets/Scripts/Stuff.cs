using UnityEngine;

public enum StuffTypes { Good, Bad }
public class Stuff : MonoBehaviour
{
    [SerializeField] protected StuffTypes stuffType;
    protected Material[] materials;

    public StuffTypes StuffType // Encapsulation
    {
        get { return stuffType; }
    }

    protected void Start()
    {
        materials = GameManager.Instance.Materials;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (stuffType == StuffTypes.Good)
                GameManager.Instance.GameOver();
            else
                Destroy(gameObject);
        }
    }
}
