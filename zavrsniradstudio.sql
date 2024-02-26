use master;

go

drop database if exists studio;

go

create database studio;

go



use studio;

create table treneri (
sifra int not null primary key identity (1,1),
ime varchar (50) not null,
prezime varchar (50) not null,
oib char (11) not null,
iban varchar (50) not null,
telefon varchar(20)
);

create table vjezbaci (
sifra int not null primary key identity (100,1),
ime varchar (50) not null,
prezime varchar (50) not null,
telefon varchar (20),
brojupisnoglista char (4)
);

create table programi (
sifra int not null primary key identity (30,1),
naziv varchar (50) not null,
tjednasatnica int not null,
cijena decimal (18,2) not null,
trener int not null
);

create table grupe (
sifra int not null primary key identity (50,1),
termin varchar (50) not null,
program int not null,
datumpocetka datetime,
maksimalanbrojvjezbaca int not null
);

create table vjezbacixgrupe (
vjezbac int not null,
grupa int not null
);



alter table grupe add foreign key (program) references programi (sifra);

alter table vjezbacixgrupe add foreign key (vjezbac) references vjezbaci (sifra);

alter table vjezbacixgrupe add foreign key (grupa) references grupe (sifra);

alter table programi add foreign key (trener) references treneri (sifra);



insert into treneri (ime, prezime, oib, iban)
values
('Barbara', 'Breškić', 45305782234, 'HR6523600006556572968'),
('Ivana', 'Perkušić', 46031020980, 'HR9324020069981971437'),
('Jelena', 'Božić', 71469056648, 'HR4723600002746766663'),
('Petra', 'Božić', 38335175604, 'HR1223600007469986838')
;

insert into vjezbaci (ime, prezime, brojupisnoglista)
values
('Nenad', 'Rašeta', '2708'),
('Ružica', 'Šandrk','1008'),
('Blaženka','Bertić', '2905'),
('Nevenka','Vrbanjac', '2312'),
('Smiljana','Mihajlović', '0612'),

('Tena', 'P', null),
('Vlatka', 'S', null),
('Vlatka', 'G', null),
('Helena', 'Ć', null),
('Sibila', 'G', null),

('Mirta', 'S', null),
('Marina', 'B', null),
('Anita', 'P', null),
('Svjetlana', 'B', null),
('Kristaina', 'K', null),
('Jasmina', 'G', null),

('Dražena', 'V', null),
('Verica', 'Š', null),
('Aleksandra', 'V', null),
('Gordana', 'T', null),
('Ivana', 'I', null)
;



insert into programi (naziv, tjednasatnica, cijena, trener)
values
('Body&balance', 2, 30.00, 4),
('Body&breath', 3, 37.00, 1),
('PowerHour', 3, 37.00, 4),
('ExtraHour', 1, 5.00, 4),
('Umirovljenici', 2, 20.00, 1),
('Yoga', 4, 40.00, 3)
;

insert into grupe (termin, program, maksimalanbrojvjezbaca)
values
('pon/pet/16:45', 30, 6),
('pon/sri/pet/18:00', 31, 6),
('pon/sri/pet/21:15', 32, 6),
('uto/čet/9:00', 31, 6),
('uto/čet/10:30', 31, 5),
('uto/čet/16:30', 31, 6),
('uto/čet/18:00', 31, 6),
('uto/čet/19:15', 31, 6),
('uto/čet/20:30', 31, 6),
('pon/sri/pet/sub/19:30', 35, 8),
('sub/9:00', 33, 6)
;

insert into vjezbacixgrupe (vjezbac, grupa)
values
(100, 54),
(101, 54),
(102, 54),
(103, 54),
(104, 54),

(105, 51),
(106, 51),
(107, 51),
(108, 51),
(109, 51),

(110, 52),
(111, 52),
(112, 52),
(113, 52),
(114, 52),
(115, 52),

(116, 50),
(117, 50),
(118, 50),
(119, 50),
(120, 50)
;


