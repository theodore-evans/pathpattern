# If you do not supply a config file name, sample config file be used with 10 images to generate

if [ $# -eq 0 ]; then
    conf="sample_config.json"
    num="10"
    imagedir="images/sample"
else
    if [$# -ne 3]; then echo "Arguments expected: config filename (.json), number of images, output directory, or <none> for sample"
    else
        conf=$1
        num=$2
        imagedir=$3
    fi
fi

# The images folder should be created in the same directory

docker run -it --rm -v $(pwd)/images:/app/images \
    -v $(pwd)/$conf:/app/config.json \
    pathpattern \
    dotnet PathPattern.dll batch config.json $num $imagedir
