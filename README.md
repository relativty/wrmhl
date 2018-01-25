<h1 align="center">
  <br>
  <a href="https://github.com/relativty/wrmhl"><img src="/img/wrmhl.png" width="300"></a>
</h1>

<h4 align="center">Super fast communication between Unity and Arduino ☄ ⏱
</h4>

<p align="center">
  <img src="https://img.shields.io/github/license/relativty/wrmhl.svg">
  <img src="https://img.shields.io/github/stars/relativty/wrmhl.svg">
  <img src="https://img.shields.io/github/issues/relativty/wrmhl.svg">
</p>

<img src="/img/mpu.gif" width="1000">
<h4 align="center">Create an Arduino and Unity3D interactive experience with no latency ! ⏱
</h4>


## Don’t worry about Latency anymore, wrmhl is here ⚡️

If you have ever wanted to transmit data from Arduino to Unity3D the main issue is INSANE LATENCY. We didn’t find any free, optimized, and customizable solutions to tackle this problem. So I built **wrmhl**. You can now connect any Arduino interface to Unity3D.

- **Just write your Arduino code, how about a [A Touchless 3D Tracking Interface](https://www.youtube.com/watch?v=ikD_3Vemkf0) or a [Brain-Computer Arduino Interface](http://www.instructables.com/id/Arduino-brain-wave-reader/) ?**

- **Add a Serial print to send data from your interface to Unity3D (see [Examples](https://github.com/relativty/wrmhl/blob/master/Arduino/Arduino.ino))**

- **Import wrmhl to Unity, and voilà!**

You can use the default protocol, or implement your own without having to deal with thread just by changing [wrmhl/Assets/WRMHL/Scripts/Thread/wrmhlThread_Lines.cs](https://github.com/relativty/wrmhl/blob/master/Assets/WRMHL/Scripts/Thread/wrmhlThread_Lines.cs).


# Getting Started ⚡️
## How to Install
You can either install it using [Git](https://git-scm.com/) or direct [Download](https://github.com/relativty/wrmhl/archive/master.zip). Or from the <strong>command line</strong>:

```bash
# Clone this repository
$ git clone https://github.com/relativty/wrmhl
```

## Uploading to Arduino 🤖
Upload to the Arduino the following program:
#### Path: wrmhl/Arduino/Arduino.ino
<img src="/img/arduino-upload.gif">

## On Unity3D ! 💻
Open the project either from **wrmhl folder** or **wrmhl-master** 🌈
<img src="/img/unity-open.gif">

### Import the Package ! 📦
**Assets**, **Import Package** and **Custom Package..** and you're good to **GO !** ⚡️

<img src="/img/unity-package.gif">

### Important ! ⚠ Change the .NET 2.0 Subset to .NET 2.0 ⚠

In order to do that : Go to **Edit** ➭  Then **Project Settings** ➭ **Player**, and under **Other Settings** find an option that reads **Api Compatibility Level** and change it from **_".NET 2.0 Subset" to ".NET 2.0"._**

## Run it ! 🏁 🚗
Select **Assets/WRMHL/DemoScenes** and choose the **demo** of your choice !
<img src="/img/unity-play.gif">



<p align="center">
  <b>Don't forget to leave some feedback, contributions and suggestions are always welcome ! 🤝</b><br>
</p>


