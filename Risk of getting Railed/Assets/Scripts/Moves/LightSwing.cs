using UnityEngine;

public class LightSwing : Move {
    public LightSwing() : base("Light Swing", 10, 0) {}

    public override bool Perform() {
        if (!base.Perform()) return false;

        Debug.Log($"Performing {this.attackName}");
        // todo perform light swing code here
        
        return true;
    }
}