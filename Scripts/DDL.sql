create table CustomPizza
(
	CustomPizzaId int not null identity,
	CrustId int not null,
	SizeId int not null,
	ToppingsId int not null,
	OrderId int not null
);

create table [User]
(
	UserId int not null identity,
	NameId int not null,
	Email nvarchar(500) not null,
	[Password] nvarchar(500) not null,
);

create table [Order]
(
	OrderId int not null identity,
	LocationId int not null,
	[Date] date not null,
	[Time] time not null,
	UserId int not null
);

create table Crust
(
	CrustId int not null identity,
	[Name] nvarchar(50) not null,
	Price money not null
);

create table Size
(
	SizeId int not null identity,
	[Name] nvarchar(50) not null,
	Price money not null
);

create table [Name]
(
	NameId int not null identity,
	[Name] nvarchar(50) not null,
	Price money not null
);


create table Toppings
(
	ToppingsId int not null identity,
	List nvarchar(1000) not null,
	Price money not null
);

create table [Location]
(
	LocationId int not null identity,
	Street nvarchar(100) not null,
	Town nvarchar(100) not null,
	Province nvarchar(100) not null
);

create table Topping
(
	ToppingId int not null identity,
	LocationId int not null,
	[Name] nvarchar(50) not null,
	Price money not null
);

create table Recipe
(
	RecipeId int not null identity,
	CrustId int not null,
	ToppingsId int not null,
	[Name] nvarchar(50) not null,
);

create table PresetPizza
(
	PresetPizzaId int not null identity,
	RecipeId int not null,
	OrderId int not null
);
go

alter table CustomPizza 
	add constraint PK_CustomPizzaID primary key (CustomPizzaId);

alter table [User]
	add constraint PK_UserId primary key (UserId);

alter table [Order]
	add constraint PK_OrderId primary key (OrderId);

alter table Crust
	add constraint PK_CrustId primary key (CrustId);

alter table Size
	add constraint PK_SizeId primary key (SizeId);

alter table [Name]
	add constraint PK_NameId primary key (NameId);

alter table Toppings
	add constraint PK_ToppingsId primary key (ToppingsId);

alter table [Location]
	add constraint PK_LocationId primary key (LocationId);

alter table Topping
	add constraint PK_ToppingId primary key (ToppingId);

alter table Recipe
	add constraint PK_RecipeId primary key (RecipeId);

alter table PresetPizza
	add constraint PK_PresetPizzaId primary key (PresetPizzaId);
go

alter table CustomPizza
	add constraint FK_CrustId foreign key (CrustId)
	references Crust(CrustId);

alter table CustomPizza
	add constraint FK_SizeId foreign key (SizeId)
	references Size(SizeId);

alter table CustomPizza
	add constraint FK_ToppingsId foreign key (ToppingsId)
	references Toppings(ToppingsId);

alter table CustomPizza
	add constraint FK_OrderId foreign key (OrderId)
	references [Order](OrderId);

alter table [User]
	add constraint FK_NameId foreign key (NameId)
	references [Name](NameId);

alter table [Order]
	add constraint FK_LocationId foreign key (LocationId)
	references [Location](LocationId);

alter table [Order]
	add constraint FK_UserId foreign key (UserId)
	references [User](UserId);

alter table Topping
	add constraint FK_LocationId foreign key (LocationId)
	references [Location](LocationId);

alter table Recipe
	add constraint FK_ToppingsId foreign key (ToppingsId)
	references Toppings(ToppingsId);

alter table PresetPizza
	add constraint FK_RecipeId foreign key (RecipeId)
	references Recipe(RecipeId);

alter table PresetPizza
	add constraint FK_OrderId foreign key (OrderId)
	references [Order](OrderId); 
go