create table UserType (TypeId int identity(1,1) primary key,TypeName varchar(20) unique not null);
insert into UserType values('User');
select * from UserType;
create table UserDetails(UserID int identity(1,1) primary key,
						 UserName varchar(20) unique not null,
						 UserEmail varchar(50) unique not null,
						 UserPassword varchar(20) not null,
						UserConfirmPassword varchar(20) not null,
						 
						 TypeId int references UserType(TypeId) on delete cascade not null)


insert into UserDetails values ('Stella','stella123@gmail.com','Stella123','Stella123',2);
select * from UserDetails;


create table Category(categoryId int identity(1,1) primary key,
					  categoryName varchar(20) unique not null)

insert into Category(categoryName) values ('Eyeliner');
select * from Category;
create table ProductTable (ProdID int identity(1,1) primary key,
				   ProdName varchar(50) not null,
				   ProdPrice int not null check(ProdPrice>0),
				   ProdImg varchar(200) not null,
				   ProdDsc varchar(250) not null,
				   ProdQty int not null check(ProdQty>0),
				   categoryId int references Category(categoryId) on delete cascade not null )
				   
insert into ProductTable (ProdName,ProdPrice,ProdImg,ProdDsc,ProdQty,categoryId) values('Radiant Ruby',650,'Images\LipsticImages\Lipstic3.jpg','Rich color ,smooth finish,and all-day wear for your perfect pout',250,1)	
insert into ProductTable (ProdName,ProdPrice,ProdImg,ProdDsc,ProdQty,categoryId) values('Crimson Gloss',550,'Images\LipsticImages\Lipstic4.jpg','Rich color ,smooth finish,and all-day wear for your perfect pout',150,1)	
insert into ProductTable (ProdName,ProdPrice,ProdImg,ProdDsc,ProdQty,categoryId) values('Velvet Rough',1200,'Images\LipsticImages\Lipstic5.jpg','Rich color ,smooth finish,and all-day wear for your perfect pout',170,1)	
insert into ProductTable (ProdName,ProdPrice,ProdImg,ProdDsc,ProdQty,categoryId) values('Glamour Gloss',999,'Images\LipsticImages\Lipstic6.jpg','Rich color ,smooth finish,and all-day wear for your perfect pout',180,1)	
insert into ProductTable (ProdName,ProdPrice,ProdImg,ProdDsc,ProdQty,categoryId) values('Lustrous Lips',899,'Images\LipsticImages\Lipstic7.jpg','Rich color ,smooth finish,and all-day wear for your perfect pout',220,1)	
insert into ProductTable (ProdName,ProdPrice,ProdImg,ProdDsc,ProdQty,categoryId) values('Matte Muse',440,'Images\LipsticImages\Lipstic8.jpg','Rich color ,smooth finish,and all-day wear for your perfect pout',177,1)



insert into ProductTable (ProdName,ProdPrice,ProdImg,ProdDsc,ProdQty,categoryId) values('GlowFit',650,'Images\FoundationImages\Foundation1.jpg','Seamless coverage wth natural finish for flawless complexion',250,2)	
insert into ProductTable (ProdName,ProdPrice,ProdImg,ProdDsc,ProdQty,categoryId) values('PureBlend',550,'Images\FoundationImages\Foundation2.jpg','Seamless coverage wth natural finish for flawless complexion',150,2)	
insert into ProductTable (ProdName,ProdPrice,ProdImg,ProdDsc,ProdQty,categoryId) values('SilkBase',1200,'Images\FoundationImages\Foundation3.jpg','Seamless coverage wth natural finish for flawless complexion',170,2)	
insert into ProductTable (ProdName,ProdPrice,ProdImg,ProdDsc,ProdQty,categoryId) values('EvenTone',999,'Images\FoundationImages\Foundation4.jpg','Seamless coverage wth natural finish for flawless complexion',180,2)	
insert into ProductTable (ProdName,ProdPrice,ProdImg,ProdDsc,ProdQty,categoryId) values('BareGlow',899,'Images\FoundationImages\Foundation5.jpg','Seamless coverage wth natural finish for flawless complexion',220,2)	
insert into ProductTable (ProdName,ProdPrice,ProdImg,ProdDsc,ProdQty,categoryId) values('Flawless',440,'Images\FoundationImages\Foundation6.jpg','Seamless coverage wth natural finish for flawless complexion',177,2)
insert into ProductTable (ProdName,ProdPrice,ProdImg,ProdDsc,ProdQty,categoryId) values('TrueMatch',399,'Images\FoundationImages\Foundation7.jpg','Seamless coverage wth natural finish for flawless complexion',277,2)
insert into ProductTable (ProdName,ProdPrice,ProdImg,ProdDsc,ProdQty,categoryId) values('MatteSkin',440,'Images\FoundationImages\Foundation8.jpg','Seamless coverage wth natural finish for flawless complexion',400,2)


