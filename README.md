# COLOR-SWITCH
This is a Color Switch clone built using Unity with clean, scalable architecture and design patterns.
---

## Features
- Color Matching: Change colors and pass through obstacles matching the player’s color.
- Simple Controls: Tap to move the player upward.
- Score System: Earn points by passing through obstacles.
- High Score: Tracks the highest score achieved in the game.
- Color Trail: Particle system trail that follows the player as a bonus visual effect.
---

## Patterns Used
- MVC (Model-View-Controller) Architecture: Manages services like Player, UI, and Color Switch Spawner, ensuring a clear separation of concerns and easier maintenance.
- Service Locator Pattern: Services like Player and UI PopUps communicate via a service locator, making the system modular and flexible.
- State Machine Pattern: Manages the player color states (Purple,Red,Blue,Yellow) for seamless transitions and gameplay control.
- Generic Mono Singleton: Ensures that GameService is globally accessible with a single instance throughout the game.
- Observer Pattern: Implements Unity Actions to maintain loose coupling between systems like score updates and UI changes and Game Start/Stop.
---
## ScreenShots
