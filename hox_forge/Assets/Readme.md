
## AR|VR Toolkit 1.2.0


### What is the Forge AR|VR Toolkit?

You have design data in Forge.

You have people – customers, prospects, employees, contractors – who desperately want to see and work with those designs in virtual and augmented reality.

 * Designers need to collaborate, and experiencing a design together virtually may let them solve hard problems more easily, even though they may be halfway across the globe.
 * Potential clients may understand their options best when immersed in the design.
 * Professionals in the field can work safer, faster, and better when the BIM data is at their fingertips, in context of the real world.
 * Or maybe you have a truly new idea for an AR|VR experience that will revolutionize the way you or your customers design and build.

Whatever the application, if you’ve already tried creating those kinds of innovative, immersive experiences around Forge data, you’ve probably hit some roadblocks along the way. 

Bringing design data into real-time interactive engines often involves a clunky, off-line data preparation process, which is a problem:

 * It’s often manual. You need people to carry out these conversion steps, tweak the data appropriately, and make decisions along the way. This usually also means that the process is slow.
 * It’s expensive, since you need people with special expertise in visualization tools and optimizing data for real-time use.
 * It’s one-way. If you make a ton of changes in data prep, what happens when the original design data needs to change upstream? Often all that work tweaking the data is lost.

And all that is before you even get started having to design and implement the ways that people will experience and work with that design data inside your interactive engine.

If this sounds like you, well we have some good news! We’ve been working with customers just like you to help build AR and VR experiences on top of design data – architecture, engineering, construction, manufacturing, and more. Like you, we’re still learning the rules and exploring the possibilities of these disruptive new technologies. But now we’re ready to take steps toward helping you figure out what the answer to that big question mark above should look like for your own organization.


### API definition
https://app.swaggerhub.com/apis/cyrillef/forge-ar_kit/1.1.0


### Installation and Usage of the companion scripts

Windows user, see Windows special setup instructions below first.

  1. Make sure cURL is installed in your system; if not, please refer to the
     [cURL releases and downloads](http://curl.haxx.se/download.html).
  2. Check that cURL is running in a Terminal window:<br />
     ```
     curl -V
     ```
  3. Install JQ [manually](https://stedolan.github.io/jq/download/) or using brew
     ```
     brew install jq
     ```

#### Windows special setup instructions

This sample was tested on Windows with the [git for windows](http://git-for-windows.github.io/) package.
It provides a nice terminal windows running Bash v4.3 and cUrl v7.51 already installed.

  1. Go to [http://git-for-windows.github.io/](http://git-for-windows.github.io/) and install the package.
     Select the default options.
  2. Go to [https://stedolan.github.io/jq/download/](https://stedolan.github.io/jq/download/), install JQ,
     and rename it to jq.
  3. Start the 'Git Bash' Terminal window from the Desktop icon, or a shortcut running this command
     ``` "C:\Program Files\Git\git-bash.exe" --cd-to-home ```
  4. You can now continue with the standard setup instructions above.

#### Script Usage

Before using any of the AR|VR Toolkit API, you need to upload and translate your file using the Forge Model Derivative API.
https://developer.autodesk.com/en/docs/model-derivative/v2/tutorials/prepare-file-for-viewer/

A typical worflow using 2 legged authorization is as follow:
 - get an authorization code
 - create bucket if one does not yet exist
 - upload the model on Autodesk Forge
 - use the Model Derivative API to translate the file

Once this is done, you can create as many AR|VR scenes you want without to have to repeat the steps above.

A typical workflow to prepare an AR|VR scene is as follow:
 - post a scene definition on the AR|VR server
 - process the scene

Once this is done, you can connect to the AR|VR scene from any system (including Unity) to get your scene.
The 'test-2legged' script does all the steps above, and takes one single argument.

```
test-2legged "~/cyrille/Urban House.rvt"
```

This command will upload the file, and translate it on Forge. Then it creates a default scens named 'scene' which
contains all the model.


#### Release updates

2017-12-21
 * Bugfix: (server) 503 error fix after the outage which happened on Dec 6th
 * Bugfix: (server) Reduced instanceTree was not processed properly for non graphical nodes
 * Bugfix: (Unity) Loading material error on Daqri and iOS system; theses systems needs shaders to be included in their respective builds
   (GraphicsSettings: Always Include "Standard” and “Standard (Specular setup)” shaders)
   (Include shaders with material in the Resources folder, and/or include object with material references into the scene)
 * Bugfix: (scripts) base64 bash command implicit -w0 argument on MacOS
 * Bugfix: (Unity) temporary remove qrcode and camera code from the plugin - this cause problems on UWP platforms
 * Bugfix: (Unity) Default values were not set for textures unless specified in the material definition
 * Bugfix: (Unity) Metadata (Properties) are requested for each transform nodes vs mesh
 * Bugfix: (Unity) Transform nodes are renamed with their "name" Property in the Unity Hierarchy tree
 * Bugfix: (Unity) LoaderEngine::Load method is now protected

 * Enhancement: (Unity) Properties requests are deferred in the loading order
 * Enhancement: (Unity) Loading Properties & Meshes are now optional
	
 * New: (scripts) Added a test-prep-scene which takes a single URN as parameter to post and process an ARKit scene
 * New: (scripts) Support for Windows platform
 * New: (scripts) Instructions to install/use scripts on all platforms (Linux, Windows, and MacOS)


2017-11-30
 * Bugfix: (Unity) redefine the upVector from the metadata - the previous version was always assuming Z up vector whereas Unity uses Y
 * Bugfix: (Unity) malformed mesh UV was causing issue on the Unity engine
 * Bugfix: (Unity) HTTP error on getting the instanceTree was causing multiple scene objects to be created
 * Bugfix: (Unity) WSA support was missing couple of #using to get the code to compile properly
 * Bugfix: (Unity) Malformed Metadata (ForgeProperties) were not displayed properly in the Unity Editor

 * New: (Unity) UnityEvent on the ForgeLoader class
 * New: (Unity) Added 3 basic samples using the API from the game engine

