Create Table Salida_Tienda(
id_salida int(11) not null,
id_vende int(11),
fecha datetime,
estado varchar(50),
primary key (id_salida)
);

alter table salida_tienda(
add constraint ´Sal_tienda_vende´ foreign key (id_vende) references vendedor(id_vendedor)
)

Create table Salida_Detalle(
id_detalle int(11) not null,
id_salida int(11),
id_prod varchar(50),
Cantidad int(11),
Precio decimal(12,2),
Total decimal(12,2),
primary key (id_detalle)
);
alter table salida_detalle
add Constraint ´salida_cons´ foreign key (id_salida) references Salida_Tienda(id_salida) on delete cascade restrict,
add constraint ´identi_prod´ foreign key (id_Prod) references Producto(id_prod) on delete cascade restrict


/*Agregar columna Gastos en credito*/

create table Bitacora
(
id_bita int(11) not null,
fecha datetime,
id_vende int (11),
id_prod varchar(50),
id_venta  int(11),
operacion varchar(40),
detalle varchar(150),
primary key (id_bita)
);
alter table bitacora
add constraint ´bita_vende´ foreign key (id_vende) references vendedor(id_vendedor) on delete cascade restrict,
add constraint ´bita_producto´ foreign key (id_prod) references producto(id_prod) on delete cascade restrict,
add constraint ´bita_venta´ foreign key (id_venta) references vendedor(id_venta) on delete cascade restrict









