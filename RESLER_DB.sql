use master
go
Create Database Resler_DB
GO
Use Resler_DB
go----------------------------Tablas----------------------------------
Create Table Marca(
    IDMarca int not null primary key identity  (1,1),
    Activo bit not null ,
    Descripcion varchar (100) not null
)
go
Create Table Categoria(
    IDCat int not null primary key identity  (1,1),
    Activo bit not null ,
    Descripcion varchar (100) not null
)
go
Create Table Provedor(
    IDPro int not null primary key identity  (1,1),
    Activo bit not null,
    Descripcion varchar (100) not null
     
)
go
Create Table Productos(
    ID int not null primary key identity (1,1),  
    Nombre varchar(100) not null,
    Descripcion varchar(100) not null,
    Precio money not null,
    ImagenUrl varchar (100) not null,
    Cantidad int not null,
    Activo bit not null ,
    IDmarca int not null foreign key references Marca(IDMarca),
    IDCatergoria int not null foreign key references Categoria(IDCat),
    IDProvedor int not null foreign key references Provedor(IDPro),
)
go
create table TipoUsuario(
  Idtipo int not null primary key identity (1,1),
  Nombre varchar (100) not null,
  Email varchar (100) not null,
  Contraseña varchar (100) not null,
  Acceso int not null,
  activo bit not null,
  )
  go
   create table Domicilio(
  IdDomicilio int not null primary key identity (1,1),
  Partido varchar (100) not null,
  Provincia varchar (100) not null,
  CodigoPostal int not null,
  Calle varchar (100) not null,
  piso int ,
  Altura int not null,
  activo bit not null,
  )
  go
create table Usuario(
   ID int not null primary key identity (1,1),  
   Nombre varchar(100) not null,
   Apellido varchar(100) not null,
   Edad int not null,
   DNI int not null,
   IdTipo int foreign key references TipoUsuario (Idtipo),
   IdDomicilio int foreign key references Domicilio(IdDomicilio),
   Activo bit not null,
   )
 go
 create table Ventas(
  Idventa int not null primary key identity (1,1),
  IdProducto int foreign key references Productos (Id),
  Cantidad int not null,
  Envio bit not null,
  fecha datetime not null,
  total money not null
  )
  go
  create table productosXventas(
  Idventa int not null foreign key references ventas (Idventa),
  Idproductos int not null foreign key references productos(ID),
  
  primary key (Idventa,Idproductos)
  )
  go
  create table ventasXusuarios(
  Idventa int not null foreign key references ventas (Idventa),
  Idusuario int not null foreign key references Usuario (ID),
  
  primary key (Idventa,Idusuario)
  )
  go
  
 
-------------------------------Producto------------------------------
go
create procedure spAgregarProducto
    
    @Nombre varchar(100),
    @Descripcion varchar(100),
    @Precio money,
    @Cantidad int,
    @ImagenUrl varchar (100),
    @IDmarca int,
    @IDCatergoria int,
    @IDProvedor int,
    @Activo bit
    
as
insert into Productos (Nombre, Descripcion, Precio,Cantidad, ImagenUrl,IDmarca,IDCatergoria,IDProvedor,Activo) Values 
(@Nombre,@Descripcion,@Precio,@Cantidad,@ImagenUrl,@IDmarca,@IDCatergoria,@IDProvedor,@Activo)
go
create procedure spModificarProducto 
    @id int,
    @Nombre varchar(100),
    @Descripcion varchar(100),
    @Cantidad int,
    @Precio money,
    @ImagenUrl varchar (100),
    @IDmarca int,
    @IDCatergoria int,
    @IDProvedor int,
    @Activo bit
as
Update Productos set Nombre=@Nombre, Descripcion=@Descripcion, ImagenURL=@ImagenURL, Precio=@Precio, IDmarca=@IDmarca,IDCatergoria=@IDCatergoria,IDProvedor=@IDProvedor, Activo=@Activo where Id=@Id
go
create procedure spEliminarProducto
  @ID int
  as
