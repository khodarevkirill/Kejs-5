## Bonus Animator Setup (State Machine)

Create Animator Controller with:
- Bool parameter: IsActive

States:
1) Idle (default)
2) Active

Transitions:
- Idle -> Active: condition IsActive == true, Has Exit Time OFF
- Active -> Idle: condition IsActive == false, Has Exit Time OFF

In Active state, add any animation you want (scale pulse, glow, rotate, etc.).
Attach BonusTriggerAnimator to the trigger collider object, and drag the Bonus object's Animator into the script field.
