#/bin/sh

dotnet publish --os linux --arch x64 -c Release -p:PublishProfile=DefaultContainer
docker stop server
docker cp hamster.db server:/app/hamster.db
docker run -d --rm --name server -v ./db:/app/db -p 80:80 server:1.0.0 
