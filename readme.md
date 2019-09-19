# AgroTutor API
Welcome to the AgroTutor API repository.

## Technology used

This project is built using the .NET Core 2.2 framework.
The API works with two main interfaces. An [ASP.NET Core WebAPI](https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-2.2) which is used by the app for uploading data and a [EFCore](https://docs.microsoft.com/en-us/ef/core/) interface which is currently set up to work with PostgreSQL, but can easily be configured to work with any of the other [supported database systems](https://docs.microsoft.com/en-us/ef/core/providers/). 

## Supported DAWs and development environment

Since .NET Core is open source and multi-platform there are some [options](https://docs.microsoft.com/en-us/dotnet/core/get-started?tabs=windows) available. The easiest approach is to work with [Visual Studio](https://visualstudio.microsoft.com/vs/) on Windows computers. For macOS there is [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/) available. For Linux it's recommended to use [Visual Studio Code](https://code.visualstudio.com/), which is also available on the other platforms, or any other text editor. 
Depending on your system you might need to manually install the [.NET Core 2.2 SDK](https://dotnet.microsoft.com/download)

## Prerequisites

This service relies on docker. Therefore a running docker-environment is required as well as the docker-compose software. 

## Build process

The application supports docker and uses docker-compose. The included [docker-compose.yml](./docker-compose.yml) is configured for building and publishing the image to a container registry. For running the application on your local docker installation, please replace the existing docker-compose.yml with the provided template. The docker-compose file for building references the [Dockerfile](./AgrotutorAPI.web/Dockerfile) which holds all information on the application's build process. The docker-compose template for running the application uses an already built image from the docker hub container registry and also creates a PostgreSQL database which is used for storing the data. __Please do not use this configuration as is for running the productive service!__ Make sure you define a __safely persisted__ [Volume](https://docs.docker.com/storage/volumes/) for the database and image storage and implement backup routines. Everything happening inside docker images is considered to be volatile.

## Publishing updates to the container registry

First make sure you are logged using:
```
docker login
```

Build your image(s) using:
```
docker-compose build
```
Tag the built release image(s):
```
docker tag agrotutorapiweb:latest iiasaeocs/agrotutor:12091901
```
*The existing tag (agrotutorapiweb:latest) is found in the output of the build command. *

Push the images to the container registry:
```
docker push iiasaeocs/agrotutor:12091901
```

You should in addition to the referencable build number push a tag of the build labeled 'latest' -> iiasaeocs/agrotutor:latest.

## Running the application locally
```
git clone https:\\github.com\iiasa\agrotutor-api
cd agrotutor-api
cp docker-compose.template.yml docker-compose.yml
docker-compose build
docker-compose up -d
```

This solution is mostly used for development builds. For deploying a productive service please use the [published image](https://hub.docker.com/r/iiasaeocs/agrotutor).

At IIASA we're using [docker-swarm](https://docs.docker.com/engine/swarm/) which can be easily also locally activated by running the command `docker swarm init`. This makes docker run an application called [portainer](https://www.portainer.io/) which can be accessed through port 9000. This lets you manage volumes and stacks through a Web-GUI.

However the application will be deployed, [docker-compose.template.yml](docker-compose.template.yml) can be used as a reference for configuring the application. This file can be used directly within the portainer web-gui, or with the commands listed above necessary to run the application locally. If you plan to use an existing / different database service, please just exclude the agrotutor-postgres service from the docker-compose file.


