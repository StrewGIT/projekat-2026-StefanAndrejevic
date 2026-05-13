create database Igraonica
use Igraonica
create table Korisnik(
	id int primary key identity(1,1),
	ime nvarchar(50) not null,
	email nvarchar(60) not null,
	lozinka nvarchar(50) not null,
	administrator bit not null
)
create table TipMesta(
	id int primary key identity(1,1),
	cena int,
	naziv nvarchar(50)
)
create table Mesto(
	id int primary key identity(1,1),
	tip int foreign key references TipMesta(id) on delete cascade
)
create table RadniDan(
	id int primary key identity(1,1),
	datum date not null,
	pocetak time(0) not null,
	kraj time(0) not null,
	duzina_termina time(0)
)
create table Rezervacija(
	id int primary key identity(1,1),
	korisnik int foreign key references Korisnik(id) on delete cascade,
	radni_dan int foreign key references RadniDan(id) on delete cascade,
	termin_pocetak time not null,
	termin_kraj time not null,
	mesto int foreign key references Mesto(id) on delete cascade
)
go
create table Artikal(
id int primary key identity(1,1),
naziv nvarchar(50),
kolicina int,
cena int,
)
go

create table Racun(
id int primary key identity(1,1),
korisnik int foreign key references Korisnik(id)
)

CREATE TABLE RacunArtikal (
    id          int PRIMARY KEY IDENTITY(1,1),
    racun       int NOT NULL FOREIGN KEY REFERENCES Racun(id) ON DELETE CASCADE,
    artikal     int NOT NULL FOREIGN KEY REFERENCES Artikal(id) ON DELETE CASCADE,
    kolicina    int NOT NULL DEFAULT 1
);
go
create table Racun_Rezervacija(
id int primary key identity(1,1),
racun int foreign key references Racun(id) ON DELETE CASCADE,
rezervacija int foreign key references Rezervacija(id) ON DELETE CASCADE)
/*/////////////////////////////////////////////////////////////////////////////////// KORISNIK */

go
Create Procedure Provera_Korisnika @email nvarchar(50),@lozinka nvarchar(100) 
as
	Set lock_timeout 3000;
	Begin Try
		If exists(Select top 1 email from Korisnik where email=@email and lozinka=@lozinka)
		Begin
			Return 0;
		End
			Return 1;
	End Try
	Begin Catch
		Return @@error;
	End Catch
go

go
Create Procedure Unos_Korisnika @ime nvarchar(50),@email nvarchar(50),@lozinka nvarchar(50) 
as
	Set lock_timeout 3000;
	Begin Try
		if(exists(Select top 1 email from Korisnik where email=@email))
			Begin
				Return 1;
			end
			Else 
			Begin
				Insert Into Korisnik(ime,email,lozinka,administrator) values(@ime,@email,@lozinka,0);
				Return 0;
			end
	End Try
	Begin Catch
		Return @@error;
	End Catch
go

go
Create Procedure Brisanje_Korisnika @email nvarchar(50)
as
	Set lock_timeout 3000;
	Begin Try
			Delete from Korisnik where email=@email;
			Return 1;
	End Try
	Begin Catch
		Return @@error;
	End Catch
go

Create Procedure Izmena_Korisnika @email nvarchar(50),@lozinka nvarchar(100)
as
	Set lock_timeout 3000;
	Begin Try
		if(exists(Select top 1 email from Korisnik where email=@email))
			Begin
				Update Korisnik set lozinka=@lozinka where email=@email;
				Return 1;
			end
	End Try
	Begin Catch
		Return @@error;
	End Catch
go
/*/////////////////////////////////////////////////////////////////////////////////// TIP MESTA */
go
Create Procedure Unos_TipaMesta @naziv nvarchar(50),@cena int
as
	Set lock_timeout 3000;
	Begin Try
		if(exists(Select top 1 naziv from TipMesta where naziv=@naziv))
			Begin
				Return 1;
			end
			Else 
			Begin
				Insert Into TipMesta(naziv,cena) values(@naziv,@cena);
				Return 0;
			end
	End Try
	Begin Catch
		Return @@error;
	End Catch
go

go
Create Procedure Brisanje_TipaMesta @id int
as
	Set lock_timeout 3000;
	Begin Try
			Delete from TipMesta where id=@id;
			Return 1;
	End Try
	Begin Catch
		Return @@error;
	End Catch
