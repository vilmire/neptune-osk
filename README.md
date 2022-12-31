# Neptune-osk
Using Windows OSK with Steamdeck Touchpad

## Usage
1. Download the release file. https://github.com/vilmire/neptune-osk/releases
2. Run neptune-osk.exe
3. Set up your configuration and enjoy!

## Setting Description 
1. OSK Transparent - windows OSK transparent (The Windows OSK is top-most and the z-order cannot be overridden. So I made it transparent.)
2. OverlabPercentage - The Steamdeck keyboard has an overlap area
3. Offset_Y - Add pointer Offset to Y (optional, i only use 0)
4. ToggleShortCut - Define OSK ShortCut combinations. (SteamOS Default is BtnSteam + BtnX)
5. Button ShortCut - 
You can add a simple click binding. Select desire button and click Add ShortcutClick. Aim mouse cursor to desire point.(I added backspace and languageSwap buttons)
WARNING - Y, B, R2, L2, Menu, Arrows and several keys are already bound at the driver level. So don't bind them.
6. Save - Save current Setting.(most important)

## Todo
1. ui improvement(not using winform)
2. fix some bug


## Resources used
https://github.com/mKenfenheuer/neptune-hidapi.net
https://github.com/mKenfenheuer/hidapi.net
https://github.com/AlexeiScherbakov/osklib
