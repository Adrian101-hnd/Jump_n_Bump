# Jump N Bump
## PAS Project

Jump N Bump is a platform rhythm videogame that focuses in helping percussionists to develop psycho-motor skills necessary to play instruments with precision.

The videogame has the intention to communicate how important is to protect the percussionist ears from hearing damage, caused by continuous exposition to loud sounds.

Using an equalizing algorithm, the videogame simulates how a person with hearing loss perceives the music for each level.

# Setting up the project

For each of the following points, you can choose to use the already deployed version or deploy your own.

First clone the whole repository to your computer and/or server.

## Videogame

Your computer must be running Windows 10 OS or earlier. As minimum requirements, your computer must have 2.0+ GHz Processor, 8 GB RAM, OpenGL Graphics and 1 GB of disk space.

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

In order to allow the videogame to connect with your server, change the URL in the following files from the `Assets/Scripts` folder:
- `Iniciosesion.cs`
- `Registro.cs`
- `Salud_Personaje.cs`

Then re-compile the project in Unity as described above.

## Database

### Deployed version
The web server uses this deployment. No further action is required.

### Deploying the database
The web server supports a database from SQL Server. It can be hosted locally, or in the cloud with Amazon Web Services or Azure SQL.

Once in SQL Server, just run the query from the file `jump-n-bump-database.sql`. The structure of the database will be created. Then, manually add the information of the music and the levels from the game in the corresponding tables.

Finally, change the file `db.config.js` in the `jump-n-bump-backend/config` directory to allow the server to access your database server.

## Data visualization

In order to generate data visualizations, you must have an active license of Tableau, and Tableau Desktop installed in your computer. Select connect to SQL Server and enter your access credentials. Then you can generate the views.

# How to play
Log in with your account or create it if you don't have one. The main menu has buttons to play the tutorial, and each one of the levels. You can also see the credits by pressing "Credits".

When losing an attempt or finishing a level, you will be prompted a screen with options to repeat the level or go to the main menu. Choose whichever you like.

Finally, you can close the app by selecting "Exit" in the main menu.
