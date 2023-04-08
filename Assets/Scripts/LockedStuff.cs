using UnityEngine;

public class LockedStuff : Stuff // Inheritance
{
    public bool IsLocked { get; private set; } // Encapsulation

    protected override void Start() // Polymorphism
    {
        IsLocked = true;
        base.Start();
    }

    protected override void OnCollisionEnter(Collision collision) // Polymorphism
    {
        if (collision.gameObject.CompareTag("Ground") && IsLocked)
            UnlockStuff();
        else
            base.OnCollisionEnter(collision);
    }

    private void UnlockStuff() // Abstraction
    {
        IsLocked = false;
        GetComponent<Renderer>().material = materials[(int)stuffType];
    }
}