go

go
Create Procedure Izmena_TipaMesta @id int, @cena int
as
	Set lock_timeout 3000;
	Begin Try
		if(exists(Select top 1 id from TipMesta where id=@id))
			Begin
				Update TipMesta set cena=@cena where id=@id;
				Return 1;
			end
	End Try
	Begin Catch
		Return @@error;
	End Catch
go

/*/////////////////////////////////////////////////////////////////////////////////// MESTO */

go
Create Procedure Unos_Mesta @tip int
as
	Set lock_timeout 3000;
	Begin Try
		Insert into Mesto values(@tip)
	End Try
	Begin Catch
		Return @@error;
	End Catch
go

go
Create Procedure Brisanje_Mesta @id int
as
	Set lock_timeout 3000;
	Begin Try
			Delete from Mesto where id=@id;
			Return 1;
	End Try
	Begin Catch
		Return @@error;
	End Catch
go

/*/////////////////////////////////////////////////////////////////////////////////// RadniDan */

go
Create or alter Procedure Unos_RadnogDana @datum date, @pocetak time, @kraj time, @duzina time
as
	Set lock_timeout 3000;
	Begin Try
		if(@pocetak>=@kraj or exists(Select top 1 datum from RadniDan where datum=@datum))
			Begin
			Return -1;
			End
		Else Begin
			Insert into RadniDan(datum,pocetak,kraj,duzina_termina) values(@datum,@pocetak,@kraj,@duzina);
			RETURN 0;
			End
	End Try
	Begin Catch
		Return @@error;
	End Catch
go

CREATE or alter PROCEDURE Unos_RadnogDana 
    @datum DATE, 
    @pocetak TIME(0), 
    @kraj TIME(0), 
    @duzina TIME(0),
    @newId INT OUTPUT 
AS
    SET LOCK_TIMEOUT 3000;
    SET @newId = -1; 
    BEGIN TRY
        IF (@pocetak >= @kraj OR EXISTS (SELECT TOP 1 datum FROM RadniDan WHERE datum = @datum))
            BEGIN
                RETURN -1;
            END
        ELSE
            BEGIN
                INSERT INTO RadniDan(datum, pocetak, kraj, duzina_termina)
                VALUES (@datum, @pocetak, @kraj, @duzina);

                SET @newId = SCOPE_IDENTITY();			
                RETURN 0;
            END
    END TRY
    BEGIN CATCH
        RETURN @@ERROR;
    END CATCH
GO

go
Create Procedure Brisanje_RadnogDana @id int
as
	Set lock_timeout 3000;
	Begin Try
		delete from RadniDan where id=@id;
	End Try
	Begin Catch
		Return @@error;
	End Catch
go

go
Create Procedure Izmena_RadnogDana @id int, @pocetak time, @kraj time, @duzina time
as
	Set lock_timeout 3000;
	Begin Try
		if(exists(Select top 1 datum from RadniDan where id=@id))
			Begin
			Update RadniDan set pocetak=@pocetak,kraj=@kraj,duzina_termina=@duzina where id=@id;
				Return 1;
			Return 1;
			End
		Else Begin
			Return 0;
			End
	End Try
	Begin Catch
		Return @@error;
	End Catch
go

/*/////////////////////////////////////////////////////////////////////////////////// Rezervacija */
go
create procedure generisi_termine_za_dan @radni_dan_id int, @mesto_id int as
begin
    set nocount on;
    set lock_timeout 3000;
    begin try
        declare @pocetak time(0);
        declare @kraj time(0);
        declare @trajanje_time time(0);
        declare @trajanje_minuta int;

        select 
            @pocetak = pocetak, 
            @kraj = kraj, 
            @trajanje_time = duzina_termina 
        from RadniDan 
        where id = @radni_dan_id;

        if @pocetak is null return 1;

        set @trajanje_minuta = datediff(minute, '00:00:00', @trajanje_time);

        if @trajanje_minuta <= 0 return 1;

        declare @curr_start time(0) = @pocetak;
        declare @curr_end time(0);

        while @curr_start < @kraj
        begin
            set @curr_end = dateadd(minute, @trajanje_minuta, @curr_start);

            if @curr_end > @kraj set @curr_end = @kraj;

            insert into Rezervacija (korisnik, radni_dan, termin_pocetak, termin_kraj, mesto)
            values (null, @radni_dan_id, @curr_start, @curr_end, @mesto_id);

            set @curr_start = @curr_end;
        end

        return 0;
    end try
    begin catch
        print error_message();
        return @@error;
    end catch
