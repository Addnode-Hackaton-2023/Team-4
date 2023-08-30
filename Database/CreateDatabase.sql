create table Town
(
	TownId int not null,
	TownName nvarchar(50) not null,
	PRIMARY KEY (TownId)
)

insert into Town
values(1,'Stockholm'),
(2,'G�teborg'),
(3,'Malm�')


create table Route 
(
	RouteId int not null,
	RouteName nvarchar(50) not null,
	TownId int not null,
	PRIMARY KEY (RouteId),
	FOREIGN KEY (TownId) REFERENCES Town(TownId)
)

insert into Route
values(1,'Stockholm f�rsta rutt',1),
(2,'Stockholm andra rutt',1),
(3,'G�teborg f�rsta rutt',2),
(4,'G�teborg andra rutt',2),
(5,'Malm�s enda rutt',3)


create table Stop 
(
	StopId int not null,
	Name nvarchar(50) not null,
	Adress nvarchar(100) not null,
	Latitude float not null,
	Longitude float not null,
	ContactPerson nvarchar(100) not null,
	ContactPhone nvarchar(100) not null,
	TownId int not null,
	PRIMARY KEY (StopId)
)

insert into Stop
values(1,'Stockholmsv�gen 1','Stockholmsv�gen 1, 182 78 Stocksund',59.385100,18.045380,'Person 1','07012345678',1),
(2,'Stockholmsv�gen 20','Stockholmsv�gen 20, 181 50 Liding�',59.385100,18.045380,'Person 1','07012345679',1),
(3,'Enhagsv�gen 24','Enhagsv�gen 24, 183 34 T�by',59.385100,18.045380,'Person 1','07012345670',1)

create table StopInRoute 
(
	StopId int not null,
	RouteId int not null,
	StopOrder int not null
	PRIMARY KEY (StopId,RouteId),
	FOREIGN KEY (RouteId) REFERENCES Route(RouteId),
	FOREIGN KEY (StopId) REFERENCES Stop(StopId)
)

insert into StopInRoute
values(1,1,1),
(2,1,1),
(3,1,1),
(2,2,1),
(1,2,1),
(3,2,1)


create table Job 
(
	JobId int not null,
	RouteId int not null,
	ETA DateTime null,
	LatestLatitude float null,
	LatestLongitude float null,
	PRIMARY KEY (JobId),
	FOREIGN KEY (RouteId) REFERENCES Route(RouteId)
)

create table JobStop 
(
	JobStopId int not null,
	JobId int not null,
	StopId int not null,
	LoadedWeight float null,
	DeviationComment nvarchar(1000) null,
	Completed bit not null DEFAULT 0
	PRIMARY KEY (JobStopId),
	FOREIGN KEY (JobId) REFERENCES Job(JobId),
	FOREIGN KEY (StopId) REFERENCES Stop(StopId)
)