# Student Service

## Description

The Student Service application  is an simple simulation of a classic student service. The system Administrator has the abillity to apply some basic actions like addition or modification on the students and courses of the faculty. On the othiser side, any other site visitor has the possibility the preview all basic inormations of any student or any course, but he can't take any actions on them.

## How to run the application ? 

First of all, make sure that your Docker Desktop App is running in the backgroud. If your don't have it u can
download it for free from [Download Docker](http:/https://www.docker.com/products/docker-desktop/ "Download Docker") and install it. After you have dont it, you have to position yourself
into the folder where the docker-compose.yaml file is located. For example, in my case it is:

	C:\Users\ico\Desktop\Zadatak\Backend
	
and open command prompt in it ( you can simply do it by double clicking in the current route in File Explorer and inputing 'cmd' ).
After the Command Prompt window opens, input: 

	docker-compose up 
	
and it will the the whole preparation for you. It Builds, (re)creates, starts, and attaches to containers for a service.
 It will check if your device has the needed extensions, plugins,
libraries , etc. and install the missing ones for you, and it will run the app after finishing. The docker-compose up command aggregates the output of each container .
 When the command exits, all containers are stopped. 
Running

	docker-compose up --

detach starts the containers in the background and leaves them running.

If there are existing containers for a service, and the service’s configuration or image was changed after the container’s creation, docker-compose up picks up the changes by stopping and recreating the containers (preserving mounted volumes). To prevent Compose from picking up changes, use the

  	no-recreate flag.

If you want to stop containers from working, you can do it by pressing the the 'q' button and control button in the same time, or simply just my closing the Command Prompt window.


## Some useful commands

	docker ps   						- List containers

	docker pull 						-Pull an image or a reposotory form a registry

	docker push  	   		    	  - Push an image or a reposotory to a registry 

	docker build               			-Build an image from a Dockerfile

	docker rename    	  			- Rename an container 


## Author Info

-Instagram https://www.instagram.com/ico.coi/