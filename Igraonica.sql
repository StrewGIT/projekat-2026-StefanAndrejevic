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
rezervacija int foreign key references Rezervacija(id),
artikal int foreign key references Artikal(id),
kolicina int
)

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
Create Procedure Unos_RadnogDana @datum date, @pocetak time, @kraj time, @duzina time
as
	Set lock_timeout 3000;
	Begin Try
		if(@pocetak>=@kraj or exists(Select top 1 datum from RadniDan where datum=@datum))
			Begin
			Return 1;
			End
		Else Begin
			Insert into RadniDan(datum,pocetak,kraj,duzina_termina) values(@datum,@pocetak,@kraj,@duzina);
			End
	End Try
	Begin Catch
		Return @@error;
	End Catch
go

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