# If you do not supply a config file name, sample config file be used

if [ $# -eq 0 ]; then
    conf="sample_config.json"
else
    conf=$1
fi

# The images folder should be created in the same directory
# provide number of images to generate as argument to this script

docker run -it --rm -v $(pwd)/images:/app/images \
    -v $(pwd)/$conf:/app/config.json \
    pathpattern \
    dotnet PathPattern.dll batch config.json $1 images
