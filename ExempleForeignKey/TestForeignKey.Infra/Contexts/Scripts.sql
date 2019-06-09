Create database exempleForeignKey;

go;

create table One(
OneID int primary key identity(1,1) not null,
OneProperty01 varchar(30),
OneProperty02 varchar(30),
OneProperty03 varchar(30),
OneProperty04 varchar(30)
);

Go;


create table Many(
ManyID bigint primary key identity(1,1),
OneID int null,
ManyProperty01 varchar(30),
ManyProperty02 varchar(30),
ManyProperty03 varchar(30),
ManyProperty04 varchar(30)
);

Go;

create table ToOne(
ToOneID int primary key identity(1,1),
ManyID bigint null,
Property01 varchar(30),
Property02 varchar(30),
Property03 varchar(30),
Property04 varchar(30)
)

create table SelfOne(
SelfOneID int primary key identity(1,1),
BaseSelfOneID int null,
ManyID bigint null,
Property01 varchar(30),
Property02 varchar(30),
Property03 varchar(30),
Property04 varchar(30)
)


Go;
alter table Many
add CONSTRAINT  Many_OneId 
foreign key (OneID) references One(OneID)

Go;
alter table ToOne
add CONSTRAINT  ToOne_ManyId 
foreign key (ManyID) references Many(ManyID)
Go;


alter table SelfOne
add CONSTRAINT  SelfOne_BaseSelfOneId 
foreign key (BaseSelfOneID) references SelfOne(SelfOneID)

alter table SelfOne
add CONSTRAINT  SelfOne_ManyID
foreign key (ManyID) references Many(ManyID)