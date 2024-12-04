# Enemy AI

## Description
If the player gets within a certain radius the enemy raycasts to check for "walls", if no "walls" (game objects on default layer) are found the enemy chases the player. If the player can't be seen for 3 or more seconds the enemy returns to its starting position. The enemy always rotates towards the player about the y-axis. 

## Interactions
* the "hit" custom function with 1 argument for damage can be used on the parent gameobject to deal damage, enemy dies at health <= 0

## Requirements
* Navmesh surface data
* All gameobjects that can block movement have a Navmesh obstacle component with carve enabled
* All gameobjects that can block vision are on the default layer
* Player transform as scene variable

## Issues
* Enemy sprite doesn't reverse color