use master
go
Create Database e_commerce
GO
Use e_commerce
go
Create Table Marca(
    IDMarca int not null primary key identity  (1,1),
    Descripcion varchar (100) not null
)
go

Create Table Categoria(
    IDCat int not null primary key identity  (1,1),
    Descripcion varchar (100) not null
)
go
Create Table Provedor(
    IDPro int not null primary key identity  (1,1),
    Descripcion varchar (100) not null
)
go
Create Table Productos(

    ID int not null identity ,  
    Nombre varchar(100) not null,
    Descripcion varchar(100) not null,
    Precio money not null,
    ImagenUrl varchar (100) not null,
    IDmarca int not null foreign key references Marca(IDMarca),
    IDCatergoria int not null foreign key references Categoria(IDCat),
    IDProvedor int not null foreign key references Provedor(IDPro),
)
go
select p.id, p.Nombre, p.Descripcion, p.ImagenUrl, p.Precio,m.Descripcion as DescMarca, m.IDMarca as idMarca, C.Descripcion as DescCat, C.IDCat as IdCat, pr.Descripcion as DescPro,pr.IDPro as IdPro from productos as p inner join Marca as m on m.IDMarca =p.IDmarca inner join Categoria as C on C.IDCat =p.IDCatergoria inner join Provedor as pr on pr.IDPro = p.idProvedor
insert into Categoria values ('Hombre')
insert into Marca values ('Adidas')
insert into Provedor values ('Adidas')
insert into Productos values ('Pantalon Adidas','Pantalon Deportivo',1000,'/Images/Pantalon.jpg',1,1,1)