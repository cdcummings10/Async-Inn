# Async Inn

*Author: Chris Cummings*

----

## Azure Deployment: https://asyncinn.azurewebsites.net/


## Description
This app is a mock creation of a MVC site using Entity Framework to create a relational database.

---

## Tools Used
Microsoft Visual Studio Community 2019 (Version 16.3.6)

- C#
- ASP.Net Core
- MVC
- Azure
- Entity Framework Core

---

### Getting Started
Clone this repository to your local machine.

```
$ git clone https://github.com/cdcummings10/Async-Inn.git
```
Once downloaded, you can either use the dotnet CLI utilities or Visual Studio 2019 (or greater) to build 
the web application. The solution file is located in the AsyncInn/AsyncInn
subdirectory at the root of the repository.
```
cd AsyncInn/AsyncInn
dotnet build
```

---

### Diagrams
#### ERD
![Entity Relational Diagram](img/ERD.png)

#### Description

**Rooms:** The room table has connections to RoomAmenities and HotelRooms in a one to many relationship. It also
has an enum of layouts. The table holds information on rooms, such as the layout as well as the name of the room.

**HotelRooms:** The HotelRooms table is a joint table with payload.  It's composite key is HotelID and RoomNumber,
though it takes in a RoomID foreign key.  It has connections to Hotels and Rooms table in a many to one relationship.

**Hotels:** The Hotels table has connections only to the HotelRooms Table in a one to many relationship.  This table
holds the location data for the hotel itself.

**RoomAmenities:** The RoomAmenitites table is a pure joint tale.  It has a composite key of AmenitiesID and RoomID,
as well as a many to one relationship with those tables as well.

**Amenities:** The Amenities table holds all the information for the amenities that can be added to a hotel room.
It has a one to many relationship with the RoomAmenities table.

### Visuals

TBD


---

### Time Estimates
Estimated time to finish: 40 Hours

Actual time to finish: 20 Hours

### Change Log 

1.0: *Created initial site, added DB functionality and connection.* - 31 Oct 2019

1.1: *Updated to bootstrap and added CRUD functionality.* - 4 Nov 2019

1.2: *Implemented repository design pattern. Added interfaces and reattachd functionality.* - 4 Nov 2019

1.3: *Finished based functionality of site, added some tests.* - 10 Nov 2019
