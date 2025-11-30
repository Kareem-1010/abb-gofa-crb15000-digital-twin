# ABB GoFa CRB 15000 Digital Twin

A Unity3D-based digital twin application for controlling and visualizing the ABB GoFa CRB 15000 collaborative robot using EGM (Externally Guided Motion).

## Overview

This project implements a digital twin for the ABB GoFa CRB 15000 collaborative robotic arm, featuring real-time control and visualization capabilities. The application supports multiple control interfaces including hand gestures (via MediaPipe), voice recognition, and VR controllers, making it a versatile platform for robotic interaction research and development.

## Features

- **Real-time Robot Control**: Control the ABB GoFa CRB 15000 using EGM (Externally Guided Motion)
- **Multiple Input Methods**:
  - Hand gesture recognition (MediaPipe integration)
  - Voice command control
  - VR Controller input
  - Mouse control
- **Digital Twin Visualization**: Real-time 3D visualization of robot movements
- **Task-based Scenarios**: 
  - Pick and place operations
  - Maze navigation tasks
- **End-effector Control**: SCHUNK Co-act EGP-C 40 gripper integration
- **Cross-platform Support**: Compatible with Windows, Android, and Universal Windows Platform

## Requirements

### Software

- **Unity3D**: 2021.3.16f1 or higher (LTS recommended)
- **Visual Studio**: 2019/2022
- **ABB RobotStudio**: Latest version
- **NuGetForUnity**: For package management

### Hardware (for real robot control)

- ABB GoFa CRB 15000 robotic arm
- SCHUNK Co-act EGP-C 40 end-effector (optional)
- Network connection to robot controller

### Dependencies

- MediaPipe Unity Plugin
- Google Protocol Buffers
- Unity Input System
- High Definition Render Pipeline (HDRP)

## Installation

1. Clone the repository:
```bash
git clone https://github.com/Kareem-1010/abb-gofa-crb15000-digital-twin.git
```

2. Open the project in Unity3D (2021.3.16f1 or higher)

3. Install required NuGet packages via NuGetForUnity

4. Configure network settings in the Unity Editor:
   - For simulation: `127.0.0.1`
   - For real robot: Set IP according to your robot controller

## Network Configuration

### IP Address Settings

| Mode | Unity3D Application | Robot Controller |
|------|-------------------|------------------|
| Simulation | 127.0.0.1 | 127.0.0.1 |
| Real-World Control | 192.168.125.1 | 192.168.125.22 |

### Port Configuration

| Protocol | Port |
|----------|------|
| TCP/IP | 6061 |
| UDP/UC | 6511 |

> **WARNING**: When controlling the real robot, you may need to configure firewall settings to allow communication.

## Project Structure

```
├── Assets/
│   ├── 3D_Model/              # Robot and end-effector 3D models
│   ├── Script/
│   │   ├── ABB/               # EGM control scripts
│   │   ├── TeemuH_Experiments/ # Hand gesture recognition
│   │   ├── TeemuK_Experiments/ # Voice control
│   │   └── Waltteri_Experiments/ # Controller input
│   ├── Scenes/                # Unity scenes for different control modes
│   ├── MediaPipeUnity/        # MediaPipe integration
│   └── Prefabs/               # Reusable game objects
├── ProjectSettings/           # Unity project settings
└── Packages/                  # Package dependencies
```

## Usage

### Simulation Mode

1. Open the desired scene from `Assets/Scenes/`
2. Select the control method:
   - `TeemuH_HandRecognition`: Hand gesture control
   - `TeemuK_VoiceRecognition`: Voice command control
   - `Waltteri_Controller`: VR controller input
3. Press Play in Unity Editor

### Real Robot Control

1. Ensure the robot controller is connected to the network
2. Configure the IP address in the Unity application
3. Load the corresponding RAPID program in ABB RobotStudio
4. Start the Unity application
5. Establish connection and begin control

> **WARNING**: RobotWare version 7.6.1 or lower must be used for EGM compatibility.

## EGM (Externally Guided Motion)

This project uses ABB's EGM interface for smooth, real-time control of the robotic arm. EGM allows external applications to send position commands to the robot controller in either Joint or Cartesian space. This implementation uses Cartesian coordinates for intuitive TCP (Tool Center Point) control.

The `egm.proto` file can be found in your RobotWare installation:
```
C:\Users\<user_name>\AppData\Local\ABB Industrial IT\Robotics IT\RobotWare\RobotControl_7.6.1\utility\Template\EGM
```

## Control Modes

### Mouse Control
Simple mouse-based interface for basic robot control and testing.

## Development

This project was developed for research in human-robot interaction and digital twin technology. It demonstrates the integration of multiple control modalities with industrial robotics.

### Key Technologies

- **Unity HDRP**: High-quality graphics rendering
- **Multi-threading**: Performance optimization for real-time control
- **UDP/TCP Communication**: Low-latency robot communication
- **MediaPipe**: Real-time hand tracking
- **Protocol Buffers**: Efficient data serialization for EGM

## Contributing

Contributions are welcome! Please feel free to submit issues or pull requests.

## Acknowledgments

- ABB Robotics for the GoFa CRB 15000 platform
- SCHUNK for the Co-act EGP-C 40 gripper
- MediaPipe team for the hand tracking solution

## Contact

For questions and support, please open an issue on GitHub.

## Safety Notice

⚠️ **IMPORTANT**: When working with real robotic hardware:
- Always follow proper safety procedures
- Ensure emergency stop systems are functional
- Keep safety distances from the robot workspace
- Test in simulation before deploying to real hardware
- Follow ABB safety guidelines and local regulations