end
go

go
create or alter procedure generisi_termine_za_sva_mesta_u_danu @radni_dan_id int
as
begin
    set nocount on;
    set lock_timeout 3000;
    declare @current_mesto_id int;
    begin try
        if not exists (select 1 from RadniDan where id = @radni_dan_id)
        begin
            return 1; 
        end
		if exists(select 1 from Rezervacija where radni_dan = @radni_dan_id)
		begin
            return 1; 
        end
        declare mesto_cursor cursor for 
        select id from Mesto;
        open mesto_cursor;
        fetch next from mesto_cursor into @current_mesto_id;
        while @@fetch_status = 0
        begin
            exec generisi_termine_za_dan 
                @radni_dan_id = @radni_dan_id, 
                @mesto_id = @current_mesto_id;
            fetch next from mesto_cursor into @current_mesto_id;
        end
        close mesto_cursor;
        deallocate mesto_cursor;
        return 0;
    end try
    begin catch
        if cursor_status('global', 'mesto_cursor') >= -1
        begin
            close mesto_cursor;
            deallocate mesto_cursor;
        end
        
        print error_message();
        return @@error;
    end catch
end
go

go
Create procedure Izmena_Rezervacije @id int,@korisnik int,@radnidan int, @pocetak time,@kraj time, @mesto int
as 
	Set lock_timeout 3000;
	Begin Try
		if(@pocetak<@kraj and exists(Select top 1 id from Rezervacija where @id=id))
			Begin
				Update Rezervacija set korisnik=@korisnik,radni_dan=@radnidan,termin_pocetak=@pocetak,termin_kraj=@kraj,mesto=@mesto where id=@id;
			Return 1;
			End
		Else Begin
			Return 0;
			End
	End Try
	Begin Catch
		Return @@error;
	End Catch

go

go
Create procedure Rezervisi_Specificno_Mesto @id int,@korisnik int
as 
	Set lock_timeout 3000;
	Begin Try
			Update Rezervacija set korisnik=@korisnik where id=@id;
			Return 1;
	End Try
	Begin Catch
		Return @@error;
	End Catch

go

go
Create or alter procedure Rezervisi_Mesto_Tipa @korisnik int,@radnidan int,@pocetak time, @tip_mesta int
as 
	Set lock_timeout 3000;
	declare @id int = (Select top 1 Rezervacija.id from Rezervacija join Mesto on Rezervacija.mesto = Mesto.id where Rezervacija.korisnik is null and @tip_mesta=Mesto.tip and @radnidan=radni_dan and @pocetak=termin_pocetak);
	Begin Try
		if(@id is not null)
		Begin
			Update Rezervacija set korisnik=@korisnik where Rezervacija.id=@id;
			Return 1;
		End
		Else Begin
			Return 0;
		End
	End Try
	Begin Catch
		Return @@error;
	End Catch

go

go
Create or alter procedure Rezervisi_Vise_Mesta_Tipa @korisnik int,@radnidan int,@pocetak time, @tip_mesta int, @kolicina int
as 
	Set lock_timeout 3000;
	Begin Try
			If((Select count(Rezervacija.id) from Rezervacija join Mesto on Rezervacija.mesto = Mesto.id where Rezervacija.korisnik is null and @tip_mesta=Mesto.tip and @radnidan=radni_dan and @pocetak=termin_pocetak)>=@kolicina)
			Begin
				declare @it int = 0;
				While @it<@kolicina Begin
					Exec Rezervisi_Mesto_Tipa @korisnik,@radnidan,@pocetak,@tip_mesta;
					set @it = @it + 1;
				End
				Return 1;
			End
			Else Begin
				Return 0;
			End
	End Try
	Begin Catch
		Return @@error;
	End Catch

go

go
Create or alter procedure Broj_Slobodnih_Mesta @radnidan int,@pocetak time, @tip_mesta int
as 
	Set lock_timeout 3000;
	Begin Try
		Return (Select count(Rezervacija.id) from Rezervacija join Mesto on Rezervacija.mesto = Mesto.id where Rezervacija.korisnik is null and @tip_mesta=Mesto.tip and @radnidan=radni_dan and @pocetak=termin_pocetak);
	End Try
	Begin Catch
		Return @@error;
	End Catch

