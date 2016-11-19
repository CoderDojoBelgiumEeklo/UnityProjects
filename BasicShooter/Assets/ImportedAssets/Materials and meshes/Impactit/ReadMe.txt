Fully adjustable metal material with rust, dirt, scratches and opacity parameters. By using those we are able to create plenty of variations. 
Material allows you to create multiple metal variations such as: steel, chrome, copper etc. Of course every of these can be painted. 
In addition you can use your own normal map which will be used in material generation process. 
You can also use custom image with dynamically tweaked size, rotation and position.

Known issues / bugs / workarounds / upcoming features :

- When inputting normal map into substance, normal map has to be flagged as texture in Unity
- Oxidation effects exist only for metals that rust, other effects will be added in next release
- When inputing a decal with uneven size the sizes in substance have to be set according to image ratio. (Ex. when inputing image with 1024x512 size it has to be set with 2:1 ratio: 50:25, 20:10 etc. to maintain correct aspect)
- In older versions of Unity the substance procedural parameters group and their inputs can be placed incorrectly
- In next release we're planning to add more custom inputs such as roughnes/smoothness, more control over existing parameters, add missing oxidation effects and more advanced mask builder which will use several inputs to generate effects mask