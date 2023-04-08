using UnityEngine;

public class LockedStuff : Stuff // Inheritance
{
    private bool isLocked = true;

    protected override void OnCollisionEnter(Collision collision) // Polymorphism
    {
        if (collision.gameObject.CompareTag("Ground") && isLocked)
            UnlockStuff();
        else
            base.OnCollisionEnter(collision);
    }

    private void UnlockStuff() // Abstraction
    {
        isLocked = false;
        GetComponent<Material>().color = materials[(int)stuffType].color;
    }
}