Update Productos set Activo=0 where ID=@id
go
create procedure spListarProducto
as
select p.id, p.Nombre, p.Descripcion,p.Cantidad, p.ImagenUrl, p.Precio,
m.Descripcion as DescMarca, m.IDMarca as idMarca,
 C.Descripcion as DescCat, C.IDCat as IdCat, 
 pr.Descripcion as DescPro,pr.IDPro as IdPro from productos as p 
 inner join Marca as m on m.IDMarca =p.IDmarca 
 inner join Categoria as C on C.IDCat =p.IDCatergoria
 inner join Provedor as pr on pr.IDPro = p.idProvedor where p.Activo=1
go
--------------------------SP AGREGAR--------------------------------
create procedure spAgregarMarca
    @Descripcion varchar(100)
as
insert into Marca (Descripcion,Activo) Values 
(@Descripcion,1)
go
create procedure spAgregarCategoria
    @Descripcion varchar(100)
as
insert into Categoria(Descripcion,Activo) Values 
(@Descripcion,1)
go
create procedure spAgregarProvedor
    @Descripcion varchar(100)
as
insert into Provedor(Descripcion,Activo) Values 
(@Descripcion,1)
go
create procedure spAgregarUsuario
    
    @Nombre varchar(100),
    @Apellido varchar(100),
    @Edad int,
    @DNI int,
    @IdTipo int,
    @IdDomicilio int,
    @Activo bit
    
as
insert into Usuario(Nombre,Apellido, Edad, DNI,Idtipo,IdDomicilio,Activo) Values 
(@Nombre,@Apellido,@Edad,@DNI,@Idtipo,@IdDomicilio,@Activo)
go
create procedure spAgregarTipo
   
    @Nombre varchar(100),
    @Email varchar(100),
    @Contraseña varchar(100),
    @Acceso int
as
insert into TipoUsuario (Nombre,Email,Contraseña,Acceso,activo) Values 
(@Nombre,@Email,@Contraseña,@Acceso,1)
go
create procedure spAgregarDomicilio
   
    @Provincia varchar(100),
    @Partido varchar(100),
    @Calle varchar(100),
    @CodigoPostal int ,
    @Altura int,
    @piso int
as
insert into Domicilio(Provincia,Partido,Calle,CodigoPostal,Altura,Piso,activo) Values 
(@Provincia,@Partido,@Calle,@CodigoPostal,@Altura,@Piso,1)
go
create procedure spAgregarVenta
    
  @IdProducto int,
  @Cantidad int ,
  @fecha datetime,
  @Total money
    
as
insert into Ventas(IdProducto,Cantidad,fecha,Envio,total) Values 
(@IdProducto,@Cantidad,@fecha,1,@Total)
go
create procedure spAgregarVentaxusuarios
    
    @IDusuario int,
    @IDventa int
    
as
insert into ventasXusuarios(Idusuario,Idventa) Values 
(@IDusuario,@IDventa)
go
create procedure spAgregarVentaxProductos
    
    @IDventa int ,
   @IDproductos int
    
as
insert into productosXventas(Idproductos,Idventa) Values 
(@IDproductos,@IDventa)
go
exec spAgregarProvedor 'Adidas',1
exec spAgregarCategoria 'Hombres',1
exec spAgregarMarca 'Adidas',1
exec spAgregar 'Pantalon','',1500,'/Images/Pantalon.jpg',1,1,1,1
-------------------------SP ELIMINAR--------------------------------
go
create procedure spEliminarMarca
  @id int
  as
Update Marca set Activo=0 where IDMarca=@id

go
create procedure spEliminarCategoria
  @id int
  as
Update Categoria set Activo=0 where IDCat=@id
go
create procedure spEliminaProvedor
  @id int
  as
Update Provedor set Activo=0 where IDPro=@id
go
create procedure spEliminaUsuario
  @id int
  as
Update Usuario set Activo=0 where ID=@id
go
create procedure spEliminarTipo
  @id int
  as
Update TipoUsuario set Activo=0 where Idtipo=@id
go 

create procedure spEliminarDomicilio
  @id int
  as
Update Usuario set Activo=0 where ID=@id
go
---------------------------SP MODIFICAR-----------------------------
create procedure spModificarMarca 
    @id int,
    @Descripcion varchar(100)
as
Update Marca set Descripcion=@Descripcion where IDMarca=@Id
go
create procedure spModificarCategoria 
    @id int,
    @Descripcion varchar(100)
