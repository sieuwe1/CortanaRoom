# Use Cortana to control your lights, RGB ledstrips, devices and more with CortanaRoom!

## open in vs 2015 to prevent errors!

### CortanaRoom will be updated with a new gui new functions and a better tutorial soon. It will also be availible for free in the windows store!
Here are the new Gui sketches!

![alt tag](https://github.com/sieuwe1/CortanaRoom/blob/master/1-Homepage.png)
![alt tag](https://github.com/sieuwe1/CortanaRoom/blob/master/2-Help.png)
![alt tag](https://github.com/sieuwe1/CortanaRoom/blob/master/3-Settings.png)




Check the UML diagram below for a overview of the new app!

![alt tag](https://github.com/sieuwe1/CortanaRoom/blob/master/UMLCortanaRoom.png)



### ToDo
Create app
upload to store
add heater feauture

### problems
none


# Old

### A video on some of CortanaRoom's functions

https://www.youtube.com/watch?v=bN5MxCF-QB8

### 1-3-2017 There are problems with the Alarm clock function wich will make the clock not go off. Please also use a regular alarm if you want to use this function. I am working on solving the problem and will push a update when it is fixed!

### What is CortanaRoom?

CortanaRoom is an open source project to use cortana  to control your electronics by voice. This is done by an application which can be downloaded from my Github and an arduino with StandardFirmata code on it. CortanaRoom is still under development by me right now. This means that there will be more features in the future. This also means that the application may have some bugs in it. Please report them as an issue on my github page so that i can fix them!

### If you want to use CortanaRoom for yourself check out my instructable.

https://www.instructables.com/id/Use-Cortana-and-a-Arduino-for-Home-Automation-to-C/

### Features

Turn on and off 3 different lights with your voice

Turn on or off an outlet box with your voice

Use your voice to lock or unlock your room (complete support will come later)

Turn an rgb ledstrip into diffrent colors with your voice turn an rgb ledstrip into a fading effect with your voice

Use the build in alarm clock to turn your RGB ledstrip into an wake up light

Support for multiple command sorts. For example you can say "turn LED blue" or you can say "can you turn my LED on in color blue".

### schematic

![alt tag](https://github.com/sieuwe1/CortanaRoom/blob/master/20170223_224139.jpg)


### Short explenation about what is here.

First off all you can see 2 folders. 

In the folder called compiled are two already compiled versions of cortana room. Version 1 is for original arduino's or very good clone's and version 2 is for fake arduino's with the ch340 usb chip. To run one of these versions you first have to open the **Add-AppDevPackage.ps1** with the windows powershell. After following the onscreen instructions you are ready to go. To find it just type in windows search CortanaRoom.

In the folder called project is the intire visual studio project. To open it download and install visual studio 2015 and the microsoft remote arduino libarary. 

