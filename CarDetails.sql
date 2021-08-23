---Use WorkingDB

Create table CarDetails
(
ID int IDENTITY(1,1),
CarModel varchar(50) Not Null,
CarNo Varchar(50) Not Null,
NoOfSeats int,
Primary Key (ID)
)

--select * from CarDetails

Insert into CarDetails(CarModel,CarNo,NoOfSeats)
Select 'Mahindra XUV700','TN03 012021',5
union all
select 'Mahindra Thar','TN03 022021',4
union all
select 'Tata Altroz','TN03 032021',5
union all
select 'Hyundai Creta','TN03 042021',5
union all
select 'Maruthi Swift','TN03 052021',5
union all
select 'Mahindra Bolero','TN03 062021',9
union all
select 'Tata Harrier','TN03 072021',5
union all
select 'Toyota Innova Crysta','TN03 082021',8
union all
select 'Lexus LX','TN03 092021',8
union all
select 'Mahindra Scorpio S3 2WD','TN03 102021',10