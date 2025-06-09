# Traffic Light Simulator

A C# Windows Forms application that simulates a traffic light with customizable timings and event-driven transitions.

## Features

- Displays Red, Orange, and Green lights with corresponding countdown timers.
- Configurable durations for each light (Red, Orange, Green).
- Event-driven design with notifications for light changes.
- Visual feedback with color-coded images and countdown text.
- Custom user control for reusable traffic light functionality.

## Technologies

- **C#**: (.NET Framework)
- **Windows Forms**: UI components
- **Visual Studio**: IDE

## Setup

1. Clone the repository: `git clone https://github.com/Mahmoud-Elshaer-10/trafic-light-Project.git`
2. Open `trafik_light_Project.sln` in Visual Studio.
3. Build and run the project.

## Usage

- Launch the application to start the traffic light simulation.
- Observe light transitions (Red → Orange → Green → Orange → Red) with countdown timers.
- Configure light durations via properties (RedTime, OrangeTime, GreenTime).
- Event notifications display current light state via message boxes.

## Code Structure

- `ctrlTraficLight.cs`: Custom user control for traffic light logic.
  - Properties: `CurrentLight`, `RedTime`, `OrangeTime`, `GreenTime`.
  - Methods:
    - `Start()`: Initiates timer and countdown.
    - `_ChangeLight()`: Handles light transitions.
    - `Raise*LightOn()`: Triggers events for light changes.
  - Events: `RedLightOn`, `OrangeLightOn`, `GreenLightOn`.
- `Form1.cs`: Main form hosting the traffic light control and event handling.

## Notes

- Uses `Resources` for light images (Red, Orange, Green).
- Countdown timer updates via `LightTimer_Tick`.
- Enum `enLight` defines light states (Red, Orange, Green).

## Author

Mahmoud Elshaer  
[GitHub](https://github.com/Mahmoud-Elshaer-10) | [LinkedIn](https://linkedin.com/in/mahmoud-elshaer-b09b9a1a3)
