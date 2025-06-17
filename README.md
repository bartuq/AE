# Recruitment Task

>Come up with and implement an environmental puzzle (it doesn't have to be complex) for a horror game that falls under the “one room horror” genre (you can refer to Amanda: The Adventurer, a title we previously worked on, as inspiration).
>The puzzle should focus on three main elements:
>- Swords
>- Candelabras
>- Skulls
>  
>The project includes a target scene of a single room. The player should be able to move around the scene and interact with relevant objects.
>Pay special attention to the clarity and transparency of the puzzle and the quality of the code - its readability and ease of modification in case the puzzle needs to be expanded later.
>
>Additional advantages would include:
>- Taking care of visual and sound aspects - after all, it’s a horror game (shaders, VFX, lighting, SFX)
>- Making use of packages already available in the project (UniTask, DOTween) or adding your own
>
>Submission format - public repository on GitHub (a fork is allowed).

# My Implementation
## Features
- First-person player controller on Input System with basic interactions
- State machine logic for future modification in mind
- ScriptableObject based events architecture
- ScriptableObject input reader for centralized input handling (e.g. action blocking)
- Interaction labels and messages - customizable per interaction stage
- Flexible interaction and puzzle system with stages - simply create prefabs and assign them unique IDs
- Sound manager based on keys
- Simple Inventory - items can be required or added during puzzles and interactions
- UI built with UI Toolkit
- Pause menu - Resume/Quit
- End game screen after puzzle completion

## Controls

- `W / A / S / D` – Move  
- `Mouse` – Rotate camera  
- `E` – Interact  
- `ESC` – Pause

## Puzzle (Spoiler)
The player must find a key that is hidden inside a locked wooden crate suspended from the ceiling.
Two crates are hanging in one rope - upper one is empty. The player needs to place skulls into the empty crate twice, which lowers it enough to allow the player to cut the rope using the found sword.
The crate then falls to the ground and breaks open. Inside is the key.

Optionally, there are interactions designed to guide the player’s attention, such as lighting a candelabra or hearing a whisper from a dead knight.

## Additional Info
- Unity 6000.0.41f1
- Models and textures were provided in the base project by the recruiter.
- All scripts and source code in this repository are the original work of the author Bartłomiej Puchniewicz and are protected by copyright.
No part of the code may be copied, used, distributed, or modified without explicit permission from the author.
**This repository is provided solely for review purposes related to the recruitment task.**
