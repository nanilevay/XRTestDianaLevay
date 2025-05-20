
# Unity Developer Test - Diana Levay

This project implements a simple 3D city with UI and physics interactions using Unity

## Technical Specs:
- Unity 2022.1.23f1
- 

## Packages used:
- 3D City assets: 
- Snow Particle System (modified to fit):
- Icons and sprites: 

### From Unity:
- Tilemaps (visual)
- Post Processing:
- TextMeshPro

#  Brief Description of Program
- No build specifications were given for this project so the target is Windows, however some settings have been adjusted for lower taking into account the nature of XR ////////////// such as:

## World
- since no map type was specified beyond a general size, this implementation doesn't follow a specific grid. Instead, a tilemap was used to set different types of terrains in which buildings can be placed. These tiles can either be locked or

A physics raycast with layers is used in order to place objects and calculate positions on the screen / world / local cell space

- unity's grid system is used to calculate the position of a world point on the grid and center on the closest tile 

- tilemap 

Scriptable objects for the buildings to store static data:
- prefab to be placed
- name to be displayed
- size for calculations
- 

interactivity is separated from UI 

## Transition from 2D to 3D:
UI element shrinks as a 3D prefab pops up then falls onto the tile with a small particle "poof" effect


## Snow


## Physics interactions:
- the object containing the tiles and buildings is tiltable via torque forces
- this object has a rigidbody attached to it, with a modified angular drag to avoid excessive dragging

### Physics matrix
- buildings ignore collisions with tiles and the parent object to ensure steady tilting and avoid unnecessary behaviours with the 

## Unity organisation:

- add images