go

go
Create procedure Brisanje_Rezervacije @id int
as 
	Set lock_timeout 3000;
	Begin Try
		Delete from Rezervacija where @id=id;
	End Try
	Begin Catch
		Return @@error;
	End Catch

go

GO
CREATE OR ALTER PROCEDURE Unos_Artikla @naziv nvarchar(50), @kolicina int, @cena int
AS
    SET LOCK_TIMEOUT 3000;
    BEGIN TRY
        IF EXISTS (SELECT TOP 1 naziv FROM Artikal WHERE naziv = @naziv)
            RETURN 1;
        ELSE
        BEGIN
            INSERT INTO Artikal(naziv, kolicina, cena) VALUES (@naziv, @kolicina, @cena);
            RETURN 0;
        END
    END TRY
    BEGIN CATCH
        RETURN @@ERROR;
    END CATCH
GO

CREATE OR ALTER PROCEDURE Izmena_Artikla @id int, @naziv nvarchar(50), @kolicina int, @cena int
AS
    SET LOCK_TIMEOUT 3000;
    BEGIN TRY
        UPDATE Artikal SET naziv = @naziv, kolicina = @kolicina, cena = @cena WHERE id = @id;
        RETURN 0;
    END TRY
    BEGIN CATCH
        RETURN @@ERROR;
    END CATCH
GO

CREATE OR ALTER PROCEDURE Brisanje_Artikla @id int
AS
    SET LOCK_TIMEOUT 3000;
    BEGIN TRY
        DELETE FROM Artikal WHERE id = @id;
        RETURN 0;
    END TRY
    BEGIN CATCH
        RETURN @@ERROR;
    END CATCH
GO

-- ============================================================
-- STORED PROCEDURES: Racun
-- ============================================================

-- Kreira novi racun za korisnika na osnovu rezervacije
-- Vraca novi racun ID
CREATE OR ALTER PROCEDURE Kreiraj_Racun @korisnik int, @rezervacija int, @racunId int OUTPUT
AS
    SET LOCK_TIMEOUT 3000;
    BEGIN TRY
        INSERT INTO Racun(korisnik) VALUES (@korisnik);
        SET @racunId = SCOPE_IDENTITY();
        INSERT INTO Racun_Rezervacija(racun, rezervacija) VALUES (@racunId, @rezervacija);
        RETURN 0;
    END TRY
    BEGIN CATCH
        RETURN @@ERROR;
    END CATCH
GO

-- Dodaje artikal na racun (smanjuje zalihu)
CREATE OR ALTER PROCEDURE Dodaj_Artikal_Na_Racun @racunId int, @artikalId int, @kolicina int
AS
    SET LOCK_TIMEOUT 3000;
    BEGIN TRY
        -- Provjera zalihe
        IF (SELECT kolicina FROM Artikal WHERE id = @artikalId) < @kolicina
            RETURN -1;

        IF EXISTS (SELECT 1 FROM RacunArtikal WHERE racun = @racunId AND artikal = @artikalId)
            UPDATE RacunArtikal SET kolicina = kolicina + @kolicina
            WHERE racun = @racunId AND artikal = @artikalId;
        ELSE
            INSERT INTO RacunArtikal(racun, artikal, kolicina) VALUES (@racunId, @artikalId, @kolicina);

        UPDATE Artikal SET kolicina = kolicina - @kolicina WHERE id = @artikalId;
        RETURN 0;
    END TRY
    BEGIN CATCH
        RETURN @@ERROR;
    END CATCH
GO

-- Otkazi racun: vraca artikle na zalihu, oslobadja rezervacije, brise racun
CREATE OR ALTER PROCEDURE Otkazi_Racun @racunId int
AS
    SET LOCK_TIMEOUT 3000;
    BEGIN TRY
        -- Vrati zalihe artikala
        UPDATE a
        SET a.kolicina = a.kolicina + ra.kolicina
        FROM Artikal a
        JOIN RacunArtikal ra ON a.id = ra.artikal
        WHERE ra.racun = @racunId;

        -- Oslobodi rezervacije (postavi korisnik na NULL)
        UPDATE Rezervacija
        SET korisnik = NULL
        WHERE id IN (
            SELECT rezervacija FROM Racun_Rezervacija WHERE racun = @racunId
        );

        -- Obrisi racun (CASCADE ce obrisati RacunArtikal i Racun_Rezervacija)
        DELETE FROM Racun WHERE id = @racunId;
        RETURN 0;
    END TRY
    BEGIN CATCH
        RETURN @@ERROR;
    END CATCH
