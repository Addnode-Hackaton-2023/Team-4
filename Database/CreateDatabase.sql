create table Town
(
	TownId int not null,
	TownName nvarchar(50) not null,
	PRIMARY KEY (TownId)
)

insert into Town
values(1,'Stockholm'),
(2,'Göteborg'),
(3,'Malmö')


create table Route 
(
	RouteId int not null,
	RouteName nvarchar(50) not null,
	TownId int not null,
	PRIMARY KEY (RouteId),
	FOREIGN KEY (TownId) REFERENCES Town(TownId)
)

insert into Route
values(1,'Stockholm första rutt',1),
(2,'Stockholm andra rutt',1),
(3,'Göteborg första rutt',2),
(4,'Göteborg andra rutt',2),
(5,'Malmös enda rutt',3)


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
values(1,'Stockholmsvägen 1','Stockholmsvägen 1, 182 78 Stocksund',59.385100,18.045380,'Person 1','07012345678',1),
(2,'Stockholmsvägen 20','Stockholmsvägen 20, 181 50 Lidingö',59.363430,18.123540,'Person 1','07012345679',1),
(3,'Enhagsvägen 24','Enhagsvägen 24, 183 34 Täby',59.443940,18.073490,'Person 1','07012345670',1),
(4,'Sankt Eriksgatan 113','Sankt Eriksgatan 113, 113 43 Stockholm',59.346390,18.039720,'Person 1','07012345670',1),
(5,'Bibliotekstorget 2A','Bibliotekstorget 2A, 171 45 Solna',59.359510,18.001260,'Person 1','07012345670',1),
(6,'Saluvägen 10','Sveavägen 59, 113 59 STOCKHOLM ',59.3408036,18.137803,'Person 1','07012345670',1),
(7,'Sveavägen 59','Enhagsvägen 24, 183 34 Täby',59.3408036,18.0582458,'Person 1','07012345670',1),
(8,'Sibyllegatan 8','Sibyllegatan 8, 114 42 Stockholm',59.3361898, 17.944066,'Person 1','07012345670',1),
(9,'Kista Galleria','Kista Galleria, 164 91 Kista',59.4034402,18.045380,'Person 1','07012345670',1),
(10,'Landsvägen 47','Landsvägen 47, 172 65 Sundbyberg',59.3610101,17.9692108,'Person 1','07012345670',1),

select * from Stop

Sankt Göransgatan 70, 112 38 Stockholm 59.3334784, 18.0309713
Djupdalsvägen 29, 192 73 Sollentuna 59.4453632, 17.9504741
Tistelvägen 21, 191 62 Sollentuna 59.4302914, 17.9366161
Rinkebytorget 1, 163 73 Spånga 59.3833, 17.9167
Folkungagatan 51, 116 22 Stockholm 59.3144817, 18.0747498
Villmanstrandsgatan 6, 164 73 Kista 59.4129253, 17.918273
Magnus Ladulåsgatan 3, 118 65 Stockholm 59.311561584472656, 18.058460235595703
Bromstensvägen 158, 163 55 Spånga 59.3764978,17.9107051
Liljeholmstorget 44, 117 61 Stockholm 59.3100245,18.0232974
Hammarby allé 118, 120 65 Stockholm 59.3021326,18.1021281
Värmdövägen 691, 132 35 Saltsjö-Boo 59.3230065,18.2570404
Enköpingsvägen 26B, 177 45 Järfälla 59.410246,17.8624445
Årevägen 32, 162 61 Vällingby 59.3609939,17.8745624
Bussens väg 5, 122 43 Enskede 59.2850686,18.0510632
Värmevägen 1A, 177 57 Järfälla 59.4279679,17.846941

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
(2,1,2),
(3,1,3),
(4,1,4),
(5,1,5),
(6,1,6),
(7,1,7),
(8,1,8),
(9,1,9),
(10,1,10),
(10,2,1),
(9,2,2),
(8,2,3),
(7,2,4),
(6,2,5),
(5,2,6),
(4,2,7),
(3,2,8),
(2,2,9),
(1,2,10)




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