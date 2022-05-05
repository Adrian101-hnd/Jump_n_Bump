create table Jugador(
	alias varchar(50) not null,
	fechaNacimiento date,
	nombre varchar(50) not null,
	apellido varchar(50) not null,
	genero varchar(50),
	nacionalidad varchar(50),
	password varchar(50)
);

alter table Jugador add constraint PK_Jugador primary key (alias);

create table Musica(
	idMusica int not null,
	duracionSegundos int not null,
	titulo varchar(50) not null,
	autor varchar(50) not null
);

alter table Musica add constraint PK_Musica primary key (idMusica);

create table Nivel(
	idNivel int not null,
	idMusica int not null,
	duracionNivelSegundos int not null,
);

alter table Nivel add constraint PK_Nivel primary key (idNivel);
alter table Nivel add constraint PK_Nivel_Musica
foreign key (idMusica) references Musica(idMusica);

create table Coleccionable(
	idColeccionable int not null,
	ubicacionX float not null,
	ubicacionY float not null,
	idNivel int not null
);

alter table Coleccionable add constraint PK_Coleccionable
primary key (idColeccionable);
alter table Coleccionable add constraint FK_coleccionable_Nivel
foreign key (idNivel) references Nivel(idNivel);

create table Jugador_Nivel(
	aliasJugador varchar(50) not null,
	idNivel int not null,
	puntuacion int not null,
	vidas int not null,
	id int not null
);

alter table Jugador_Nivel add constraint PK_Jugador_Nivel
primary key (id);
alter table Jugador_Nivel add constraint FK_Jugador_Nivel_Jugador
foreign key (aliasJugador) references Jugador(alias);
alter table Jugador_Nivel add constraint FK_Jugador_Nivel_Nivel
foreign key (idNivel) references Nivel(idNivel);

create table Jugador_Coleccionable(
	aliasJugador varchar(50) not null,
	idColeccionable int not null
);

alter table Jugador_Coleccionable add constraint PK_Jugador_Coleccionable
primary key (aliasJugador, idColeccionable);
alter table Jugador_Coleccionable add constraint FK_Jugador_Coleccionable_Jugador
foreign key (aliasJugador) references Jugador(alias);
alter table Jugador_Coleccionable add constraint FK_Jugador_Coleccionable_Coleccionable
foreign key (idColeccionable) references Coleccionable(idColeccionable);
