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


Agregar columna Gastos en creditos
