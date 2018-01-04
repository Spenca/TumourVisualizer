# TumourVisualizer

![alt text](https://github.com/Spenca/UnityTumourSimulator/blob/master/Screenshot.png)

## About
TumourVisualizer uses Unity to visualize data generated by a modified version of [TumourSimulator version 1.2.3](https://www2.ph.ed.ac.uk/~bwaclaw/cancer-code/), included in this repository.

## Using the visualizer
To make changes to the project, or build for other platforms, clone this repository and open the root directory in your Unity editor.

To run the Windows build, clone this repository and run the executeable located in the `BuildWindows` directory.

## Controls
While moving the mouse, click and hold the left mouse button to pan the camera, or click and hold and the right mouse button to strafe the camera. Hold the spacebar and move the mouse forwards and backwards to zoom.

## Input
The visualizer accepts the file `pointcloud_10000.pcd` as input; at the root project directory while running the Unity editor, and in the same directory as the executeable when running a build. This file is generated by TumourSimulator, and can be modified by compiling and running the code found in the `TumourSimulator_1.2.3` directory (instructions [here](https://www2.ph.ed.ac.uk/~bwaclaw/cancer-code/)).

## Future work
I'd like to experiment with changing dispersal and mutation probability values within the TumourSimulator source code, as detailed within [this](https://www.nature.com/articles/nature14971) paper. I'd also be interested in potentially modifying the visualizer to update in real time and/or have the ability to step through different states, by providing multiple outputs from TumourSimulator.