as
Update Categoria set Descripcion=@Descripcion where IDCat=@Id
go
create procedure spModificarProvedor
    @id int,
    @Descripcion varchar(100)
as
Update Provedor set Descripcion=@Descripcion where IDPro=@Id
go
create procedure spModificarUsuario 
    @id int,
    @Nombre varchar(100),
    @Apellido varchar(100),
    @Edad int,
    @DNI int,
    @IdTipo int,
    @IdDomicilio int
as
Update Usuario set Nombre=@Nombre, Apellido=@Apellido , Edad= @Edad, DNI=@DNI, IdTipo=@IdTipo,IdDomicilio=@IdDomicilio where Id=@Id
go
create procedure spModificarTipo 
   @Nombre varchar(100),
    @Email varchar(100),
     @Contraseña varchar(100),
    @Acceso int,
    @Id int
as
Update TipoUsuario set Nombre=@Nombre,Email=@Email,Contraseña=@Contraseña, Acceso=@Acceso where Idtipo=@Id
go
create procedure spModificarDomicilio 
    @ID int,
    @Provincia varchar(100),
    @Partido varchar(100),
    @Calle varchar(100),
    @CodigoPostal int ,
    @Altura int,
    @piso int
as
Update Domicilio set Provincia=@Provincia,Partido=@Partido,Calle=@Calle,Altura=@Altura,piso=@piso,CodigoPostal=@CodigoPostal where IdDomicilio=@ID
go
----------------------------SPLISTAR--------------------------------
create procedure spListarMarca
as
select m.IDMarca,m.Descripcion from Marca as m where Activo=1
go
create procedure spListarCategoria
as
select c.IDCat,c.Descripcion from Categoria as c where Activo=1
go
create procedure spListarProvedor
as
select p.IDPro,p.Descripcion from Provedor as p where Activo=1
go
create procedure spListarUsuario
as
select u.id, u.Nombre, u.Apellido, u.Edad, u.DNI, tp.Idtipo as idTipo,tp.Email as Emailusu,tp.Contraseña as Contrausu,tp.Nombre as nombretipo ,D.Partido as ciudadusu, d.IdDomicilio as IdDomi, D.Provincia as Provusu,d.Piso,
d.Altura,d.calle as Calleusu ,d.CodigoPostal from Usuario as u 
inner join Domicilio as d on d.Iddomicilio = u.IDDomicilio
inner join TipoUsuario as tp on tp.Idtipo = u.IdTipo
go
exec spListarTipoUsu
create procedure spListarDomicilio
as
select d.IdDomicilio,d.Partido,d.Provincia,d.Calle,d.CodigoPostal,d.Altura,d.piso
 from Domicilio as d where d.Activo = 1
go
create procedure spListarTipoUsu
as
select tp.Idtipo, tp.Nombre, tp.Email, tp.Contraseña, tp.Acceso from TipoUsuario as tp
go
go
create procedure spListarVenta
as
select v.Idventa,v.Cantidad,v.Envio,v.fecha,v.total from Ventas as v
go
select * from 
go 
create procedure spListarVentaXProductos
as
select v.Idventa,v.IdProducto,P.nombre as nombrepro,v.Cantidad,m.Descripcion as nombremar,p.ImagenUrl as imagenpro,v.Envio,v.fecha,v.total from Ventas as v
inner join productosXventas as Pxv on Pxv.Idventa =v.Idventa
inner join Productos as P on P.ID =pxv.Idproductos
inner join Marca as m on m.IDMarca =P.IDmarca
go
create procedure spListarVentasxUsuarios
@Id int 
as
select v.Idventa,P.nombre as nombrepro,v.Cantidad,m.Descripcion as nombremar,p.ImagenUrl as imagenpro,v.Envio,v.fecha,v.total from Ventas as v
inner join ventasXusuarios as Vxu on Vxu.Idventa =v.Idventa
inner join productosXventas as pxv on pxv.Idventa=Vxu.Idventa
inner join Productos as p on p.ID=pxv.Idproductos
inner join Marca as m on m.IDMarca=p.IDmarca
inner join usuario as u on u.ID =vxu.Idusuario
where u.ID=@Id
go
select * from productosXventas
exec spListarVentasxUsuarios 1
delete from Usuario where ID=2
