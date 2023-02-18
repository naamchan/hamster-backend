#/bin/sh

dotnet publish --os linux --arch x64 -c Release -p:PublishProfile=DefaultContainer
docker stop server
dotnet ef database update
docker run -d --rm --name server -v ./db:/app/db -p 80:80 server:1.0.0 
