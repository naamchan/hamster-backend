#/bin/sh

dotnet publish --os linux --arch x64 -c Release -p:PublishProfile=DefaultContainer
docker run -it --rm -p 9050:9000 my-awesome-container-app:1.0.0