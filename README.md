
# Unity Developer XR Test - Diana Levay

This project implements a simple city with UI and physics interactions using Unity 3D.

##  Brief Description of Program

The Unity Project contains a single scene "FinalPrototype" in which the city development simulation can be run. 

This scene contains a simple UI with three different images pertaining to buildings that can be placed on the map, as well as two toggles for physics interactions.

The map is a 30x30 3D city consisting of tiles for terrain and roads, as well as some miscellaneous buildings.

The user can drag the buildings into the map, use WASD or arrow keys to tilt and spin the map, and toggle a snow effect on / off to tilt the snow off the screen. 

<img width="705" alt="Image" src="https://github.com/user-attachments/assets/58da5c29-2338-40a4-bcc0-72744e8fbe10" />

# User input
- WASD / arrows to apply different torques
- Mouse drag and drop to grab from UI and place on world
- Interactions with other buttons via mouse click

### City Development
- The city has 2 types of terrains (road and grass)
- Users can drop buildings on grass terrains only
- There are some pre-existing static buildings in the map

### UI interaction
- Simple 3 icon layout with 2D images - Apartment, House and Factory
- User can drag images with mouse and place them on their desired tile
- Two toggles - one for snow and another for physical interactions
- A button to reset the scene and one to get information on how to interact

### Transition from 2D to 3D:
- drag and drop animation
  - UI element fades out as a 3D prefab falls onto the tile with a small particle "poof" effect
  - UI element fades back in at its original position
  - Tiles change colour to showcase newly placed building
    
### Object Placement
- Initial lay of tiles using tilemap - static map for this project for simplicity
- Raycast from mouse to plane to get selected tile
- Unity's grid system is used to calculate the position of a world point on the grid and center on the closest tile 
- Array of tiles of different types (extended classes in future) that can either be locked or unlocked for placement
- 3 different house prefabs can be instantiated on the map with their specific sizes on the grid
- Placing a building on a tile will change the tile colour as well as any other tiles the building is on

<img width="773" alt="Image" src="https://github.com/user-attachments/assets/e4179cfd-e692-4422-8e14-7ae31141dda1" />

### Physical interaction
- The city can spin and be tilted using a rigidbody attached to the parent of the map to manipulate the whole city
- this object has a rigidbody attached to it, with a modified angular drag to avoid excessive dragging, the center of mass is set slightly below the object for intended effect
- There are two torques applied separately with user input
    - one spins on the Y axis, the other tilts on the X axis (different forces applied)
- due to the importance of keeping items within their grid positions, the physics matrix is set in a way that buildings ignore collisions with tiles and the parent object to ensure steady tilting and avoid unnecessary behaviours with the physics system
- Once the user toggles the physics "off", the rigidbody is set to kinematic in order to smoothly bring the position and rotation back

<img width="656" alt="Image" src="https://github.com/user-attachments/assets/4ae14f8e-a87d-4baf-b5c8-48d376236286" />

### Version Control
There are two branches for testing the UI and Physics features separately, which were merged on main for the final result.

### Known bugs:
- Neighbouring doesn't check for road tiles so house edge can overlap - easy fix on method
- No feedback on neighbouring tiles when hovering with mouse, only upon placement

### Technical Specs:
- Unity 2022.1.23f1
- URP 
- Github Desktop 
- Visual Studio

No build specifications were given for this project so the target is Windows, however some settings have been adjusted taking into account the nature of XR, such as:

- Turned off shadows
- Gamma colour space
- Basic URP post processing vignette only
- Particle physics adhering to planes and not the entire space

### Packages used
- [3D City assets](https://assetstore.unity.com/packages/3d/environments/simplepoly-city-low-poly-assets-58899)
- [Snow Particle System](https://assetstore.unity.com/packages/vfx/particles/environment/hail-particles-pack-62038) (modified to fit project)
- [Smoke Effect](assetstore.unity.com/account/assets)
- [Icons](assetstore.unity.com/account/assets) and [sprites](https://www.flaticon.com/)

3rd party assets consisting of images / 3d assets were implemented into the root project file due to project’s scale and ease of use

### From Unity
- Tilemaps (visual)
- URP
- TextMeshPro
