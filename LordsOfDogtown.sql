--creating the datatables
CREATE TABLE Neighborhood (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    [Name] VARCHAR(55) NOT NULL
);

CREATE TABLE [OWNER] (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    [Name] VARCHAR(55) NOT NULL,
    [Address] VARCHAR(255) NOT NULL,
    NeighborhoodId INTEGER NOT NULL,
    Phone VARCHAR(55) NOT NULL 
    CONSTRAINT FK_Owner_Neighborhood FOREIGN KEY(NeighborhoodId) REFERENCES Neighborhood(Id)
    );

CREATE TABLE Walker (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(55) NOT NULL,
    NeighborhoodId INTEGER NOT NULL
    CONSTRAINT FK_Walker_Neighborhood FOREIGN KEY(NeighborhoodId) REFERENCES Neighborhood(Id)
);

CREATE TABLE Dog (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(55) NOT NULL,
    OwnerId INTEGER NOT NULL,
    Breed VARCHAR(55) NOT NULL,
    Notes VARCHAR(255) NOT NULL
    CONSTRAINT FK_Dog_Owner FOREIGN KEY(OwnerId) REFERENCES [Owner](Id)
);

CREATE TABLE Walks (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY, 
    [Date] DATETIME NOT NULL, 
    Duration INTEGER NOT NULL,
    WalkerId INTEGER NOT NULL,
    DogId INTEGER NOT NULL
    CONSTRAINT FK_Walks_Dog FOREIGN KEY(DogId) REFERENCES Dog(Id),
    CONSTRAINT FK_Walks_Walker FOREIGN KEY(WalkerId) References Walker(Id)
);


--creating neighborhoods
INSERT INTO Neighborhood ([Name]) VALUES ('12th South');
INSERT INTO Neighborhood ([Name]) VALUES ('Green Hills');
INSERT INTO Neighborhood ([Name]) VALUES ('5 Points');

--creating owners
INSERT INTO [OWNER] ([Name], [Address], NeighborhoodId, Phone) VALUES ('Josh', '1216 12th ave s.', 1, '(615) 555-1234'); 
INSERT INTO [OWNER] ([Name], [Address], NeighborhoodId, Phone) VALUES ('Jessica', '1216 Richard Jones Ave.', 2, '(615) 555-1234');  
INSERT INTO [OWNER] ([Name], [Address], NeighborhoodId, Phone) VALUES ('Huey', '202 Woodland st.', 3, '(615) 555-1234');  
INSERT INTO [OWNER] ([Name], [Address], NeighborhoodId, Phone) VALUES ('Henry', '111 Sweetbriar Ave.', 1, '(615) 555-1234');  
INSERT INTO [OWNER] ([Name], [Address], NeighborhoodId, Phone) VALUES ('Emma', '12 Hilsboro Blvd.', 2, '(615) 555-1234');  
INSERT INTO [OWNER] ([Name], [Address], NeighborhoodId, Phone) VALUES ('Ellie', '151 Holly St.', 3, '(615) 555-1234');  
INSERT INTO [OWNER] ([Name], [Address], NeighborhoodId, Phone) VALUES ('George', '303 YMCA Way.', 2, '(615) 555-1234');  
INSERT INTO [OWNER] ([Name], [Address], NeighborhoodId, Phone) VALUES ('Gina', '140 11th St.', 3, '(615) 555-1234');  

--creating walkers
INSERT INTO Walker([Name], NeighborhoodId) VALUES ('Jason', 1);
INSERT INTO Walker([Name], NeighborhoodId) VALUES ('Hank', 2);
INSERT INTO Walker ([Name], NeighborhoodId) Values ('Sara', 3);

--creating dogs
INSERT INTO Dog ([Name], Breed, Notes, OwnerId) VALUES ('Margot', 'Blue Heeler', 'She nips at people. Keep her away from children', 3);
INSERT INTO Dog ([Name], Breed, Notes, OwnerId) VALUES ('Ruby', 'Boston Terrior', 'She is sweet', 2);
INSERT INTO Dog ([Name], Breed, Notes, OwnerId) VALUES ('Bean', 'American Bulldog', 'Can not walk far', 1);
INSERT INTO Dog ([Name], Breed, Notes, OwnerId) VALUES ('Winston', 'Pug', 'He is sweet', 1);
INSERT INTO Dog ([Name], Breed, Notes, OwnerId) VALUES ('Rufus', 'Golden Retriever', 'He loves Fetch', 4);
INSERT INTO Dog ([Name], Breed, Notes, OwnerId) VALUES ('Rex', 'Goldendoodle', 'He loves fetch', 4);
INSERT INTO Dog ([Name], Breed, Notes, OwnerId) VALUES ('Blue', 'Australian Shepard', 'Loves to run.', 5);
INSERT INTO Dog ([Name], Breed, Notes, OwnerId) VALUES ('Mark', 'Border Collie', 'Super smart. play games with him', 6);
INSERT INTO Dog ([Name], Breed, Notes, OwnerId) VALUES ('Zip', 'Mutt', 'good boy', 7);
INSERT INTO Dog ([Name], Breed, Notes, OwnerId) VALUES ('Fred', 'Scottish Terrier', 'Likes to bark', 8);

--creating walks
INSERT INTO Walks ([Date], Duration, WalkerId, DogId) VALUES ('03/12/2020', 45, 1,2);
INSERT INTO Walks ([Date], Duration, WalkerId, DogId) VALUES ('03/18/2020', 45, 1,1);
INSERT INTO Walks ([Date], Duration, WalkerId, DogId) VALUES ('03/18/2020', 45, 2,3);
INSERT INTO Walks ([Date], Duration, WalkerId, DogId) VALUES ('03/20/2020', 45, 2,4);
INSERT INTO Walks ([Date], Duration, WalkerId, DogId) VALUES ('03/12/2020', 45, 3,5);
INSERT INTO Walks ([Date], Duration, WalkerId, DogId) VALUES ('03/21/2020', 45, 3,6);