insert into ProductTable (ProdName,ProdPrice,ProdImg,ProdDsc,ProdQty,categoryId) values('LinePro',200,'Images\EyelinerImages\Eyeliner1.jpg','Sharp ,bold lines for effortless,all-day definition',250,3)	
insert into ProductTable (ProdName,ProdPrice,ProdImg,ProdDsc,ProdQty,categoryId) values('Edge',300,'Images\EyelinerImages\Eyeliner2.jpg','Sharp ,bold lines for effortless,all-day definition',150,3)	
insert into ProductTable (ProdName,ProdPrice,ProdImg,ProdDsc,ProdQty,categoryId) values('Flick',350,'Images\EyelinerImages\Eyeliner3.jpg','Sharp ,bold lines for effortless,all-day definition',170,3)	
insert into ProductTable (ProdName,ProdPrice,ProdImg,ProdDsc,ProdQty,categoryId) values('Bold',550,'Images\EyelinerImages\Eyeliner4.jpg','Sharp ,bold lines for effortless,all-day definition',180,3)	
insert into ProductTable (ProdName,ProdPrice,ProdImg,ProdDsc,ProdQty,categoryId) values('Precison',120,'Images\EyelinerImages\Eyeliner5.jpg','Sharp ,bold lines for effortless,all-day definition',220,3)	
insert into ProductTable (ProdName,ProdPrice,ProdImg,ProdDsc,ProdQty,categoryId) values('JettLine',50,'Images\EyelinerImages\Eyeliner6.jpg','Sharp ,bold lines for effortless,all-day definition',177,3)
insert into ProductTable (ProdName,ProdPrice,ProdImg,ProdDsc,ProdQty,categoryId) values('Define',410,'Images\EyelinerImages\Eyeliner7.jpg','Sharp ,bold lines for effortless,all-day definition',277,3)
insert into ProductTable (ProdName,ProdPrice,ProdImg,ProdDsc,ProdQty,categoryId) values('Glide',440,'Images\EyelinerImages\Eyeliner8.jpg','Sharp ,bold lines for effortless,all-day definition',400,3)

UPDATE ProductTable
SET ProdImg='Images\EyelinerImages\Eyeliner8.jpg'
WHERE ProdID = 24;

create table Cart(CartID int identity(1,1) primary key,
				  UserID int references UserDetails(UserID) on delete cascade not null,
				  ProdID int references ProductTable(ProdID) on delete cascade not null,
				  CartQty int not null check(CartQty>0),
				  Price int not null check(Price>0))

create table Bill(BillID int identity(1,1) primary key,
				  UserID int references UserDetails(UserID) on delete cascade not null)
create table BillDetails(BillDetailsID int identity(1,1) primary key,
						 BillID int references Bill(BillID) on delete cascade not null,
						 ProdID int references ProductTable(ProdID) on delete cascade not null,
						 BillQty int not null check(BillQty>0),BillAmt int not null check(BillAmt>0))	;

select * from Cart;
select * from Bill;
select * from BillDetails;
delete from Bill where BillID>=13
delete from Cart  where CartID>=21;
delete from BillDetails where BillDetailsID=4;

select * from ProductTable;