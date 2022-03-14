Create Database [Car Rental Systems]

create table Cars(
 RegNum varchar(50) primary key Not null,
 Brand varchar(50) Not null,
 Model varchar(50) not null,
 Price varchar(50) not null,
 Avialable varchar(50) not null,);

 create table Customer(
C_id int primary key Not null,
 Cname varchar(50) Not null,
 C_address varchar(50) not null,
 C_phone varchar(50) not null,);


 create table Rental(
 Rental_id int primary key Not null,
 CarReg varchar(50) Not null,
 [Customer ID] varchar(50) not null,
 [Customer Name] varchar(50) not null,
 [Rental Date] date not null,
 [Return Date] date not null,
 fee varchar(50) Not null,);
 
  create table [ReturnCar](
 ReturnID int primary key Not null,
 CarID varchar(50) Not null,
 CusName varchar(50) not null,
 ReturnDate date not null,
 [Delay] varchar(50) ,
 Fine varchar(50),);

 
  create table [UserTb](
ID int primary key Not null,
 Uname varchar(50) Not null,
Upassword varchar(50) not null,
UserType varchar(50) not null,);

select * from UserTb where UserType='Admin';

select * from UserTb where Uname='ali' and Upassword='ali' and UserType='Admin';






