# MikuTest

A Unity project with first-person player movement and a simple pause menu.

## Controls

| Key | Action |
|-----|--------|
| W A S D | Move |
| Mouse | Look around |
| ESC | Open / close menu |

## Setup

### Player
1. Add the `Player` script to your player GameObject
2. Add a **CharacterController** component to the same GameObject
3. Place the **Camera** as a child of the player
4. Assign the camera's Transform to the `Camera Transform` field in the Inspector

### Menu
1. Create a **Canvas** and add a **Panel** inside it
2. Add a **Quit** button inside the panel
3. Attach the `Menu` script to any GameObject and assign the panel to `Menu Panel`
4. Wire the Quit button's `OnClick` to `Menu → Quit()`

## CI/CD

This project uses [GameCI](https://game.ci) to automatically build on every push to `main`.

Builds are uploaded as GitHub Actions artifacts (Windows 64-bit).

### Required GitHub Secrets

| Secret | Description |
|--------|-------------|
| `UNITY_EMAIL` | Unity account email |
| `UNITY_PASSWORD` | Unity account password |
| `UNITY_LICENSE` | Contents of your Unity `.ulf` license file |

See [game.ci/docs/github/activation](https://game.ci/docs/github/activation) for how to generate the license file.

## Requirements

- Unity 6 or later
- Unity Input System package
