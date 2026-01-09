# Unity Portfolio Project (Cinemachine + Coins + Hazards + Particles)

This is a starter Unity project folder with ready-to-use C# scripts for Case #5:
- Cinemachine Virtual Camera follow setup
- Bonus trigger animation (Animator state machine)
- Coins + Wallet (UI)
- Explosive barrel (destroy player on impact force)
- Moving hazards (damage player, destroy on 0 HP)
- Movement particles

## Recommended Unity version
Unity 2021.3 LTS or newer.

## Packages
1) Install **Cinemachine** via Package Manager:
   Window -> Package Manager -> Unity Registry -> Cinemachine -> Install

2) (Optional) Input System not required; scripts use classic Input.

## Quick Scene Setup (Step-by-step)
Open or create scene: `Assets/Scenes/Main.unity` (create if not present).

### 1) Player
- Create: GameObject -> 3D Object -> Capsule, name it **Player**
- Add components:
  - Rigidbody (Use Gravity = true, Freeze Rotation X/Z = true)
  - CapsuleCollider
  - **PlayerController.cs**
  - **Health.cs**
- Create empty child: **GroundCheck** (position near feet)

### 2) Ground
- Create Plane, name it Ground.

### 3) Cinemachine Follow
- GameObject -> Cinemachine -> Virtual Camera
- In Virtual Camera:
  - Follow = Player (transform)
  - LookAt = Player (transform)
- Add **CinemachineCollider** (optional) to avoid clipping
- In Main Camera ensure there is **CinemachineBrain** component (auto added).

### 4) UI Wallet
- Create: GameObject -> UI -> Canvas
- Add: UI -> Text (Legacy) (or TMP if you prefer)
- Attach **WalletUI.cs** to the Text and link Wallet instance (see below)

### 5) Wallet
- Create empty GameObject **GameManager**
- Add **Wallet.cs** component (it is a singleton-like service)

### 6) Coin
- Create Sphere (or 3D coin model), name it **Coin**
- Add Collider (Is Trigger = true)
- Add **Coin.cs** script
- Tag Player object as "Player" (or keep default and assign in scripts)

### 7) Bonus with Animator (Trigger zone)
- Create Cube, name it **Bonus**
- Add Animator component
- Create Animator Controller with parameters:
  - Bool: `IsActive`
- Create two states:
  - Idle (IsActive=false)
  - Active (IsActive=true)
- Transitions based on `IsActive`
- Add a trigger collider child (Is Trigger = true) named **BonusTrigger**
- Add **BonusTriggerAnimator.cs** on trigger object; assign Animator reference

### 8) Explosive Barrel
- Create Cylinder, name it **ExplosiveBarrel**
- Add Rigidbody, Collider
- Add **ExplosiveBarrel.cs**
- Set `KillImpactThreshold` (e.g. 8..12)

### 9) Moving Hazard
- Create Cube, name it **MovingHazard**
- Add Collider (not trigger)
- Add Rigidbody (isKinematic = true)
- Add **MovingHazard.cs** (patrol movement)
- Add **DamageOnContact.cs** (damage player)

### 10) Movement Particles
- Create Particle System, name it **MoveParticles**
- Place as child of Player, near feet
- Add **MovementParticles.cs** to player and assign ParticleSystem

## Controls
- WASD / Arrow keys: move
- Space: jump
- Esc: quit play mode (editor) / pause can be added

## Notes
This project folder is intentionally minimal: Unity will generate Library/ProjectSettings on first open.
