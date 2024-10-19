# COLOR-SWITCH
This is a Color Switch Game built using Unity with clean, scalable architecture and design patterns.
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
<img src="https://github.com/user-attachments/assets/6c24a121-e16c-48e2-8de4-c8cb1cf40ca6" alt="Screenshot 2024-10-19 201112" width="400" height="600" style="margin: 20px;">
&nbsp;&nbsp;&nbsp;&nbsp;
<img src="https://github.com/user-attachments/assets/510deef2-1be3-44b0-821e-e2a3a785f95f" alt="Screenshot 2024-10-19 201126" width="400" height="600">
<br><br>
<img src="https://github.com/user-attachments/assets/15960e26-0ff8-4aab-a2fa-8c1c3704e1ae" alt="Screenshot 2024-10-19 201135" width="400" height="600">


