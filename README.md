
# Unity Developer XR Test - Diana Levay

This project implements a simple city with UI and physics interactions using Unity 3D.

##  Brief Description of Program

The Unity Project contains a single scene "FinalPrototype" in which the city development simulation can be run. 

This scene contains a simple UI with three different images pertaining to buildings that can be placed on the map, as well as two toggles for physics interactions.

The map is a 30x30 3D city consisting of tiles for terrain and roads, as well as some miscellaneous buildings.

The user can drag the buildings into the map, use WASD or arrow keys to tilt and spin the map, and toggle a snow effect on / off to tilt the snow off the screen. 

UPDATING

## Technical Specs:
- Unity 2022.1.23f1
- URP 
- Github Desktop 
- Visual Studio

## Known bugs:
- neighbouring doesn't check for road tiles so house edge can overlap - easy fix on method
- no feedback on neighbouring tiles when hovering with mouse, only upon placement

## Technical Specs:
- Unity 2022.1.23f1
- URP 
- Github Desktop 
- Visual Studio

No build specifications were given for this project so the target is Windows, however some settings have been adjusted taking into account the nature of XR, such as:

- Turned off shadows
- Gamma colour space
- Basic URP post processing vignette only
- Particle physics adhering to planes and not the entire space

## Version Control
There are two branches for testing the UI and Physics features separately, which were merged on main for the final result.

## Packages used
- [3D City assets](https://assetstore.unity.com/packages/3d/environments/simplepoly-city-low-poly-assets-58899)
- [Snow Particle System](https://assetstore.unity.com/packages/vfx/particles/environment/hail-particles-pack-62038) (modified to fit project)
- [Smoke Effect](assetstore.unity.com/account/assets)
- [Icons](assetstore.unity.com/account/assets) and [sprites](https://www.flaticon.com/)

3rd party assets consisting of images / 3d assets were implemented into the root project file due to project’s scale and ease of use

### From Unity
- Tilemaps (visual)
- URP
- TextMeshPro
