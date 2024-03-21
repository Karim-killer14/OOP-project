using UnityEngine;

public class Heal : Move {
    public Heal() : base("Heal", 0, 00) {}

    public override bool Perform() {
        if (!base.Perform()) return false;

        Debug.Log($"Performing {this.attackName}");
        // todo healing swing code here
        
        return true;
    }
}