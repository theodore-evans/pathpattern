Dataset generation app in C#, inspired by Kandinsky Patterns: human-centered.ai. “Kandinsky Patterns Our Swiss-Knife for Studying Explainable-AI.” Accessed November 10, 2020. https://human-centered.ai/project/kandinsky-patterns/.

Running the script will generate the specified number of square images in .png format, where each image contains a number of white circles on a black background, with generation parameters for each image drawn from the normal distribution defined in the configuration file.

Build the docker container with build.sh

Run the app with execute.sh, providing arguments for the configuration filename (.json), the number of images to generate, and the image output directory, or without arguments to generate a sample of 10 images using sample_config.json

The app takes a configuration file with the same format as sample_config.json, where ImageSize defines the width/height of the output image, RadiusMeanDistMean defines the mean of the distribution from which the mean node radius is drawn, etc.

```
{
  "ImageSize" : 452,
  "RadiusMeanDistMean" : 25,
  "RadiusMeanDistStddev" : 0,
  "RadiusStddevDistMean": 3,
  "RadiusStddevDistStddev" : 0,
  "NodeDensityDistMean" : 0.6,
  "NodeDensityDistStddev" : 0.2,
  "ClusteringDistMean" : 0.5,
  "ClusteringDistStddev" : 0.2
}
```

See images/sample for sample output images and labels.json