GO

-- Prikaz racuna korisnika
CREATE OR ALTER VIEW ViewRacuniKorisnika AS
    SELECT
        r.id AS racun_id,
        r.korisnik,
        rd.datum,
        rr.rezervacija AS rezervacija_id,
        rez.termin_pocetak,
        rez.termin_kraj,
        tm.naziv AS tip_mesta
    FROM Racun r
    JOIN Racun_Rezervacija rr ON r.id = rr.racun
    JOIN Rezervacija rez ON rr.rezervacija = rez.id
    JOIN RadniDan rd ON rez.radni_dan = rd.id
    JOIN Mesto m ON rez.mesto = m.id
    JOIN TipMesta tm ON m.tip = tm.id;
GO

-- Suma racuna (rezervacije + artikli)

CREATE OR ALTER VIEW ViewRacunSuma AS
    SELECT
        r.id        AS racun_id,
        r.korisnik,
        ISNULL(rez_suma.cena_rezervacija, 0) + ISNULL(art_suma.cena_artikala, 0) AS ukupno
    FROM Racun r

    -- Suma cena svih rezervacija na racunu (svako mesto se racuna posebno)
    LEFT JOIN (
        SELECT rr.racun, SUM(tm.cena) AS cena_rezervacija
        FROM Racun_Rezervacija rr
        JOIN Rezervacija rez ON rr.rezervacija = rez.id
        JOIN Mesto       m   ON rez.mesto      = m.id
        JOIN TipMesta    tm  ON m.tip           = tm.id
        GROUP BY rr.racun
    ) rez_suma ON rez_suma.racun = r.id

    -- Suma cena artikala na racunu
    LEFT JOIN (
        SELECT ra.racun, SUM(ra.kolicina * a.cena) AS cena_artikala
        FROM RacunArtikal ra
        JOIN Artikal a ON ra.artikal = a.id
        GROUP BY ra.racun
    ) art_suma ON art_suma.racun = r.id;
GO
create or alter view viewRacuni as SELECT DISTINCT top 1000
                    r.korisnik as rdk
					,r.id                                    AS [Racun ID],
                    rd.datum                                AS [Datum],
                    LEFT(CONVERT(VARCHAR, rez.termin_pocetak, 108), 5)
                        + ' - ' +
                    LEFT(CONVERT(VARCHAR, rez.termin_kraj,   108), 5) AS [Termin],
                    tm.naziv                                AS [Tip mesta],
                    ISNULL(rs.ukupno, 0)                   AS [Ukupno RSD]
                FROM Racun r
                JOIN Racun_Rezervacija rr  ON r.id = rr.racun
                JOIN Rezervacija       rez ON rr.rezervacija = rez.id
                JOIN RadniDan          rd  ON rez.radni_dan = rd.id
                JOIN Mesto             m   ON rez.mesto = m.id
                JOIN TipMesta          tm  ON m.tip = tm.id
                LEFT JOIN ViewRacunSuma rs ON rs.racun_id = r.id
				ORDER BY rd.datum DESC, r.id DESC
/*/////////////////////VIEWS///////////////////// */
create or alter view ViewTermini as select distinct CONCAT(LEFT(CONVERT(VARCHAR, termin_pocetak, 108), 5) ,'-',LEFT(CONVERT(VARCHAR, termin_kraj, 108), 5)) as Termin ,termin_pocetak,radni_dan from Rezervacija join Mesto on Rezervacija.mesto=Mesto.id join TipMesta on Mesto.tip = TipMesta.id where korisnik is null
create or alter view ViewTipoviMesta as select distinct TipMesta.id,TipMesta.naziv,radni_dan from Rezervacija join Mesto on Rezervacija.mesto=Mesto.id join TipMesta on Mesto.tip = TipMesta.id where korisnik is null;
create view viewBrojMestaPoTipu as SELECT tm.id, tm.naziv, COUNT(m.id) AS broj_mesta FROM TipMesta tm LEFT JOIN Mesto m ON tm.id = m.tip GROUP BY tm.id, tm.naziv
