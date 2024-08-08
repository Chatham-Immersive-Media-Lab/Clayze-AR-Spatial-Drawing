## Looking Glass Drawing

Project Description

This project uses an XPPen Deco 01 drawing tablet and a Looking Glass to map a 3D space using a 2D drawing tablet and pen. It attempts to take advantage of the fact that pen drawing tablets are comfortable and familiar for virtual sketching. The user is intended to comfortably draw into a 3D space while taking a few simple creative liberties.

Hardware Requirements

Output: A Looking Glass Portrait.

Input: A drawing tablet (XPPen Deco 01 for this example).

## Set Up

Open this project in Unity editor version 2022.3.34f1 or newer.
Navigate to scenes
Drag and drop the "UI and Painting" scene into the scene builder window.
Build and Run for Windows.

Instructions

Use the tip of the drawing tablet to control the cursor on the Looking Glass. The tip controls drawing, translating, rotating, and erasing the drawn object. The barrel buttons, when pressed, open a pop-up menu. There are four orbs. White is the drawing mode, red is the translate mode, blue is the rotate mode, and green is the erase mode. In translate mode, use the pen tip to drag the most recently drawn object around the scene relative to the camera. In rotate mode, use the pen tip to drag across the Looking Glass to look at the drawn object from a different perspective. In erase mode, use the pop-up menu and press the green button to erase the canvas. There are two sets of four buttons on the drawing tablet, with the top four changing the color (black, red, blue, and yellow) and the bottom four changing the pen size (0.1, 0.2, 0.3, 0.4) where tapping one of the buttons automatically inputs the desired change.

Attributions

Forked from: https://github.com/Chathander/IMM313-Proto-2-SE---AR-Spatial-Drawing

Unity Technologies