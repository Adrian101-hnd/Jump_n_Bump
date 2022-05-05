# Jump N Bump
## PAS Project

Jump N Bump is a platform rhythm videogame that focuses in helping percussionists to develop psycho-motor skills necessary to play instruments with precision.

The videogame has the intention to communicate how important is to protect the percussionist ears from hearing damage, caused by continuous exposition to loud sounds.

Using an equalizing algorithm, the videogame simulates how a person with hearing loss perceives the music for each level.

# Technical requirements

For each of the following points, you can choose to use the already deployed version or deploy your own.

First clone the whole repository to your computer and/or server.

## Videogame

Your computer must be running Windows 10 OS or earlier.

### Use of compiled version
Open the file `Jump_n_Bump.exe` inside the `jump-n-bump-backend` folder.

### Compile from source code

Your computer must have installed
- Unity Hub
- Unity Editor Version 2021.2.12f1

Open the project from Unity Hub. When Unity Editor is open, navigate to the file tab and select Build Settings. Then press the Build Button.

## Web Server

### Deployed version

You can access the web server by typing `http://165.232.147.208/` into your browser. The documentation of the API is available in `http://165.232.147.208/api/docs/`. No further action is required for the videogame to connect with the server.

### Deploying the server

Your server must have an OS with Linux Kernel with admin permissions.

Your server must have installed
- Node.js
- Node Package Manager (npm)

Navigate to the `jump-n-bump-backend` folder and run the following command:

`npm install`

This will install all the required dependencies for the project.

Then run the project as a process.

`pm2 start index.js`

## Database