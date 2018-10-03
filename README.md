# WallpaperEngineSupervisor
This program automatically turns on/off your Wallpaper Engine depending on current type of power supply. Increase your working time on a battery by an automatic turn off of Wallpaper Engine.

##Features
* Cyclic check of the current type of power supply (you can change interval in the config file)
* Low performance losses


##Installation
If you want to run this program when the OS starts you must download [NSSM](https://nssm.cc/) to set this app as a service.

You have to type in command prompt in directory with nssm.exe:
> nssm install

It will open up the window with the configuration:
[](https://i.imgur.com/tn5oRoI.png)

You have to type here path to this application and press "Install service".


##Notes
> Application compatible with 64-bit version of Wallpaper Engine