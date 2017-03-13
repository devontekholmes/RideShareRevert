USE [RideShareDB]
GO

CREATE TABLE [Customer] (
	[Email] nvarchar(100) NOT NULL,
	[Password] nvarchar(100) NOT NULL,
	[Name] nvarchar (50) NOT NULL,
	[PhoneNo] nvarchar(20) NOT NULL,
	[CreditCardNo] nvarchar(30) NOT NULL,
	[XCoordinate] float NOT NULL,
	[YCoordinate] float NOT NULL,
	CONSTRAINT [PK_EmailId_Email] PRIMARY KEY CLUSTERED ([Email])
);

CREATE TABLE [Car](
	[LicensePlateNo] nvarchar(100) NOT NULL,
	[Model] nvarchar(20) NOT NULL,
	[Brand] nvarchar (20) NOT NULL
	CONSTRAINT [PK_CarId_Car] PRIMARY KEY CLUSTERED ([LicensePlateNo])
);


CREATE TABLE [Driver](
	[DriverId] int IDENTITY(1,1) NOT NULL,
	[LicensePlateNo] nvarchar(100) NOT NULL,
	[Name] nvarchar(30) NOT NULL,
	[Rating] float NOT NULL,
	CONSTRAINT [PK_DriverId_Driver] PRIMARY KEY CLUSTERED ([DriverId])
);

ALTER TABLE [Driver]
ADD CONSTRAINT [FK_Driver_LicensePlateNo] FOREIGN KEY ([LicensePlateNo]) REFERENCES [Car] ([LicensePlateNo])
;


CREATE TABLE [RideInfo](
	[DriverId] int NOT NULL,
	[Email] nvarchar(100) NOT NULL,
	[Time] DateTime UNIQUE NOT NULL,
);

ALTER TABLE [RideInfo]
ADD CONSTRAINT [FK_RideInfo_DriverId] FOREIGN KEY ([DriverId]) REFERENCES [Driver] ([DriverId])
;

ALTER TABLE [RideInfo]
ADD CONSTRAINT [FK_RideInfo_CustomerId] FOREIGN KEY ([Email]) REFERENCES [Customer] ([Email])
;

ALTER TABLE [Driver]
ADD [XCoordinate] float;

ALTER TABLE [Driver]
ADD [YCoordinate] float;

INSERT INTO [Customer] values ( 'em322609@ohio.edu', 'erik1234', 'Erik May', '440-840-8757', '1234567890123456', 0.0,0.0);
INSERT INTO [Customer] values ( 'joe@revature.com', 'joe1234', 'Joe Kirkbride', '281-330-8004', '1234567890123456', 0.0,0.0);
INSERT INTO [Customer] values ( 'lbj@mvp.com', 'lbj1234', 'Lebron James', '216-111-1111', '1234567890123456', 0.0,0.0);


INSERT INTO [Car] values ('ABC 1234', 'Accord', 'Honda');
INSERT INTO [Car] values ('ABC 3456', '911 Turbo', 'Porsche');
INSERT INTO [Car] values ('ABC 7890', 'Malibu', 'Chevy');



INSERT INTO [Driver] values ('ABC 1234', 'Jeff Gordon', 5.0);
INSERT INTO [Driver] values ('ABC 3456', 'Dale Earnhardt', 3.5);
INSERT INTO [Driver] values ('ABC 7890', 'Kyle Busch', 4.0);


SELECT * from [Car];
SELECT * from [RideInfo];


USE RideShareDB
GO
CREATE PROCEDURE GetCoordinates(@CustomerEmail nvarchar)
AS
SELECT [XCoordinate], [YCoordinate] FROM [Customer] WHERE [Email] = @CustomerEmail;

USE RideShareDB
GO
CREATE PROCEDURE GetCoordinatesDriver(@DriverId int)
AS
SELECT [XCoordinate], [YCoordinate] FROM [Driver] WHERE [DriverId] = @DriverId;


