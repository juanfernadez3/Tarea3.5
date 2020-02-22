drop database InscripcionesDB1
use InscripcionesDB

create table Estudiantes
(
	EstudianteId int primary key identity,
	Nombre varchar(50),
	Cedula varchar(50),
	Telefono varchar(15),
	Direccion varchar(50),
	FechaNacimiento datetime,
	Balance decimal
);
select * from Estudiantes;


create table Inscripciones
(
	InscripcionId int primary key identity,
	Fecha datetime,
	EstudianteID int,
	Comentario varchar(100),
	Monto decimal,
	Balance decimal
);

alter table Inscripciones add constraint Fk_EstudianteId 
foreign key(EstudianteID) References Estudiantes(EstudianteId)
on update cascade on Delete cascade

select * from Inscripciones;